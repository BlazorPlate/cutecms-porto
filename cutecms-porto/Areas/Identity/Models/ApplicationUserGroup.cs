using System.ComponentModel.DataAnnotations;

namespace cutecms_porto.Areas.Identity.Models
{
    public class ApplicationUserGroup
    {
        #region Properties
        [Required]
        public virtual string UserId { get; set; }

        [Required]
        public virtual int GroupId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Group Group { get; set; }
        #endregion Properties
    }
}