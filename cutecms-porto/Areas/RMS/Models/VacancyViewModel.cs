using System;
using System.ComponentModel.DataAnnotations;
namespace cutecms_porto.Areas.RMS.Models
{
    public class VacancyViewModel
    {
        #region Constructors
        public VacancyViewModel()
        {
        }
        #endregion Constructors
        #region Properties
        [Display(Name = "Id", ResourceType = typeof(Resources.Resources))]
        public int Id { get; set; }
        [Display(Name = "Code", ResourceType = typeof(Resources.Resources))]
        public string Code { get; set; }
        [Display(Name = "JobTitle", ResourceType = typeof(Resources.Resources))]
        public string Title { get; set; }
        [Display(Name = "Language", ResourceType = typeof(Resources.Resources))]
        public string Language { get; set; }
        [Display(Name = "LanguageId", ResourceType = typeof(Resources.Resources))]
        public int LanguageId { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Department", ResourceType = typeof(Resources.Resources))]
        public string Department { get; set; }
        [Display(Name = "VacancyType", ResourceType = typeof(Resources.Resources))]
        public string JobType { get; set; }
        [Display(Name = "PublishedOn", ResourceType = typeof(Resources.Resources))]
        public string PublishedOn { get; set; }
        [Display(Name = "ExpiredOn", ResourceType = typeof(Resources.Resources))]
        public string ExpiredOn { get; set; }
        [Display(Name = "TranslationId", ResourceType = typeof(Resources.Resources))]
        public int? TranslationId { get; set; }
        [Display(Name = "IsTranslated", ResourceType = typeof(Resources.Resources))]
        public bool IsTranslated { get; set; }
        [Display(Name = "StatusId", ResourceType = typeof(Resources.Resources))]
        public string Status { get; set; }
        #endregion Properties
    }
}