using cutecms_porto.Areas.CMS.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cutecms_porto.Helpers
{
    public static class BreadcrumbsHelper
    {
        #region Fields
        private static CMSEntities db = new CMSEntities();
        private static List<MenuItem> menuItemsList = new List<MenuItem>();
        private static Object thisLock = new Object();
        #endregion Fields

        #region Methods
        public static List<MenuItem> GetParentMenuItems(int? menuItemId)
        {
            lock (thisLock)
            {
                var menuItem = db.MenuItems.Find(menuItemId);
                if (menuItem.IsLeaf)
                {
                    menuItemsList.Clear();
                    menuItemsList.Add(menuItem);
                }
                if (menuItem.ParentId != null)
                {
                    menuItemsList.Add(db.MenuItems.Find(menuItem.ParentId));
                    GetParentMenuItems(menuItem.ParentId);
                }
            }
            return menuItemsList;
        }
        #endregion Methods
    }
}