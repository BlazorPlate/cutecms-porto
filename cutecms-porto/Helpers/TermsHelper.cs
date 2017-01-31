using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Areas.Config.Models.DBModel;
using cutecms_porto.Areas.Identity.Models.DBModel;
using cutecms_porto.Areas.RMS.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Web;

namespace cutecms_porto.Helpers
{
    public static class TermsHelper
    {
        #region Fields
        private static IdentityEntities IdentityDb = new IdentityEntities();
        private static CMSEntities cmsDb = new CMSEntities();
        private static RMSEntities rmsDb = new RMSEntities();
        private static ConfigEntities configDb = new ConfigEntities();
        #endregion Fields
        #region Methods
        #region CMSDB
        public static IEnumerable<CMSStatusTerm> Statuses()
        {
            var statuses = (from p in cmsDb.CMSStatuses
                            join c in cmsDb.CMSStatusTerms on p.Id equals c.StatusId
                            where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                            orderby p.Ordinal
                            select c);
            return statuses.Include("Status");
        }
        public static IEnumerable<CMSStatusTerm> Statuses(int? id)
        {
            var statuses = (from p in cmsDb.CMSStatuses
                            join c in cmsDb.CMSStatusTerms on p.Id equals c.StatusId
                            where c != null && p.Id == id && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                            orderby p.Ordinal
                            select c);
            return statuses;
        }

        public static IEnumerable<ContentTypeTerm> ContentTypes()
        {
            var contentTypes = (from p in cmsDb.ContentTypes
                                join c in cmsDb.ContentTypeTerms on p.Id equals c.ContentTypeId
                                where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                                orderby p.Ordinal
                                select c);
            return contentTypes;
        }
        public static IEnumerable<CategoryTerm> Categories()
        {
            var categories = (from p in cmsDb.Categories
                              join c in cmsDb.CategoryTerms on p.Id equals c.CategoryId
                              where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                              orderby p.Ordinal
                              select c);
            return categories;
        }
        public static IEnumerable<GalleryTerm> Galleries()
        {
            var galleries = (from p in cmsDb.Galleries
                             join c in cmsDb.GalleryTerms on p.Id equals c.GalleryId
                             where p.TenantId == Tenant.TenantId && c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                             orderby p.Ordinal
                             select c);
            return galleries;
        }
        public static IEnumerable<ImageFileTerm> ImageFiles()
        {
            var imageFiles = (from p in cmsDb.ImageFiles
                              join c in cmsDb.ImageFileTerms on p.Id equals c.ImageFileId
                              where p.TenantId == Tenant.TenantId && c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)
                              orderby p.Ordinal
                              select c);
            return imageFiles;
        }
        public static IEnumerable<TagTerm> Tags()
        {
            var tags = (from p in cmsDb.Tags
                        join c in cmsDb.TagTerms on p.Id equals c.TagId
                        where p.TenantId == Tenant.TenantId && c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                        orderby p.Ordinal
                        select c);
            return tags;
        }
        #endregion
        #region RMSDB
        public static IEnumerable<GenderTerm> Genders()
        {
            var Genders = (from p in rmsDb.Genders
                           join c in rmsDb.GenderTerms on p.Id equals c.GenderId
                           where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                           orderby p.Ordinal
                           select c);
            return Genders;
        }
        public static IEnumerable<JobTypeTerm> JobTypes()
        {
            var jobTypes = (from p in rmsDb.JobTypes
                            join c in rmsDb.JobTypeTerms on p.Id equals c.JobTypeId
                            where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                            orderby p.Ordinal
                            select c);
            return jobTypes;
        }

        #endregion
        #region IdentityDB
        public static IEnumerable<IdentityPersonalTitleTerm> PersonalTitles()
        {
            var personalTitles = (from p in IdentityDb.IdentityPersonalTitles
                                  join c in IdentityDb.IdentityPersonalTitleTerms on p.Id equals c.PersonalTitleId
                                  where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                                  orderby p.Ordinal
                                  select c);
            return personalTitles;
        }
        public static IEnumerable<IdentityDegreeTerm> Degrees()
        {
            var degrees = (from p in IdentityDb.IdentityDegrees
                           join c in IdentityDb.IdentityDegreeTerms on p.Id equals c.DegreeId
                           where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                           orderby p.Ordinal
                           select c);
            return degrees;
        }
        public static List<IdentityDepartmentTerm> DepartmentList(int? languageId)
        {
            IdentityDb = new IdentityEntities();
            List<IdentityDepartmentTerm> departments = null;
            if (languageId == null)
            {
                departments = (from p in IdentityDb.IdentityDepartments
                               join c in IdentityDb.IdentityDepartmentTerms on p.Id equals c.DepartmentId
                               where c != null
                               orderby p.Ordinal
                               select c).ToList();
            }
            else
            {
                departments = (from p in IdentityDb.IdentityDepartments
                               join c in IdentityDb.IdentityDepartmentTerms on p.Id equals c.DepartmentId
                               where c != null && c.LanguageId == languageId
                               orderby p.Ordinal
                               select c).ToList();
            }
            return departments;
        }
        public static IEnumerable<IdentityDepartment> DepartmentList()
        {
            var departments = (from p in IdentityDb.IdentityDepartments
                               join c in IdentityDb.IdentityDepartmentTerms on p.Id equals c.DepartmentId
                               where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)
                               orderby p.Ordinal
                               select p);
            return departments;
        }
        public static IEnumerable<IdentityDepartmentTerm> Departments()
        {
            var departments = (from p in IdentityDb.IdentityDepartments
                               join c in IdentityDb.IdentityDepartmentTerms on p.Id equals c.DepartmentId
                               where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name)
                               orderby p.Ordinal
                               select c).Include("Language");
            return departments;
        }
        public static IEnumerable<IdentityProgramTerm> Programs()
        {
            var programs = (from p in IdentityDb.IdentityPrograms
                            join c in IdentityDb.IdentityProgramTerms on p.Id equals c.ProgramId
                            where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                            orderby p.Ordinal
                            select c);
            return programs;
        }
        public static IEnumerable<IdentityRankTerm> Ranks()
        {
            var ranks = (from p in IdentityDb.IdentityRanks
                         join c in IdentityDb.IdentityRankTerms on p.Id equals c.RankId
                         where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                         orderby p.Ordinal
                         select c);
            return ranks;
        }

        public static IEnumerable<OccupationTerm> Occupations()
        {
            var personalTitles = (from p in IdentityDb.Occupations
                                  join c in IdentityDb.OccupationTerms on p.Id equals c.OccupationId
                                  where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                                  orderby p.Ordinal
                                  select c);
            return personalTitles;
        }

        public static IEnumerable<EmployeeTypeTerm> EmployeeTypes()
        {
            var employeeTypes = (from p in IdentityDb.EmployeeTypes
                                 join c in IdentityDb.EmployeeTypeTerms on p.Id equals c.EmployeeTypeId
                                 where c != null && c.Language.CultureName.Trim().Equals(Thread.CurrentThread.CurrentCulture.Name) && p.Visible
                                 orderby p.Ordinal
                                 select c);
            return employeeTypes;
        }
        #endregion
        #endregion Methods
    }
}