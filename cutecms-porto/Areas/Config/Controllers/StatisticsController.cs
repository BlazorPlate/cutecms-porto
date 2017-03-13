using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Helpers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Config.Controllers
{
    [LocalizedAuthorize(Roles = "Admin")]
    public class StatisticsController : BaseController
    {
        #region Fields
        private ConfigEntities db = new ConfigEntities();
        #endregion Fields

        #region Methods
        // GET: CMS/Statistics
        public ActionResult Index(int? page, string searchStringFilter)
        {
            if (string.IsNullOrWhiteSpace(searchStringFilter))
                searchStringFilter = null;
            var pageNumber = page ?? 1;// if no page was specified in the querystring, default to the first page (1)
            ViewBag.searchStringFilter = searchStringFilter;
            foreach (var item in db.Statistics)
            {
                if (item.IP.Equals("::1"))
                {
                    db.Statistics.Remove(item);
                }
            }
            db.SaveChanges();
            var statistic = db.Statistics.Where(s => s.CountryCode.Contains(searchStringFilter) || s.CountryName.Contains(searchStringFilter) || s.RegionCode.Contains(searchStringFilter) || s.RegionName.Contains(searchStringFilter) || s.City.Contains(searchStringFilter) || string.IsNullOrEmpty(searchStringFilter)).OrderBy(i => i.RequestDate).ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize
            ViewBag.Counter = db.Statistics.Count();
            return View(statistic);
        }

        // GET: CMS/Statistics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Statistic statistic = db.Statistics.Find(id);
            if (statistic == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(statistic);
        }

        // GET: CMS/Statistics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Statistic statistic = db.Statistics.Find(id);
            if (statistic == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(statistic);
        }

        // POST: CMS/Statistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Statistic statistic = db.Statistics.Find(id);
            db.Statistics.Remove(statistic);
            db.SaveChanges();
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
        #endregion Methods
    }
}