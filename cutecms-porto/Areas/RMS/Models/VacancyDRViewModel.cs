using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Areas.RMS.Models.DBModel;
using cutecms_porto.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Web;

namespace cutecms_porto.Areas.RMS.Models
{
    public class CreateVacancyWithDRViewModel
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Constructors
        public CreateVacancyWithDRViewModel()
        {
            this.Degrees = new List<SelectDegreeEditorViewModel>();
            // Add all available Degrees to the list of EditorViewModels:
            var allDegrees = db.RMSDegrees;
            foreach (var degree in allDegrees)
            {
                // An EditorViewModel will be used by Editor Template:
                var sdeVM = new SelectDegreeEditorViewModel(degree);
                this.Degrees.Add(sdeVM);
            }
            this.Ranks = new List<SelectRankEditorViewModel>();
            // Add all available Ranks to the list of EditorViewModels:
            var allRanks = db.RMSRanks;
            foreach (var Rank in allRanks)
            {
                // An EditorViewModel will be used by Editor Template:
                var sreVM = new SelectRankEditorViewModel(Rank);
                this.Ranks.Add(sreVM);
            }
        }
        #endregion Constructors

        #region Properties
        [Display(Name = "Id", ResourceType = typeof(Resources.Resources))]
        public int Id { get; set; }

