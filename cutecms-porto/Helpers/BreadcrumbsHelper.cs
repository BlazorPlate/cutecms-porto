using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Areas.Identity.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cutecms_porto.Helpers
{
    public static class BreadcrumbsHelper
    {
        #region Fields
        private static CMSEntities cmsDb = new CMSEntities();
        private static IdentityEntities identityDb = new IdentityEntities();
        private static List<MenuItem> menuItemsList = new List<MenuItem>();
        private static List<IdentityDepartment> deptsList = new List<IdentityDepartment>();
        private static Object thisLock = new Object();
        #endregion Fields

        #region Methods
        public static List<MenuItem> GetParentMenuItems(int? menuItemId)
        {
            lock (thisLock)
            {
                if (menuItemId != null)
                {
                    var menuItem = cmsDb.MenuItems.Find(menuItemId);
                    if (menuItem.IsLeaf)
                    {
                        menuItemsList.Clear();
                        menuItemsList.Add(menuItem);
                    }
                    if (menuItem.ParentId != null)
                    {
                        menuItemsList.Add(cmsDb.MenuItems.Find(menuItem.ParentId));
                        GetParentMenuItems(menuItem.ParentId);
                    }
                }
            }
            return menuItemsList;
        }

        public static List<IdentityDepartment> GetParentDepts(int? deptId)
        {
            lock (thisLock)
            {
                if (deptId != null)
                {
                    var dept = identityDb.IdentityDepartments.Find(deptId);
                    if (dept.Departments1.Count==0)
                    {
                        deptsList.Clear();
                        deptsList.Add(dept);
                    }
                    if (dept.ParentId != null)
                    {
                        deptsList.Add(identityDb.IdentityDepartments.Find(dept.ParentId));
                        GetParentDepts(dept.ParentId);
                    }
                }
            }
            return deptsList;
        }

        #endregion Methods
    }
}