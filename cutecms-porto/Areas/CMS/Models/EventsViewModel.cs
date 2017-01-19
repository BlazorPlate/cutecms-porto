using cutecms_porto.Areas.CMS.Models.DBModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace cutecms_porto.Areas.CMS.Models
{
    public class EventsViewModel
    {
        #region Properties
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.Resources))]
        public string Title { get; set; }

        [Display(Name = "Location", ResourceType = typeof(Resources.Resources))]
        public string Location { get; set; }

        [Display(Name = "PublishedOn", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> PublishedOn { get; set; }

        [Display(Name = "ExpiredOn", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> ExpiredOn { get; set; }

        [Display(Name = "Author", ResourceType = typeof(Resources.Resources))]
        public string Author { get; set; }

        [Display(Name = "StatusId", ResourceType = typeof(Resources.Resources))]
        public virtual CMSStatus Status { get; set; }

        [Display(Name = "CreatedOn", ResourceType = typeof(Resources.Resources))]
        public System.DateTime CreatedOn { get; set; }

        [Display(Name = "Language", ResourceType = typeof(Resources.Resources))]
        public string Language { get; set; }

        [Display(Name = "Language", ResourceType = typeof(Resources.Resources))]
        public string Culture { get; set; }

        [Display(Name = "IsTranslated", ResourceType = typeof(Resources.Resources))]
        public bool IsTranslated { get; set; }

        [Display(Name = "TranslationId", ResourceType = typeof(Resources.Resources))]
        public Nullable<int> TranslationId { get; set; }
        #endregion Properties
    }
}