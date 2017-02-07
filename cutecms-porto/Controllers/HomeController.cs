using cutecms_porto.Areas.CMS.Models;
using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Areas.Identity.Models;
using cutecms_porto.Helpers;
using cutecms_porto.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace cutecms_porto.Controllers
{
    //[Whitespace]
    //[Compress]
    //[ETag]
    //[OutputCache(Duration = 864000, Location = OutputCacheLocation.Server)]
    public class HomeController : BaseController
    {
        #region Fields
        public static List<SelectTagEditorViewModel> SelectedTags;
        private CMSEntities cmsDb = new CMSEntities();
        private ConfigEntities configDb = new ConfigEntities();
        #endregion Fields
        #region Methods
        public ActionResult Index(HomeViewModel homePage)
        {
            homePage.HomeGallery = cmsDb.ImageFiles.Include("ImageFileTerms").Include("ImageFileTerms.Language").Where(i => i.TenantId.Trim().Equals(Tenant.TenantId) && i.Gallery.HomeVisible && i.Gallery.Code.Trim().Equals("home-gallery")).OrderBy(i => i.Ordinal);
            homePage.Contents = cmsDb.Contents.Include("ContentType").Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && c.Status.Code.Trim().Equals("published") && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).OrderBy(c => c.Ordinal);
            homePage.ContentLists = cmsDb.ContentLists.Include("Content").Include("ListItems").Where(c => c.Content.TenantId.Trim().Equals(Tenant.TenantId) && c.Content.Status.Code.Trim().Equals("published") && c.Content.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && (c.Content.Code.Trim().Equals("home-list"))).OrderBy(li => li.Ordinal);
            return View(homePage);
        }
        public ActionResult Contents(int? page, string keywordFilter = "", int contentTypeIdFilter = 0, int statusIdFilter = 0)
        {
            var pageNumber = page ?? 1;
            keywordFilter.Trim();
            if (string.IsNullOrWhiteSpace(keywordFilter))
                keywordFilter = "";
            ViewBag.ContentTypeIdFilter = new SelectList(TermsHelper.ContentTypes(), "ContentTypeId", "Value", contentTypeIdFilter);
            ViewBag.StatusIdFilter = new SelectList(TermsHelper.Statuses().Where(s => !s.Status.Code.Trim().Equals("scheduled") && !s.Status.Code.Trim().Equals("unpublished")), "StatusId", "Value", statusIdFilter);
            ViewBag.KeywordFilter = keywordFilter;
            ViewBag.ContentTypeId = contentTypeIdFilter;
            ViewBag.StatusId = statusIdFilter;
            var contents = cmsDb.Contents.Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && (c.Title.Contains(keywordFilter.Trim()) || c.MainContent.Contains(keywordFilter.Trim()) || c.ContentLists.Any(cl => cl.MainContent.Contains(keywordFilter.Trim())) || string.IsNullOrEmpty(keywordFilter)) && (c.ContentTypeId == contentTypeIdFilter || contentTypeIdFilter == 0) && (c.StatusId == statusIdFilter || statusIdFilter == 0)).OrderByDescending(c => c.PublishedOn).ThenByDescending(c => c.StartDate);
            return View(contents.ToPagedList(pageNumber, 10));
        }
        public ActionResult Contact()
        {
            var organization = configDb.Organizations.Where(o => o.TenantId.Trim().Equals(Tenant.TenantId) && o.IsDefault == true && o.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault();
            if (organization == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(organization);
        }
        public ActionResult Calendar()
        {
            var upcomingEvents = cmsDb.Contents.Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && c.ContentType.Code.Equals("event") && c.Status.Code.Trim().Equals("published") && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && System.Data.Entity.DbFunctions.TruncateTime(c.StartDate.Value) >= System.Data.Entity.DbFunctions.TruncateTime(DateTime.Now)).OrderBy(c => c.StartDate).Take(5);
            return View(upcomingEvents);
        }
        public ActionResult ListEvents(string start, string end)
        {
            CultureInfo provider = Thread.CurrentThread.CurrentCulture;    // Arabic - United Arab Emirates
            DateTime startDate;
            DateTime endDate;
            if (Helpers.CultureHelper.GetCurrentNeutralCulture().Trim().Equals("ar"))
            {
                start = ReplaceArabicNumerals(start);
                end = ReplaceArabicNumerals(end);
            }
            DateTime.TryParse(start, provider, DateTimeStyles.None, out startDate);
            DateTime.TryParse(end, provider, DateTimeStyles.None, out endDate);
            DateTime StartDate = startDate;
            DateTime EndDate = endDate;
            var eventCalendar = cmsDb.Contents.Where(e => e.TenantId.Trim().Equals(Tenant.TenantId) && e.ContentType.Code.Equals("event") && !e.Status.Code.Equals("unpublished") && e.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).AsEnumerable();
            var events = from e in eventCalendar
                         select new
                         {
                             id = e.Id,
                             title = e.Title,
                             start = e.StartDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ").Replace("T00:00:00Z", string.Empty),
                             end = e.EndDate != null ? e.EndDate.Value.ToString("yyyy-MM-ddTHH:mm:ssZ") : string.Empty,
                             description = e.MainContent,
                             location = e.Location
                         };
            return Json(events, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Galleries(int? page)
        {
            var pageNumber = page ?? 1;
            var galleries = cmsDb.Galleries.Include("GalleryTerms").Include("GalleryTerms.Language").Include("ImageFiles").Include("GalleryCategories").Include("GalleryCategories.Category").Include("GalleryCategories.Category.CategoryTerms").Include("GalleryCategories.Category.CategoryTerms.Language").Where(g => g.TenantId.Trim().Equals(Tenant.TenantId) && !g.Code.Equals("home-gallery") && g.Visible == true && g.ImageFiles.Count != 0).OrderBy(g => g.Ordinal).ToPagedList(pageNumber, 4);
            return View(galleries);
        }
        public ActionResult ImageFiles(int? id, int? page, int tagIdFilter = 0, string returnUrl = null)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            var pageNumber = page ?? 1;// if no page was specified in the querystring, default to the first page (1)
            ViewBag.TagIdFilter = new SelectList(TermsHelper.Tags(id), "TagId", "Value", tagIdFilter);
            ViewBag.TagId = tagIdFilter; 
            var imageFiles = cmsDb.ImageFiles.Where(i => i.TenantId.Trim().Equals(Tenant.TenantId) && i.GalleryId == id && (i.ImageTags.Any(t => t.Tag.Id == tagIdFilter) || tagIdFilter == 0)).OrderBy(i => i.CreatedOn).ToPagedList(pageNumber, 10);
            if (imageFiles == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(imageFiles);
        }
        [OutputCache(Duration = 9000, VaryByCustom = "culture")]
        [ChildActionOnly]
        public PartialViewResult GetHeaderMenu()
        {
            return PartialView("_HeaderMenu");
        }
        [HttpPost]
        public ActionResult Subscribe(SubscriberViewModel subscriber, string returnUrl)
        {
            return Redirect(returnUrl);
        }
        public ActionResult ReturnUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                return Redirect("/" + Thread.CurrentThread.CurrentCulture.Name);
            }
            return Redirect(returnUrl);
        }
        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        public ActionResult ResetPassword(string code)
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel();
            model.Code = code;
            return View(model);
        }

        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        public static string ReplaceArabicNumerals(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                if (c >= 1632 && c <= 1641)
                {
                    output += Char.GetNumericValue(c).ToString();
                }
                else
                {
                    output += c;
                }
            }
            return output;
        }
        #endregion Methods
    }
}