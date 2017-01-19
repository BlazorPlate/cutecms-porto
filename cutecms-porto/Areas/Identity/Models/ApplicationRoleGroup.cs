namespace cutecms_porto.Areas.Identity.Models
{
    public class ApplicationRoleGroup
    {
        #region Properties
        public virtual string RoleId { get; set; }

        public virtual int GroupId { get; set; }

        public virtual ApplicationRole Role { get; set; }

        public virtual Group Group { get; set; }
        #endregion Properties
    }
}