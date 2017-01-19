using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cutecms_porto.Areas.Identity.Models
{
    public class Group
    {
        #region Constructors
        public Group()
        {
        }

        public Group(string name)
            : this()
        {
            Roles = new List<ApplicationRoleGroup>();
            Name = name;
        }
        #endregion Constructors

        #region Properties
        [Key]
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        public virtual int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        public virtual string Name { get; set; }

        public virtual ICollection<ApplicationRoleGroup> Roles { get; set; }
        #endregion Properties
    }
}