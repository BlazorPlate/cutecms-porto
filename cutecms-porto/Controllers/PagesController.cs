using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace cutecms_porto.Controllers
{
    public class PagesController : BaseController
    {
        #region Fields
        public static bool flag = true;
        private CMSEntities db = new CMSEntities();
        #endregion Fields
        // GET: Pages
        #region Methods
        //[Whitespace]
        //[Compress]
        //[ETag]
        //[OutputCache(Duration = 864000, Location = OutputCacheLocation.Server)]
        public new ActionResult Content(string slug)
        {
            Content translatedContent = new Content();
            if (slug == null)
                throw new HttpException(404, "Page Not Found");
            var contentTranslationId = db.Contents.FirstOrDefault(c => c.TenantId.Trim().Equals(Tenant.TenantId) && c.UrlSlug.Trim().Equals(slug))?.TranslationId;
            if (contentTranslationId == null)
                throw new HttpException(404, "Page Not Found");
            translatedContent = db.Contents.Include("Status").Include("ContentType").Include("ContentLists").Include("ContentLists.ListItems").Include("ContentGalleries").Include("ContentGalleries.Gallery").Include("ContentGalleries.Gallery.GalleryTerms").Include("ContentGalleries.Gallery.GalleryTerms.Language").Include("ContentGalleries.Gallery.ImageFiles").Include("ContentGalleries.Gallery.ImageFiles.ImageFileTerms").Include("ContentGalleries.Gallery.ImageFiles.ImageFileTerms.Language").Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && c.TranslationId == contentTranslationId && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)).FirstOrDefault();
            if (translatedContent == null)
                throw new HttpException(602, "Page Not Translated");
            if (translatedContent.Status.Code.Equals("unpublished"))
                throw new HttpException(601, "Page Not Published");
            if (flag == true && !slug.Trim().Equals(translatedContent.UrlSlug.Trim()))
            {
                flag = false;
                return RedirectToAction("Content", new { slug = translatedContent.UrlSlug });
            }
            flag = true;
            return View(translatedContent);
        }
        #endregion Methods
    }
}