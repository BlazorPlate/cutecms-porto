using cutecms_porto.Areas.CMS.Models.DBModel;
using System.ComponentModel.DataAnnotations;

namespace cutecms_porto.Areas.CMS.Models
{
    public class ContentsViewModel
    {
        #region Properties
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.Resources))]
        public string Title { get; set; }

        [Display(Name = "UrlSlug", ResourceType = typeof(Resources.Resources))]
        public string UrlSlug { get; set; }

        [Display(Name = "AbsolutePath", ResourceType = typeof(Resources.Resources))]
        public string AbsolutePath { get; set; }

        [Display(Name = "ContentType", ResourceType = typeof(Resources.Resources))]
        public string ContentType { get; set; }

        [Display(Name = "Author", ResourceType = typeof(Resources.Resources))]
        public string Author { get; set; }

        [Display(Name = "IsPublished", ResourceType = typeof(Resources.Resources))]
        public bool IsPublished { get; set; }

        [Display(Name = "IsScheduled", ResourceType = typeof(Resources.Resources))]
        public bool IsScheduled { get; set; }

        [Display(Name = "CreatedOn", ResourceType = typeof(Resources.Resources))]
        public System.DateTime CreatedOn { get; set; }

        [Display(Name = "Language", ResourceType = typeof(Resources.Resources))]
        public string Language { get; set; }

        [Display(Name = "IsTranslated", ResourceType = typeof(Resources.Resources))]
        public bool IsTranslated { get; set; }

        [Display(Name = "TranslationId", ResourceType = typeof(Resources.Resources))]
        public int? TranslationId { get; set; }

        public string Status { get; set; }
        #endregion Properties
    }
}