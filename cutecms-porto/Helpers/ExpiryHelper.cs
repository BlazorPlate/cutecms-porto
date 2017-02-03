using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Areas.RMS.Models.DBModel;
using System;
using System.Data.Entity;
using System.Linq;

namespace cutecms_porto.Helpers
{
    public static class ExpiryHelper
    {
        #region Methods
        public static void ExpiryValidator()
        {
            using (CMSEntities cmsDb = new CMSEntities())
            {
                var contents = cmsDb.Contents.Where(c => c.TenantId.Trim().Equals(Tenant.TenantId) && !c.Status.Code.Trim().Equals("archived") && !c.Status.Code.Equals("unpublished"));
                foreach (var content in contents)
                {
                    if (content.PublishedOn <= DateTime.Now && (DateTime.Now <= content.ExpiredOn || content.ExpiredOn == null))
                    {
                        content.StatusId = cmsDb.CMSStatuses.Where(s => s.Code.Equals("published")).Single().Id;
                    }
                    else if (content.PublishedOn <= DateTime.Now && DateTime.Now >= content.ExpiredOn)
                    {
                        content.StatusId = cmsDb.CMSStatuses.Where(s => s.Code.Equals("archived")).Single().Id;
                        content.PublishedOn = null;
                        content.ExpiredOn = null;
                    }
                    if (content.IsUrgent && DateTime.Now >= content.UrgentExpiredOn)
                    {
                        content.IsUrgent = false;
                    }
                    var menuItem = cmsDb.MenuItems.Include("Menu").Where(m => m.Menu.TenantId.Trim().Equals(Tenant.TenantId) && m.ContentId == content.Id).FirstOrDefault();
                    if (menuItem != null)
                    {
                        menuItem.StatusId = content.StatusId;
                        cmsDb.Entry(menuItem).State = EntityState.Modified;
                    }
                    cmsDb.Entry(content).State = EntityState.Modified;
                }
                cmsDb.SaveChanges();
            }
            using (RMSEntities rmsDb = new RMSEntities())
            {
                var vacancies = rmsDb.Vacancies.Where(c => !c.Status.Code.Trim().Equals("archived"));
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