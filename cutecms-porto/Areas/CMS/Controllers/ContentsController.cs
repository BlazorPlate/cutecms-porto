using cutecms_porto.Areas.CMS.Models;
using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Areas.Identity.Models;
using cutecms_porto.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.CMS.Controllers
{
    [LocalizedAuthorize(Roles = "Admin,CMS,Contents")]
    public class ContentsController : BaseController
    {
        #region Fields
        private string cultureName = null;
        private ApplicationDbContext _db = new ApplicationDbContext();
        private CMSEntities db = new CMSEntities();
        private int? statusId;
        private List<object> menuItemsList = new List<object>();
        private string menuItemPath = "";
        #endregion Fields

        #region Methods
        public string GetParents(MenuItem element)
        {
            if (element.ParentId == null)
            {
                menuItemPath = element.Name + "/" + menuItemPath;
                return menuItemPath;
            }
            MenuItem menuItem = element;
            menuItemPath = db.MenuItems.Find(menuItem.Id).Name + "/" + menuItemPath;
            GetParents(db.MenuItems.Find(menuItem.ParentId));
            return menuItemPath;
        }

        public List<object> GetMenuItemsServerSide(int languageId)
        {
            var menuItems = db.MenuItems.Include("Menu").Where(mi => mi.Menu.TenantId.Trim().Equals(Tenant.TenantId) && mi.LanguageId == languageId && mi.IsParent && mi.Menu.Code.Trim().Equals("header")).OrderBy(mi => mi.MenuItem1.Ordinal);
            foreach (var item in menuItems)
            {
                menuItemsList.Add(new
                {
                    Id = item.Id,
                    Name = GetParents(item)
                }
                 );
                menuItemPath = "";
            }
            return menuItemsList;
        }

        public JsonResult GetMenuItemsClientSide(int languageId)
        {
            var menuItems = db.MenuItems.Include("Menu").Where(mi => mi.Menu.TenantId.Trim().Equals(Tenant.TenantId) && mi.LanguageId == languageId && mi.IsParent && mi.Menu.Code.Trim().Equals("header")).OrderBy(mi => mi.MenuItem1.Ordinal); ;
            foreach (var item in menuItems)
            {
                menuItemsList.Add(new
                {
                    Id = item.Id,
                    Name = GetParents(item)
                }
                 );
                menuItemPath = "";
            }
            return Json(new SelectList(menuItemsList, "Id", "Name", Resources.Resources.ChooseParentMenuItem));
        }
        public ActionResult Translations(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            ViewBag.TranslationId = id;
            List<string> roles = GetUserRoles();
            IEnumerable<ContentsViewModel> ContentsJoinUsersQuery =
                (from c in db.Contents.Include("Status").Include("ContentType").Include("Language").Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && (roles.Any(r => c.RoleVID.Equals(r)) || c.RoleVID == null) && c.TranslationId == id).ToList()
                 join auu in _db.Users on c.Author equals auu.Id
                 orderby c.CreatedOn ascending
                 orderby c.LanguageId
                 select new ContentsViewModel
                 {
                     Id = c.Id,
                     Title = c.Title,
                     UrlSlug = c.UrlSlug,
                     AbsolutePath = c.AbsolutePath,
                     ContentType = c.ContentType.ContentTypeTerms.Where(c => c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault() != null ? c.ContentType.ContentTypeTerms.Where(c => c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value : c.ContentType.Code,
                     Author = auu.UserName,
                     Language = c.Language.Name,
                     CreatedOn = c.CreatedOn,
                     IsTranslated = c.IsTranslated,
                     Status = (c.Status.StatusTerms.Where(s => s.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault() != null) ? c.Status.StatusTerms.Where(s => s.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value : c.Status.Code,
                     TranslationId = c.TranslationId
                 });

            return View(ContentsJoinUsersQuery);
        }
        // GET: /Contents/
        public ActionResult Index(int? page, string pageTitleFilter, string pathFilter, string statusMessage, int? languageIdFilter, int? contentTypeIdFilter, int? statusIdFilter, int? statusId, string authorIdFilter = null)
        {
            var pageNumber = page ?? 1;// if no page was specified in the querystring, default to the first page (1)
            if (string.IsNullOrWhiteSpace(pageTitleFilter))
            {
                pageTitleFilter = null;
            }
            else
            {
                pageTitleFilter.Trim();
            }
            if (string.IsNullOrWhiteSpace(authorIdFilter))
            {
                authorIdFilter = null;
            }
            ViewBag.ContentTypeIdFilter = new SelectList(TermsHelper.ContentTypes(), "ContentTypeId", "Value", contentTypeIdFilter);
            ViewBag.AuthorIdFilter = new SelectList(_db.Users, "Id", "Email", statusIdFilter);
            ViewBag.LanguageIdFilter = new SelectList(db.CMSLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", languageIdFilter);
            ViewBag.StatusIdFilter = new SelectList(TermsHelper.Statuses(), "StatusId", "Value", statusIdFilter);
            ViewBag.PageTitleFilter = pageTitleFilter;
            ViewBag.PathFilter = pathFilter;
            ViewBag.ContentTypeId = contentTypeIdFilter;
            ViewBag.AuthorId = authorIdFilter;
            ViewBag.LanguageId = languageIdFilter;
            ViewBag.StatusId = statusIdFilter;

            List<string> roles = GetUserRoles();
            IEnumerable<ContentsViewModel> ContentsJoinUsersQuery =
                (from c in db.Contents.Include("ContentType").Include("Language").Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && (roles.Any(r => c.RoleVID.Equals(r)) || c.RoleVID == null) && (c.Title.Contains(pageTitleFilter) || string.IsNullOrEmpty(pageTitleFilter)) && (c.AbsolutePath.Contains(pathFilter) || string.IsNullOrEmpty(pathFilter)) && (c.LanguageId == languageIdFilter || languageIdFilter == null) && (c.Author == authorIdFilter || authorIdFilter == null) && (c.ContentTypeId == contentTypeIdFilter || contentTypeIdFilter == null) && (c.StatusId == statusIdFilter || statusIdFilter == null)).ToList()
                 join auu in _db.Users on c.Author equals auu.Id
                 orderby c.CreatedOn ascending
                 orderby c.LanguageId
                 select new ContentsViewModel
                 {
                     Id = c.Id,
                     Title = c.Title,
                     UrlSlug = c.UrlSlug,
                     AbsolutePath = c.AbsolutePath,
                     ContentType = c.ContentType.ContentTypeTerms.Where(c => c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault() != null ? c.ContentType.ContentTypeTerms.Where(c => c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault().Value : c.ContentType.Code,
                     Author = auu.UserName,
                     Language = c.Language.Name,
                     CreatedOn = c.CreatedOn,
                     IsTranslated = c.IsTranslated,
                     Status = (TermsHelper.Statuses(c.StatusId).FirstOrDefault() != null ? TermsHelper.Statuses().Where(s => s.StatusId == c.StatusId).FirstOrDefault().Value : db.CMSStatuses.Find(c.StatusId).Code),
                     TranslationId = c.TranslationId
                 }).ToPagedList(pageNumber, 10);
            ViewBag.StatusMessageId = statusId;
            return View(ContentsJoinUsersQuery);
        }

        // GET: /Contents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            List<string> roles = GetUserRoles();
            Content content = db.Contents.Include("Language").Include("Status.StatusTerms.Language").Include("Status.StatusTerms").Include("Status.StatusTerms.Language").Include("ContentType").Include("ContentType.ContentTypeTerms").Include("ContentType.ContentTypeTerms.Language").Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && (roles.Any(r => c.RoleVID.Equals(r)) || c.RoleVID == null) && c.Id == id).FirstOrDefault();
            if (content == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.Author = _db.Users.Find(content.Author).UserName;
            ViewBag.ModifiedBy = _db.Users.Find(content.ModifiedBy).UserName;
            return View(content);
        }

        // GET: /Contents/Create
        public ActionResult Create(int? id)
        {
            int[] assignedLanguages = db.Contents.Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && c.TranslationId == id).Select(c => c.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            ViewBag.RoleVID = new SelectList(_db.Roles, "Id", "Name");
            ViewBag.ContentTypeId = new SelectList(TermsHelper.ContentTypes(), "ContentTypeId", "Value");
            ViewBag.StatusId = new SelectList(TermsHelper.Statuses(), "StatusId", "Value");
            Content content = new Content();
            content.TranslationId = id;
            return View(content);
        }

        // POST: /Contents/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ContentTypeId,Code,Title,Subtitle,MainContent,Location,MetaDescription,Image,TranslationId,LanguageId,IsUrgent,UrgentExpiredOn,HasShortcut,ShortcutTitle,CssClass,Ordinal,StartDate,EndDate,PublishedOn,ExpiredOn,ParentMenuItemId,HasMenuItem,RoleVID,StatusId")] Content content, int? width, int? height)
        {
            var contentStatus = db.CMSStatuses.Find(content.StatusId);
            if (contentStatus.Code.Trim().Equals("published"))
                content.PublishedOn = DateTime.Now;
            content.PublishedOn = DateTime.Now;
            if (content.PublishedOn != null && content.StartDate != null)
            {
                if (content.PublishedOn > content.StartDate)
                {
                    ModelState.AddModelError("InvalidPublishDate", Resources.Resources.InvalidPublishDate);
                }
            }
            if (content.ExpiredOn != null && content.EndDate != null)
            {
                if (content.ExpiredOn < content.EndDate)
                {
                    ModelState.AddModelError("InvalidExpiryDate", Resources.Resources.InvalidExpiryDate);
                }
            }
            if (content.Image != null && content.Image.ContentLength > 0)
            {
                var extension = Path.GetExtension(content.Image.FileName);
                var newFileName = Helpers.StringHelper.CleanFileName(content.Title + extension);
                //var newFileName = listItem.Title + extension;
                var path = String.Format("/fileman/Uploads/Images/CMS/Contents/Images/{0}", newFileName);
                content.ImagePath = path;
                content.ImageName = newFileName;
                using (var img = System.Drawing.Image.FromStream(content.Image.InputStream))
                {
                    if (width == null)
                        width = img.Width;
                    if (height == null)
                        height = img.Height;
                    ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(width.Value, height.Value), content.ImagePath);
                }
            }
            if (ModelState.IsValid)
            {
                var culture = db.CMSLanguages.Find(content.LanguageId).CultureName.Trim();
                content.Title = content.Title.Trim();
                if (string.IsNullOrEmpty(content.ShortcutTitle))
                    content.ShortcutTitle = content.Title;
                using (TransactionScope ts = new TransactionScope())
                {
                    using (var db = new CMSEntities())
                    {
                        try
                        {
                            MenuItem menuItem = new MenuItem();
                            Random rnd = new Random();
                            content.UrlCode = rnd.Next(1000, 9999);
                            if (content.ParentMenuItemId == -1)
                            {
                                content.ParentMenuItemId = null;
                            }
                            if (content.HasMenuItem)
                            {
                                int? menuId = db.Menus.Where(m => m.TenantId.Trim().Equals(Tenant.TenantId) && m.Code.Trim().Equals("header")).FirstOrDefault()?.Id;
                                if (menuId == null)
                                {
                                    Menu menu = new Menu();
                                    menu.Code = "header";
                                    menu.Visible = true;
                                    menu.Ordinal = 0;
                                    menu.TenantId = Tenant.TenantId;
                                    db.Menus.Add(menu);
                                    db.SaveChanges();
                                    menuItem.MenuId = menu.Id;
                                }
                                else
                                {
                                    menuItem.MenuId = db.Menus.Where(m => m.TenantId.Trim().Equals(Tenant.TenantId) && m.Code.Trim().Equals("header")).FirstOrDefault().Id;
                                }

                                if (content.ParentMenuItemId != null)
                                {
                                    StringHelper.MenuItemsList.Clear();
                                    StringHelper.ParentMenuItemPath = string.Empty;
                                    string parentMenuItemPath = StringHelper.GetParentMenuItemPath(content.ParentMenuItemId, content.LanguageId);
                                    var link = StringHelper.BuildUrl(content.UrlCode, culture, content.ContentTypeId, parentMenuItemPath, content.Title, true);
                                    content.UrlSlug = link.Item1;
                                    content.AbsolutePath = link.Item2;
                                    menuItem.Path = link.Item2;
                                    menuItem.ParentId = content.ParentMenuItemId;
                                }
                                else
                                {
                                    var link = StringHelper.BuildUrl(content.UrlCode, culture, content.ContentTypeId, null, content.Title, true);
                                    content.UrlSlug = link.Item1;
                                    content.AbsolutePath = link.Item2;
                                    menuItem.Path = link.Item2;
                                }
                                menuItem.Name = content.Title;
                                menuItem.LanguageId = content.LanguageId;
                                menuItem.IsCms = true;
                                menuItem.IsLeaf = true;
                                menuItem.Visible = true;
                                menuItem.StatusId = content.StatusId;
                            }
                            else
                            {
                                var link = StringHelper.BuildUrl(content.UrlCode, culture, content.ContentTypeId, null, content.Title, false);
                                content.UrlSlug = link.Item1;
                                content.AbsolutePath = link.Item2;
                            }
                            cultureName = db.CMSLanguages.Find(content.LanguageId).CultureName.Trim();
                            content.Author = User.Identity.GetUserId();
                            content.CreatedOn = DateTime.Now;
                            content.ModifiedBy = User.Identity.GetUserId();
                            content.ModifiedOn = DateTime.Now;
                            db.Entry(content).State = EntityState.Added;
                            db.SaveChanges();
                            if (content.TranslationId == null)
                                content.TranslationId = content.Id;
                            content.TenantId = Tenant.TenantId;
                            db.Entry(content).State = EntityState.Modified;
                            if (content.HasMenuItem)
                            {
                                menuItem.ContentId = content.Id;
                                db.MenuItems.Add(menuItem);
                                db.Entry(menuItem).State = EntityState.Added;
                            }
                            db.SaveChanges();
                            CacheHelper.ClearCache();
                            statusId = contentStatus.Id;
                   
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("error", ex.ToString());
                        }
                        ts.Complete();
                        return RedirectToAction("Index", new { statusId = statusId });
                    }
                }
            }
            ViewBag.ParentMenuItemId = new SelectList(db.MenuItems.Include("Menu").Where(m => m.Menu.TenantId.Trim().Equals(Tenant.TenantId) && m.Language.CultureName.Trim().Equals(content.Language.Name)), "Id", "Name", content.ParentMenuItemId);
            int[] assignedLanguages = db.Contents.Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && c.TranslationId == content.TranslationId).Select(v => v.LanguageId).ToArray();
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => !assignedLanguages.Contains(l.Id) && l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            ViewBag.ContentTypeId = new SelectList(TermsHelper.ContentTypes(), "ContentTypeId", "Value", content.ContentTypeId);
            ViewBag.StatusId = new SelectList(TermsHelper.Statuses(), "StatusId", "Value", content.StatusId);
            ViewBag.RoleVID = new SelectList(_db.Roles, "Id", "Name", content.RoleVID);
            return View(content);
        }

        // GET: /Contents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            List<string> roles = GetUserRoles();
            Content content = db.Contents.Include("Language").Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && (roles.Any(r => c.RoleVID.Equals(r)) || c.RoleVID == null) && c.Id == id).FirstOrDefault();
            if (content == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.Language = content.Language.Name;
            ViewBag.ContentTypeId = new SelectList(TermsHelper.ContentTypes(), "ContentTypeId", "Value", content.ContentTypeId);
            ViewBag.StatusId = new SelectList(TermsHelper.Statuses(), "StatusId", "Value", content.StatusId);
            ViewBag.ParentMenuItemId = new SelectList(GetMenuItemsServerSide(content.LanguageId), "Id", "Name", content.ParentMenuItemId);
            ViewBag.Author = _db.Users.Find(content.Author).UserName;
            ViewBag.ModifiedBy = _db.Users.Find(content.ModifiedBy).UserName;
            ViewBag.RoleVID = new SelectList(_db.Roles, "Id", "Name", content.RoleVID);
            return View(content);
        }

        // POST: /Contents/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ContentTypeId,Title,Subtitle,Code,MainContent,Location,LanguageId,UrlCode,IsPublished,MetaDescription,Image,ImagePath,ImageName,Author,ModifiedBy,PublishedOn,CreatedOn,ModifiedOn,TranslationId,IsTranslated,IsUrgent,UrgentExpiredOn,HasShortcut,ShortcutTitle,CssClass,Ordinal,StartDate,EndDate,PublishedOn,ExpiredOn,ParentMenuItemId,HasMenuItem,RoleVID,StatusId")] Content content, string status, int? width, int? height)
        {
            var contentStatus = db.CMSStatuses.Find(content.StatusId);
            if (contentStatus.Code.Trim().Equals("published") && content.PublishedOn == null)
                content.PublishedOn = DateTime.Now;
            else if (contentStatus.Code.Trim().Equals("archived"))
                content.PublishedOn = null;
            //if (content.PublishedOn != null && content.StartDate != null)
            //{
            //    if (content.PublishedOn > content.StartDate)
            //    {
            //        ModelState.AddModelError("InvalidPublishDate", Resources.Resources.InvalidPublishDate);
            //    }
            //}
            //if (content.ExpiredOn != null && content.EndDate != null)
            //{
            //    if (content.ExpiredOn < content.EndDate)
            //    {
            //        ModelState.AddModelError("InvalidExpiryDate", Resources.Resources.InvalidExpiryDate);
            //    }
            //}

            if (ModelState.IsValid)
            {
                if (content.Image != null && content.Image.ContentLength > 0)
                {
                    var extension = Path.GetExtension(content.Image.FileName);
                    var newFileName = Helpers.StringHelper.CleanFileName(content.Title + extension);
                    //var newFileName = listItem.Title + extension;
                    var path = String.Format("/fileman/Uploads/Images/CMS/Contents/Images/{0}", newFileName);
                    content.ImagePath = path;
                    content.ImageName = newFileName;
                    using (var img = System.Drawing.Image.FromStream(content.Image.InputStream))
                    {
                        if (width == null)
                            width = img.Width;
                        if (height == null)
                            height = img.Height;
                        ImageUploaderHelper.SaveImageToFolder(img, extension, new Size(width.Value, height.Value), content.ImagePath);
                    }
                }
                var culture = db.CMSLanguages.Find(content.LanguageId).CultureName.Trim();
                content.Title = content.Title.Trim();
                if (string.IsNullOrEmpty(content.ShortcutTitle))
                    content.ShortcutTitle = content.Title;
                if (content.UrlCode == null)
                {
                    Random rnd = new Random();
                    content.UrlCode = rnd.Next(1000, 9999);
                }
                using (TransactionScope ts = new TransactionScope())
                {
                using (var db = new CMSEntities())
                {     
                        try
                        {
                            MenuItem menuItem = new MenuItem();
                            menuItem = db.MenuItems.Include("Menu").Where(mi => mi.Menu.TenantId.Trim().Equals(Tenant.TenantId) && mi.ContentId == content.Id).FirstOrDefault();
                            int menuItemOrdinal = 0;
                            if (menuItem != null)
                            {
                                menuItemOrdinal = menuItem.Ordinal;
                                db.MenuItems.Remove(menuItem);
                            }
                            if (content.HasMenuItem)
                            {
                                menuItem = new MenuItem();
                                if (content.ParentMenuItemId != null)
                                {
                                    StringHelper.MenuItemsList.Clear();
                                    StringHelper.ParentMenuItemPath = string.Empty;
                                    string parentMenuItemPath = StringHelper.GetParentMenuItemPath(content.ParentMenuItemId, content.LanguageId);
                                    var link = StringHelper.BuildUrl(content.UrlCode, culture, content.ContentTypeId, parentMenuItemPath, content.Title, true);
                                    content.UrlSlug = link.Item1;
                                    content.AbsolutePath = link.Item2;
                                    menuItem.Path = link.Item2;
                                }
                                else
                                {
                                    var link = StringHelper.BuildUrl(content.UrlCode, culture, content.ContentTypeId, null, content.Title, true);
                                    content.UrlSlug = link.Item1;
                                    content.AbsolutePath = link.Item2;
                                    menuItem.Path = link.Item2;
                                }
                                menuItem.Name = content.Title;
                                menuItem.MenuId = db.Menus.Where(m => m.TenantId.Trim().Equals(Tenant.TenantId) && m.Code.Trim().Equals("header")).FirstOrDefault().Id;
                                menuItem.ParentId = content.ParentMenuItemId;
                                menuItem.LanguageId = content.LanguageId;
                                menuItem.ContentId = content.Id;
                                menuItem.IsCms = true;
                                menuItem.IsLeaf = true;
                                menuItem.Visible = true;
                                menuItem.StatusId = content.StatusId;
                                menuItem.Ordinal = menuItemOrdinal;
                                db.Entry(menuItem).State = EntityState.Added;
                            }
                            else
                            {
                                var link = StringHelper.BuildUrl(content.UrlCode, culture, content.ContentTypeId, null, content.Title, false);
                                content.AbsolutePath = link.Item2;
                                content.UrlSlug = link.Item1;
                            }
                            cultureName = db.CMSLanguages.Find(content.LanguageId).CultureName.Trim();
                            content.ModifiedBy = User.Identity.GetUserId();
                            content.ModifiedOn = DateTime.Now;
                            content.TenantId = Tenant.TenantId;
                            db.Entry(content).State = EntityState.Modified;
                            db.SaveChanges();
                            CacheHelper.ClearCache();
                            statusId = contentStatus.Id;

                        }
                        catch
                        {
                            ViewBag.Language = db.CMSLanguages.Find(content.LanguageId).Name;
                            ViewBag.ContentTypeId = new SelectList(TermsHelper.ContentTypes(), "ContentTypeId", "Value", content.ContentTypeId);
                            ViewBag.StatusId = new SelectList(TermsHelper.Statuses(), "StatusId", "Value", content.StatusId);
                            ViewBag.ParentMenuItemId = new SelectList(GetMenuItemsServerSide(content.LanguageId), "Id", "Name", content.ParentMenuItemId);
                            ViewBag.Author = _db.Users.Find(content.Author).UserName;
                            ViewBag.ModifiedBy = _db.Users.Find(content.ModifiedBy).UserName;
                            ViewBag.RoleVID = new SelectList(_db.Roles, "Id", "Name", content.RoleVID);
                            return View(content);
                        }
                        ts.Complete();
                        return RedirectToAction("Index", new { statusId = statusId });  
                    }
                }
            }
            ViewBag.Language = db.CMSLanguages.Find(content.LanguageId).Name;
            ViewBag.ContentTypeId = new SelectList(TermsHelper.ContentTypes(), "ContentTypeId", "Value", content.ContentTypeId);
            ViewBag.StatusId = new SelectList(TermsHelper.Statuses(), "StatusId", "Value", content.StatusId);
            ViewBag.ParentMenuItemId = new SelectList(GetMenuItemsServerSide(content.LanguageId), "Id", "Name", content.ParentMenuItemId);
            ViewBag.RoleVID = new SelectList(_db.Roles, "Id", "Name", content.RoleVID);
            ViewBag.Author = _db.Users.Find(content.Author).UserName;
            ViewBag.ModifiedBy = _db.Users.Find(content.ModifiedBy).UserName;
            return View(content);
        }

        // GET: /Contents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            List<string> roles = GetUserRoles();
            Content content = db.Contents.Include("Language").Include("Status.StatusTerms.Language").Include("Status.StatusTerms").Include("Status.StatusTerms.Language").Include("ContentType").Include("ContentType.ContentTypeTerms").Include("ContentType.ContentTypeTerms.Language").Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && (roles.Any(r => c.RoleVID.Equals(r)) || c.RoleVID == null) && c.Id == id).FirstOrDefault();
            if (content == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.Author = _db.Users.Find(content.Author).UserName;
            ViewBag.ModifiedBy = _db.Users.Find(content.ModifiedBy).UserName;
            return View(content);
        }

        // POST: /Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (TransactionScope ts = new TransactionScope())
            {
            using (var db = new CMSEntities())
            {
                    try
                    {
                        Content content = db.Contents.Find(id);
                        db.Entry(content).State = EntityState.Deleted;
                        db.Contents.Remove(content);
                        db.SaveChanges();
                        Content translatedContent = db.Contents.Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && c.TranslationId == content.TranslationId).FirstOrDefault();
                        if (translatedContent != null)
                        {
                            db.Entry(translatedContent).State = EntityState.Modified;
                            translatedContent.IsTranslated = false;
                            translatedContent.TranslationId = translatedContent.Id;
                            db.SaveChanges();
                        }

                        MenuItem menuItem = new MenuItem();
                        menuItem = db.MenuItems.Include("Menu").Where(mi => mi.Menu.TenantId.Trim().Equals(Tenant.TenantId) && mi.ContentId == id).FirstOrDefault();
                        if (menuItem != null)
                        {
                            db.MenuItems.Remove(menuItem);
                            db.SaveChanges();
                        }

                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("error", ex.ToString());
                        return View();
                    }
                    ts.Complete();
                }
            }
            CacheHelper.ClearCache();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private List<string> GetUserRoles()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var userRoles = manager.GetRoles(User.Identity.GetUserId());
            List<string> roleIds = new List<string>();
            foreach (var item in userRoles)
            {
                roleIds.Add(_db.Roles.Where(r => r.Name.Equals(item)).Single().Id);
            }
            return roleIds;
        }
        #endregion Methods
    }
}