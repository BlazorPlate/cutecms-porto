using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Helpers;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Web;

namespace cutecms_porto.Areas.CMS.Models
{
    public class CreateImageWithTagsViewModel
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Constructors
        public CreateImageWithTagsViewModel()
        {
            this.Tags = new List<SelectTagEditorViewModel>();
            // Add all available Tags to the list of EditorViewModels:
            var allTags = db.Tags.Where(t => t.TenantId.Trim().Equals(Tenant.TenantId));
            foreach (var tag in allTags)
            {
                // An EditorViewModel will be used by Editor Template:
                var steVM = new SelectTagEditorViewModel(tag);
                this.Tags.Add(steVM);
            }
        }
        #endregion Constructors

        #region Properties
        public ImageFile ImageFile { get; set; }
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Gallery", ResourceType = typeof(Resources.Resources))]
        public short GalleryId { get; set; }
        public string[] AvailableTags { get; set; }
        [Display(Name = "Tags", ResourceType = typeof(Resources.Resources))]
        public List<SelectTagEditorViewModel> Tags { get; set; }
        [Display(Name = "ImageFiles", ResourceType = typeof(Resources.Resources))]
        public IEnumerable<HttpPostedFileBase> ImageFiles { get; set; }
        #endregion Properties
    }

    public class SelectTagEditorViewModel
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Constructors
        public SelectTagEditorViewModel()
        {
        }

        // Update this to accept an argument of type Tag:
        public SelectTagEditorViewModel(Tag tag)
        {
            this.TagId = tag.Id;
            string tagName = (TermsHelper.Tags().Where(d => d.TagId == tag.Id).FirstOrDefault() == null) ?
                              db.Tags.Where(d => d.Id == tag.Id).FirstOrDefault().Code :
                              TermsHelper.Tags().Where(d => d.TagId == tag.Id).FirstOrDefault().Value;
            this.TagName = tagName;
        }
        #endregion Constructors

        #region Properties
        public bool Selected { get; set; }

        public int TagId { get; set; }

        public string TagName { get; set; }
        #endregion Properties

        // Add the new Description property:
    }

    public class EditImageWithTagsViewModel
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Constructors
        public EditImageWithTagsViewModel()
        {
            this.Tags = new List<SelectTagEditorViewModel>();
        }

        // Enable initialization with an instance of ApplicationUser:
        public EditImageWithTagsViewModel(ImageFile imageFile)
            : this()
        {
            this.ImageFile = imageFile;
            // Add all available Tags to the list of EditorViewModels:
            var allTags = db.Tags.Where(t => t.TenantId.Trim().Equals(Tenant.TenantId));
            foreach (var tag in allTags)
            {
                // An EditorViewModel will be used by Editor Template:
                var steVM = new SelectTagEditorViewModel(tag);
                this.Tags.Add(steVM);
            }

            // Set the Selected property to true for those Tags for which the current imageFile is a member:
            foreach (var imageTag in imageFile.ImageTags)
            {
                var checkImagetag = this.Tags.Find(r => r.TagId == imageTag.Tag.Id);
                checkImagetag.Selected = true;
            }
        }
        #endregion Constructors

        #region Properties
        [Display(Name = "Tags", ResourceType = typeof(Resources.Resources))]
        public List<SelectTagEditorViewModel> Tags { get; set; }
        public ImageFile ImageFile { get; set; }
        [Display(Name = "ImageFiles", ResourceType = typeof(Resources.Resources))]
        public IEnumerable<HttpPostedFileBase> ImageFiles { get; set; }
        #endregion Properties
    }

    public class GetImageByTagsViewModel
    {
        #region Fields
        private CMSEntities db = new CMSEntities();
        #endregion Fields

        #region Constructors
        public GetImageByTagsViewModel()
        {
            this.AvailableTags = new List<SelectTagEditorViewModel>();

            // Add all available Tags to the list of EditorViewModels:
            var allTags = db.Tags.Where(t => t.TenantId.Trim().Equals(Tenant.TenantId));
            foreach (var tag in allTags)
            {
                // An EditorViewModel will be used by Editor Template:
                var steVM = new SelectTagEditorViewModel(tag);
                this.AvailableTags.Add(steVM);
            }
        }
        #endregion Constructors

        #region Properties
        public IPagedList<ImageFile> Images { get; set; }
        public List<SelectTagEditorViewModel> AvailableTags { get; set; }
        #endregion Properties
    }
}