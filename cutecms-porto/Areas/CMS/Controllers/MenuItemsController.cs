using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
namespace cutecms_porto.Areas.CMS.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class MenuItemsController : BaseController
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
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

        public List<object> GetMenuItemsServerSide(int languageId, int id)
        {
            var menuItems = db.MenuItems.Include("Menu").Where(mi => mi.Menu.TenantId.Trim().Equals(Tenant.TenantId) && mi.LanguageId == languageId && mi.MenuId == id && mi.IsParent).OrderBy(mi => mi.MenuItem1.Ordinal);
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

        public JsonResult GetMenuItemsClientSide(int languageId, int id)
        {
            menuItemsList.Add(new
            {
                Id = -1,
                Name = Resources.Resources.ChooseParentMenuItem
            }
                );

            var menuItems = db.MenuItems.Where(mi => mi.Menu.TenantId.Trim().Equals(Tenant.TenantId) && mi.LanguageId == languageId && mi.MenuId == id && mi.IsParent).OrderBy(mi => mi.MenuItem1.Ordinal);
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

        // GET: CMS/MenuItems
        public ActionResult Index(int? id, int? selectedLanguageId)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            if (id != null)
            {
                ViewBag.MenuId = id;
                ViewBag.LanguageId = selectedLanguageId;
                menuItems = db.MenuItems.Include(mi => mi.Menu).Where(mi => mi.Menu.TenantId.Trim().Equals(Tenant.TenantId) && mi.MenuId == id && (mi.LanguageId == selectedLanguageId.Value || selectedLanguageId.HasValue == false)).OrderBy(mi => mi.LanguageId).ThenBy(mi => mi.Ordinal).ToList();
            }
            ViewBag.selectedLanguageId = new SelectList(db.CMSLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name", selectedLanguageId);
            return View(menuItems);
        }

        // GET: CMS/MenuItems/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            MenuItem menuItem = new MenuItem();
            ViewBag.MenuCode = db.Menus.Find(id).Code;
            menuItem.MenuId = id.Value;
            menuItem.Visible = true;
            menuItem.StatusId = db.CMSStatuses.Where(s => s.Code.Trim().Equals("published")).FirstOrDefault().Id;
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            ViewBag.ParentId = new SelectList(db.MenuItems.Include("Menu").Where(mi => mi.Menu.TenantId.Trim().Equals(Tenant.TenantId) && mi.IsParent == true && mi.MenuId == id), "Id", "Name");
            return View(menuItem);
        }

        // POST: CMS/MenuItems/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Path,MenuId,ParentId,CssClass,Ordinal,IsCms,IsParent,Visible,LanguageId,IsPublished,StatusId")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                menuItem.Name.Trim();
                if (menuItem.IsParent)
                {
                    menuItem.IsLeaf = false;
                    menuItem.IsCms = false;
                    if (string.IsNullOrEmpty(menuItem.Path))
                        menuItem.Path = "#";
                }
                else
                {
                    menuItem.IsLeaf = true;
                    menuItem.IsCms = false;
                }
                if (menuItem.ParentId == -1)
                    menuItem.ParentId = null;
                db.MenuItems.Add(menuItem);
                db.SaveChanges();
                CacheHelper.ClearCache();
                return RedirectToAction("Index", new { id = menuItem.MenuId });
            }
            ViewBag.MenuCode = db.Menus.Find(menuItem.MenuId).Code;
            ViewBag.LanguageId = new SelectList(db.CMSLanguages.Where(l => l.IsEnabled == true).OrderByDescending(l => l.IsDefault).ThenBy(l => l.Ordinal), "Id", "Name");
            ViewBag.ParentId = new SelectList(db.MenuItems.Include("Menu").Where(mi => mi.Menu.TenantId.Trim().Equals(Tenant.TenantId) && mi.IsParent == true && mi.MenuId == menuItem.MenuId), "Id", "Name");
            return View(menuItem);
        }

        // GET: CMS/MenuItems/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var langaugeId = db.MenuItems.Find(id).LanguageId;
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.MenuCode = db.Menus.Find(menuItem.MenuId).Code;
            ViewBag.LanguageName = db.CMSLanguages.Find(menuItem.LanguageId).Name;
            ViewBag.ParentId = new SelectList(GetMenuItemsServerSide(langaugeId, menuItem.MenuId), "Id", "Name", menuItem.ParentId);
            return View(menuItem);
        }

        // POST: CMS/MenuItems/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Path,MenuId,ParentId,CssClass,Ordinal,IsCms,IsParent,Visible,LanguageId,IsPublished,ContentId,StatusId")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                using (var context = new CMSEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        context.Configuration.AutoDetectChangesEnabled = false;
                        try
                        {
                            menuItem.Name.Trim();
                            if (menuItem.IsParent == true)
                            {
                                menuItem.IsLeaf = false;
                                menuItem.IsCms = false;
                                if (string.IsNullOrEmpty(menuItem.Path))
                                    menuItem.Path = "#";
                            }
                            else
                            {
                                menuItem.IsLeaf = true;
                            }
                            db.Entry(menuItem).State = EntityState.Modified;
                            db.SaveChanges();
                            if (menuItem.ContentId != null)
                            {
                                StringHelper.MenuItemsList.Clear();
                                StringHelper.ParentMenuItemPath = string.Empty;
                                var content = db.Contents.Find(menuItem.ContentId);
                                content.Title = menuItem.Name;
                                if (menuItem.ParentId != null)
                                {
                                    StringHelper.MenuItemsList.Clear();
                                    StringHelper.ParentMenuItemPath = string.Empty;
                                    string parentMenuItemPath = StringHelper.GetParentMenuItemPath(menuItem.ParentId, menuItem.LanguageId);
                                    var link = StringHelper.BuildUrlSlug(content.UrlCode, content.LanguageId, content.ContentTypeId, parentMenuItemPath, content.Title.Trim(), true);
                                    content.UrlSlug = link.Item1;
                                    content.AbsolutePath = link.Item2;                   
                                    menuItem.Path = link.Item2;
                                }
                                else
                                {
                                    var link = StringHelper.BuildUrlSlug(content.UrlCode, content.LanguageId, content.ContentTypeId, null, content.Title.Trim(), true);
                                    content.UrlSlug = link.Item1;
                                    content.AbsolutePath = link.Item2;
                                    menuItem.Path = link.Item2;
                                }
                                content.ParentMenuItemId = menuItem.ParentId;
                                db.Entry(content).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (menuItem.IsParent)
                            {
                                UpdatePath(menuItem);
                            }
                            dbContextTransaction.Commit();
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                            ViewBag.MenuCode = db.Menus.Find(menuItem.MenuId).Code;
                            ViewBag.LanguageName = db.CMSLanguages.Find(menuItem.LanguageId).Name;
                            ViewBag.ParentId = new SelectList(GetMenuItemsServerSide(menuItem.LanguageId, menuItem.MenuId), "Id", "Name", menuItem.ParentId);
                            return View(menuItem);
                        }
                        finally
                        {
                            context.Configuration.AutoDetectChangesEnabled = true;
                            CacheHelper.ClearCache();
                        }
                    }
                }
                return RedirectToAction("Index", new { id = menuItem.MenuId });
            }
            ViewBag.MenuCode = db.Menus.Find(menuItem.MenuId).Code;
            ViewBag.LanguageName = db.CMSLanguages.Find(menuItem.LanguageId).Name;
            ViewBag.ParentId = new SelectList(GetMenuItemsServerSide(menuItem.LanguageId, menuItem.MenuId), "Id", "Name", menuItem.ParentId);
            return View(menuItem);
        }

        private void UpdatePath(MenuItem menuItem)
        {
            menuItem = db.MenuItems.Include(m => m.MenuItems1).Where(m => m.Id == menuItem.Id).First();
            var menuItems = TreeHelper.Traversal(menuItem, x => x.MenuItems1);
            foreach (var item in menuItems)
            {
                StringHelper.MenuItemsList.Clear();
                StringHelper.ParentMenuItemPath = string.Empty;
                Content content = new Content();
                content = db.Contents.Find(item.ContentId);
                if (content != null)
                {
                    string parentMenuItemPath = StringHelper.GetParentMenuItemPath(content.ParentMenuItemId, content.LanguageId);
                    var link = StringHelper.BuildUrlSlug(content.UrlCode, content.LanguageId, content.ContentTypeId, parentMenuItemPath, content.Title.Trim(), true);
                    content.UrlSlug = link.Item1;
                    content.AbsolutePath = link.Item2;
                    item.Path = link.Item2;
                    db.Entry(content).State = EntityState.Modified;
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if (item.MenuItems1.Any())
                {
                    foreach (var nestedItem in item.MenuItems1)
                    {
                        UpdatePath(nestedItem);
                    }             
                }
            }
        }

        // GET: CMS/MenuItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                throw new HttpException(404, "Page Not Found");
            }

            return View(menuItem);
        }

        // POST: CMS/MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuItem menuItem = db.MenuItems.Include("Language").Include("Menu").Where(m => m.Menu.TenantId.Trim().Equals(Tenant.TenantId) && m.Id == id).FirstOrDefault();
            db.MenuItems.Remove(menuItem);
            db.SaveChanges();
            CacheHelper.ClearCache();
            return RedirectToAction("Index", new { id = menuItem.MenuId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion Methods
    }
}