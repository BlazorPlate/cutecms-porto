using Microsoft.AspNet.Identity.EntityFramework;

namespace cutecms_porto.Areas.Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        #region Constructors
        public ApplicationRole()
            : base()
        {
        }

        public ApplicationRole(string name, string description)
            : base(name)
        {
            this.Description = description;
        }
        #endregion Constructors

        #region Properties
        public virtual string Description { get; set; }
        #endregion Properties
    }
}