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

        public static List<MenuItem> GetParentMenuItems(MenuItem node, string culture)
        {
                int i = -1;
                string pathToRoot = string.Empty;
                List<MenuItem> menuItemList = new List<MenuItem>();
                // Walk up the tree until we find the
                // root of the tree, keeping count of
                // how many nodes we walk over in
                // the process
                menuItemList.Add(node);
                while (node != null)
                {
                    i++;
                    node = node.MenuItem1;
                    if (node != null)
                        menuItemList.Add(node);
                }
                return menuItemList;
        }

        public static List<IdentityDepartment> GetParentDepartmentItems(IdentityDepartment node, string culture)
        {
            int i = -1;
            string pathToRoot = string.Empty;
            List<IdentityDepartment> deptList = new List<IdentityDepartment>();
            // Walk up the tree until we find the
            // root of the tree, keeping count of
            // how many nodes we walk over in
            // the process
            deptList.Add(node);
            while (node != null)
            {
                i++;
                node = node.Department1;
                if (node != null)
                    deptList.Add(node);
            }
            return deptList;
        }


        #endregion Methods
    }
}