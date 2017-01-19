using System.ComponentModel.DataAnnotations;

namespace cutecms_porto.Areas.RMS.Models
{
    public class SubmissionViewModel
    {
        #region Properties
        [Display(Name = "SubmissionId", ResourceType = typeof(Resources.Resources))]
        public string Id { get; set; }
        [Display(Name = "Applicant", ResourceType = typeof(Resources.Resources))]
        public string ApplicantFullName { get; set; }
        [Display(Name = "SubmittedOn", ResourceType = typeof(Resources.Resources))]
        public string SubmissionDate { get; set; }
        [Display(Name = "Vacancy", ResourceType = typeof(Resources.Resources))]
        public string VacancyTitle { get; set; }
        [Display(Name = "Department", ResourceType = typeof(Resources.Resources))]
        public string Department { get; set; }
        [Display(Name = "ResumeFileName", ResourceType = typeof(Resources.Resources))]
        public string ResumeFileName { get; set; }
        [Display(Name = "ResumeFilePath", ResourceType = typeof(Resources.Resources))]
        public string ResumeFilePath { get; set; }
        #endregion Properties
    }
}