        [Display(Name = "Code", ResourceType = typeof(Resources.Resources))]
        public string Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "JobTitle", ResourceType = typeof(Resources.Resources))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        public string Description { get; set; }

        [Display(Name = "Requirements", ResourceType = typeof(Resources.Resources))]
        public string Requirements { get; set; }

        [Display(Name = "Skills", ResourceType = typeof(Resources.Resources))]
        public string Skills { get; set; }

        [Display(Name = "Documents", ResourceType = typeof(Resources.Resources))]
        public string Documents { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Department", ResourceType = typeof(Resources.Resources))]
        public int DeptId { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "VacancyType", ResourceType = typeof(Resources.Resources))]
        public int JobTypeId { get; set; }

        [Display(Name = "Rank", ResourceType = typeof(Resources.Resources))]
        public Nullable<int> RankId { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Program", ResourceType = typeof(Resources.Resources))]
        public int ProgramId { get; set; }

        [Display(Name = "Available", ResourceType = typeof(Resources.Resources))]
        public int Available { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Degree", ResourceType = typeof(Resources.Resources))]
        public int DegreeId { get; set; }

        [Display(Name = "Notes", ResourceType = typeof(Resources.Resources))]
        public string Notes { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Group", ResourceType = typeof(Resources.Resources))]
        public string RoleVID { get; set; }

        [Display(Name = "Author", ResourceType = typeof(Resources.Resources))]
        public string Author { get; set; }

        [Display(Name = "ModifiedBy", ResourceType = typeof(Resources.Resources))]
        public string ModifiedBy { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "CreatedOn", ResourceType = typeof(Resources.Resources))]
        public System.DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "PublishedOn", ResourceType = typeof(Resources.Resources))]
        public Nullable<System.DateTime> PublishedOn { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "ExpiredOn", ResourceType = typeof(Resources.Resources))]
        public Nullable<System.DateTime> ExpiredOn { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "ModifiedOn", ResourceType = typeof(Resources.Resources))]
        public Nullable<System.DateTime> ModifiedOn { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Language", ResourceType = typeof(Resources.Resources))]
        public int LanguageId { get; set; }

        [Display(Name = "IsTranslated", ResourceType = typeof(Resources.Resources))]
        public bool IsTranslated { get; set; }

        [Display(Name = "TranslationId", ResourceType = typeof(Resources.Resources))]
        public Nullable<int> TranslationId { get; set; }

        [Display(Name = "StatusId", ResourceType = typeof(Resources.Resources))]
        public int StatusId { get; set; }

        [Display(Name = "Degrees", ResourceType = typeof(Resources.Resources))]
        public List<SelectDegreeEditorViewModel> Degrees { get; set; }

        [Display(Name = "Ranks", ResourceType = typeof(Resources.Resources))]
        public List<SelectRankEditorViewModel> Ranks { get; set; }
        #endregion Properties
    }

    public class SelectDegreeEditorViewModel
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Constructors
        public SelectDegreeEditorViewModel()
        {
        }

        // Update this to accept an argument of type Degree:
        public SelectDegreeEditorViewModel(RMSDegree Degree)
        {
            this.DegreeId = Degree.Id;
            string degreeName = (TermsHelper.Degrees().Where(d => d.DegreeId == Degree.Id).FirstOrDefault() == null) ?
                                db.RMSDegrees.Where(d => d.Id == Degree.Id).FirstOrDefault().Code :
                                TermsHelper.Degrees().Where(d => d.DegreeId == Degree.Id).FirstOrDefault().Value;
            this.DegreeName = degreeName;
        }
        #endregion Constructors

        #region Properties
        public bool Selected { get; set; }

        public int DegreeId { get; set; }

        public string DegreeName { get; set; }
        #endregion Properties

        // Add the new Description property:
    }

    public class SelectRankEditorViewModel
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Constructors
        public SelectRankEditorViewModel()
        {
        }

        // Update this to accept an argument of type Rank:
        public SelectRankEditorViewModel(RMSRank Rank)
        {
            this.RankId = Rank.Id;
            string rankName = (TermsHelper.Ranks().Where(d => d.RankId == Rank.Id).FirstOrDefault() == null) ?
                              db.RMSRanks.Where(d => d.Id == Rank.Id).FirstOrDefault().Code :
                              TermsHelper.Ranks().Where(d => d.RankId == Rank.Id).FirstOrDefault().Value;
            this.RankName = rankName;
        }
        #endregion Constructors

        #region Properties
        public bool Selected { get; set; }

        public int RankId { get; set; }

        public string RankName { get; set; }
        #endregion Properties

        // Add the new Description property:
    }

    public class EditVacancyWithDRViewModel
    {
        #region Fields
        private RMSEntities db = new RMSEntities();
        #endregion Fields

        #region Constructors
        public EditVacancyWithDRViewModel()
        {
            this.Degrees = new List<SelectDegreeEditorViewModel>();
            this.Ranks = new List<SelectRankEditorViewModel>();
        }

        // Enable initialization with an instance of ApplicationUser:
        public EditVacancyWithDRViewModel(Vacancy vacancy)
            : this()
        {
            this.Id = vacancy.Id;
            this.Code = vacancy.Code;
            this.Title = vacancy.Title;
            this.Available = vacancy.Available;
            this.Description = vacancy.Description;
            this.Requirements = vacancy.Requirements;
            this.Skills = vacancy.Skills;
            this.Documents = vacancy.Documents;
            this.DeptId = vacancy.DeptId;
            this.JobTypeId = vacancy.JobTypeId;
            this.ProgramId = vacancy.ProgramId;
            this.Notes = vacancy.Notes;
            this.RoleVID = vacancy.RoleVID;
            this.Author = vacancy.Author;
            this.ModifiedBy = vacancy.ModifiedBy;
            this.CreatedOn = vacancy.CreatedOn;
            this.PublishedOn = vacancy.PublishedOn;
            this.ExpiredOn = vacancy.ExpiredOn;
            this.ModifiedOn = vacancy.ModifiedOn;
            this.LanguageId = vacancy.LanguageId;
            this.IsTranslated = vacancy.IsTranslated;
            this.TranslationId = vacancy.TranslationId;
            this.StatusId = vacancy.StatusId;
            // Add all available DRs to the list of EditorViewModels:
            var allDegrees = db.RMSDegrees;
            foreach (var degree in allDegrees)
            {
                // An EditorViewModel will be used by Editor Template:

                var steVM = new SelectDegreeEditorViewModel(degree);
                this.Degrees.Add(steVM);
            }

            // Set the Selected property to true for those DRs for which the current degree is a member:
            foreach (var vacancyDegree in vacancy.VacancyDegrees)
            {
                var checkDegree = this.Degrees.Find(r => r.DegreeId == vacancyDegree.Degree.Id);
                checkDegree.Selected = true;
            }
            var allRanks = db.RMSRanks;
            foreach (var Rank in allRanks)
            {
                // An EditorViewModel will be used by Editor Template:
                var sreVM = new SelectRankEditorViewModel(Rank);
                this.Ranks.Add(sreVM);
            }

            // Set the Selected property to true for those DRs for which the current rank is a member:
            foreach (var vacancyRank in vacancy.VacancyRanks)
            {
                var checkRank = this.Ranks.Find(r => r.RankId == vacancyRank.Rank.Id);
                checkRank.Selected = true;
            }
        }
        #endregion Constructors

        #region Properties
        [Display(Name = "Id", ResourceType = typeof(Resources.Resources))]
        public int Id { get; set; }

        [Display(Name = "Code", ResourceType = typeof(Resources.Resources))]
        public string Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "JobTitle", ResourceType = typeof(Resources.Resources))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        public string Description { get; set; }

        [Display(Name = "Requirements", ResourceType = typeof(Resources.Resources))]
        public string Requirements { get; set; }

        [Display(Name = "Skills", ResourceType = typeof(Resources.Resources))]
        public string Skills { get; set; }

        [Display(Name = "Documents", ResourceType = typeof(Resources.Resources))]
        public string Documents { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "DepartmentId")]
        [Display(Name = "Department", ResourceType = typeof(Resources.Resources))]
        public int DeptId { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "VacancyType", ResourceType = typeof(Resources.Resources))]
        public int JobTypeId { get; set; }

        [Display(Name = "Rank", ResourceType = typeof(Resources.Resources))]
        public Nullable<int> RankId { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Program", ResourceType = typeof(Resources.Resources))]
        public int ProgramId { get; set; }

        [Display(Name = "Available", ResourceType = typeof(Resources.Resources))]
        public int Available { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Degree", ResourceType = typeof(Resources.Resources))]
        public int DegreeId { get; set; }

        [Display(Name = "Notes", ResourceType = typeof(Resources.Resources))]
        public string Notes { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Role", ResourceType = typeof(Resources.Resources))]
        public string RoleVID { get; set; }

        [Display(Name = "Author", ResourceType = typeof(Resources.Resources))]
        public string Author { get; set; }

        [Display(Name = "ModifiedBy", ResourceType = typeof(Resources.Resources))]
        public string ModifiedBy { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "CreatedOn", ResourceType = typeof(Resources.Resources))]
        public System.DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "PublishedOn", ResourceType = typeof(Resources.Resources))]
        public Nullable<System.DateTime> PublishedOn { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "ExpiredOn", ResourceType = typeof(Resources.Resources))]
        public Nullable<System.DateTime> ExpiredOn { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "ModifiedOn", ResourceType = typeof(Resources.Resources))]
        public Nullable<System.DateTime> ModifiedOn { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Language", ResourceType = typeof(Resources.Resources))]
        public int LanguageId { get; set; }

        [Display(Name = "IsTranslated", ResourceType = typeof(Resources.Resources))]
        public bool IsTranslated { get; set; }

        [Display(Name = "TranslationId", ResourceType = typeof(Resources.Resources))]
        public Nullable<int> TranslationId { get; set; }

        [Display(Name = "StatusId", ResourceType = typeof(Resources.Resources))]
        public int StatusId { get; set; }

        [Display(Name = "Degrees", ResourceType = typeof(Resources.Resources))]
        public List<SelectDegreeEditorViewModel> Degrees { get; set; }

        [Display(Name = "Rank", ResourceType = typeof(Resources.Resources))]
        public List<SelectRankEditorViewModel> Ranks { get; set; }

        public virtual DBModel.RMSLanguage Language { get; set; }
        public virtual DBModel.RMSStatus Status { get; set; }
        #endregion Properties
    }
}