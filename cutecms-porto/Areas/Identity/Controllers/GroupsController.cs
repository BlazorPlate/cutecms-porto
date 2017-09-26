using cutecms_porto.Areas.Identity.Models;
using cutecms_porto.Helpers;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Identity.Controllers
{
    [LocalizedAuthorize(Roles = "Admin,Identity,Groups")]
    public class GroupsController : BaseController
    {
        #region Fields
        private ApplicationDbContext db = new ApplicationDbContext();
        #endregion Fields

        #region Methods
        public ActionResult Index()
        {
            return View(db.Groups.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(group);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new HttpException(400, "Bad Request");
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return View(group);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            var idManager = new IdentityManager();
            idManager.DeleteGroup(id);
            return RedirectToAction("Index");
        }

        public ActionResult GroupRoles(int id)
        {
            var group = db.Groups.Find(id);
            var model = new SelectGroupRolesViewModel(group);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GroupRoles(SelectGroupRolesViewModel model)
        {
            if (ModelState.IsValid)
            {
           
                var idManager = new IdentityManager();
                idManager.ClearGroupRoles(model.GroupId);
                var Db = new ApplicationDbContext();
                var group = Db.Groups.Find(model.GroupId);
                // Add each selected role to this group:
                foreach (var role in model.Roles)
                {
                    if (role.Selected)
                    {
                        idManager.AddRoleToGroup(group.Id, role.RoleName);
                    }
                }
                return RedirectToAction("index");
            }
            return View();
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