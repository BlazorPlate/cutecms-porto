using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Areas.RMS.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;

namespace cutecms_porto.Helpers
{
    public static class ExpiryHelper
    {
        #region Methods
        public static void ExpiryValidator()
        {
            using (CMSEntities cmdDb = new CMSEntities())
            {
                var contents = cmdDb.Contents.Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && !c.Status.Code.Trim().Equals("archived") && !c.Status.Code.Equals("unpublished")).ToList();
                foreach (var content in contents)
                {
                    if (content.PublishedOn <= DateTime.Now && (DateTime.Now <= content.ExpiredOn || content.ExpiredOn == null))
                    {
                        content.StatusId = cmdDb.CMSStatuses.Where(s => s.Code.Equals("published")).Single().Id;
                    }
                    else if (content.PublishedOn <= DateTime.Now && DateTime.Now >= content.ExpiredOn)
                    {
                        content.StatusId = cmdDb.CMSStatuses.Where(s => s.Code.Equals("archived")).Single().Id;
                        content.PublishedOn = null;
                        content.ExpiredOn = null;
                    }
                    if (content.IsUrgent && DateTime.Now >= content.UrgentExpiredOn)
                    {
                        content.IsUrgent = false;
                    }
                    var menuItem = cmdDb.MenuItems.Include("Menu").Where(m => m.Menu.TenantId.Trim().Equals(Tenant.TenantId) && m.ContentId == content.Id).FirstOrDefault();
                    if (menuItem != null)
                    {
                        menuItem.StatusId = content.StatusId;
                        cmdDb.Entry(menuItem).State = EntityState.Modified;
                    }
                    cmdDb.Entry(content).State = EntityState.Modified;
                }
                cmdDb.SaveChanges();
            }
            using (RMSEntities rmsDb = new RMSEntities())
            {
                var vacancies = rmsDb.Vacancies.Where(c => !c.Status.Code.Trim().Equals("archived")).ToList();
                foreach (var vacancy in vacancies)
                {
                    if (vacancy.PublishedOn <= DateTime.Now && (DateTime.Now <= vacancy.ExpiredOn || vacancy.ExpiredOn == null))
                    {
                        vacancy.StatusId = rmsDb.Statuses.Where(s => s.Code.Trim().Equals("published")).Single().Id;
                    }
                    else if (vacancy.PublishedOn <= DateTime.Now && DateTime.Now >= vacancy.ExpiredOn)
                    {
                        vacancy.StatusId = rmsDb.Statuses.Where(s => s.Code.Trim().Equals("archived")).Single().Id;
                        vacancy.PublishedOn = null;
                        vacancy.ExpiredOn = null;
                    }
                }
                rmsDb.SaveChanges();
            }
        }
        #endregion Methods
    }
}