using cutecms_porto.Areas.CMS.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
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
                var updatedMenuItems = ((List<MenuItem>)System.Web.HttpRuntime.Cache["MenuItems"]).Where(m => m.Menu.Code.Trim().Equals("header"));
                var menuItem = updatedMenuItems.Where(mi => mi.Id == menuItemId).FirstOrDefault();
                if (menuItem.IsLeaf)
                {
                    menuItemsList.Clear();
                    menuItemsList.Add(menuItem);
                }
                if (menuItem.ParentId != null)
                {
                    menuItemsList.Add(updatedMenuItems.Where(mi => mi.Id == menuItem.ParentId).Single());
                    GetParentMenuItems(menuItem.ParentId);
                }
            }
            return menuItemsList;
        }
        #endregion Methods
    }
}