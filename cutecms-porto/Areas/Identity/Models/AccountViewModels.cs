using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cutecms_porto.Areas.Identity.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        #region Properties
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }
        #endregion Properties
    }

    public class ExternalLoginListViewModel
    {
        #region Properties
        public string ReturnUrl { get; set; }
        #endregion Properties
    }

    public class SendCodeViewModel
    {
        #region Properties
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
        #endregion Properties
    }

    public class VerifyCodeViewModel
    {
        #region Properties
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        public string Provider { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "VerificationCode", ResourceType = typeof(Resources.Resources))]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "RememberBrowser", ResourceType = typeof(Resources.Resources))]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
        #endregion Properties
    }

    public class ForgotViewModel
    {
        #region Properties
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }
        #endregion Properties
    }

    public class LoginViewModel
    {
        #region Properties
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "EmailInvalid")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resources.Resources))]
        public bool RememberMe { get; set; }
        #endregion Properties
    }

    public class RegisterViewModel
    {
        #region Properties
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "EmailInvalid")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "StringLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Resources))]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "PasswordMatch")]
        public string ConfirmPassword { get; set; }
        #endregion Properties
    }

    public class ResetPasswordViewModel
    {
        #region Properties
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "EmailInvalid")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Resources))]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "PasswordMatch")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "SecurityCode", ResourceType = typeof(Resources.Resources))]
        public string Code { get; set; }
        #endregion Properties
    }

    public class ForgotPasswordViewModel
    {
        #region Properties
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "EmailInvalid")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        public string Email { get; set; }
        #endregion Properties
    }

    public class UserViewModel
    {
        #region Constructors
        public UserViewModel()
        {
        }

        // Allow Initialization with an instance of ApplicationUser:
        public UserViewModel(ApplicationUser user)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            this.Email = user.Email;
        }
        #endregion Constructors

        #region Properties
        public string Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Username", ResourceType = typeof(Resources.Resources))]
        [Editable(false)]
        public string UserName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "EmailRegularExpression")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "EmailInvalid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        #endregion Properties
    }

    public class SelectRoleEditorViewModel
    {
        #region Constructors
        public SelectRoleEditorViewModel()
        {
        }

        // Update this to accept an argument of type ApplicationRole:
        public SelectRoleEditorViewModel(ApplicationRole role)
        {
            this.RoleName = role.Name;
            this.RoleDescription = role.Description;
        }
        #endregion Constructors

        #region Properties
        public bool Selected { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        public string RoleName { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        public string RoleDescription { get; set; }
        #endregion Properties
    }

    public class RoleViewModel
    {
        #region Constructors
        public RoleViewModel()
        {
        }

        public RoleViewModel(ApplicationRole role)
        {
            this.RoleName = role.Name;
            this.Description = role.Description;
        }
        #endregion Constructors

        #region Properties
        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        public string RoleName { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        public string Description { get; set; }
        #endregion Properties
    }

    public class EditRoleViewModel
    {
        #region Constructors
        public EditRoleViewModel()
        {
        }

        public EditRoleViewModel(ApplicationRole role)
        {
            this.OriginalRoleName = role.Name;
            this.RoleName = role.Name;
            this.Description = role.Description;
        }
        #endregion Constructors

        #region Properties
        public string OriginalRoleName { get; set; }

        public string RoleName { get; set; }

        public string Description { get; set; }
        #endregion Properties
    }

    // Wrapper for SelectGroupEditorViewModel to select user group membership:
    public class SelectUserGroupsViewModel
    {
        #region Fields
        private ApplicationDbContext _db = new ApplicationDbContext();
        #endregion Fields

        #region Constructors
        public SelectUserGroupsViewModel()
        {
            this.Groups = new List<SelectGroupEditorViewModel>();
        }
        public SelectUserGroupsViewModel(ApplicationUser user)
            : this()
        {
            this.UserName = user.UserName;
            // Add all available groups to the public list:
            var allGroups = _db.Groups;
            foreach (var role in allGroups)
            {
                // An EditorViewModel will be used by Editor Template:
                var rvm = new SelectGroupEditorViewModel(role);
                this.Groups.Add(rvm);
            }

            // Set the Selected property to true where user is already a member:
            foreach (var group in user.Groups)
            {
                var checkUserRole = this.Groups.Find(r => r.GroupId == group.Group.Id);
                checkUserRole.Selected = true;
            }
        }
        #endregion Constructors

        #region Properties
        public string UserName { get; set; }
        public List<SelectGroupEditorViewModel> Groups { get; set; }
        #endregion Properties
    }

    // Used to display a single role group with a checkbox, within a list structure:
    public class SelectGroupEditorViewModel
    {
        #region Constructors
        public SelectGroupEditorViewModel()
        {
        }

        public SelectGroupEditorViewModel(Group group)
        {
            this.GroupName = group.Name;
            this.GroupId = group.Id;
        }
        #endregion Constructors

        #region Properties
        public bool Selected { get; set; }

        [Required(ErrorMessageResourceType = typeof(App_GlobalResources.ValidationResources), ErrorMessageResourceName = "PropertyValueRequired")]
        public int GroupId { get; set; }

        public string GroupName { get; set; }
        #endregion Properties
    }

    public class SelectGroupRolesViewModel
    {
        #region Fields
        private ApplicationDbContext _db = new ApplicationDbContext();
        #endregion Fields

        #region Constructors
        public SelectGroupRolesViewModel()
        {
            this.Roles = new List<SelectRoleEditorViewModel>();
        }

        // Enable initialization with an instance of ApplicationUser:
        public SelectGroupRolesViewModel(Group group)
            : this()
        {
            this.GroupId = group.Id;
            this.GroupName = group.Name;
            // Add all available roles to the list of EditorViewModels:
            var allRoles = _db.Roles;
            foreach (var role in allRoles)
            {
                // An EditorViewModel will be used by Editor Template:
                var rvm = new SelectRoleEditorViewModel(role);
                this.Roles.Add(rvm);
            }

            // Set the Selected property to true for those roles for which the current user is a member:
            foreach (var groupRole in group.Roles)
            {
                var checkGroupRole =
                    this.Roles.Find(r => r.RoleName == groupRole.Role.Name);
                checkGroupRole.Selected = true;
            }
        }
        #endregion Constructors

        #region Properties
        public int GroupId { get; set; }

        [Display(Name = "Group Name")]
        public string GroupName { get; set; }

        public List<SelectRoleEditorViewModel> Roles { get; set; }
        #endregion Properties
    }

    public class SelectUserRolesViewModel
    {
        #region Fields
        private ApplicationDbContext _db = new ApplicationDbContext();
        #endregion Fields
        #region Constructors
        public SelectUserRolesViewModel()
        {
            this.Roles = new List<SelectRoleEditorViewModel>();
        }
        // Enable initialization with an instance of ApplicationUser:
        public SelectUserRolesViewModel(ApplicationUser user)
            : this()
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            // Add all available roles to the list of EditorViewModels:
            var allRoles = _db.Roles;
            foreach (var role in allRoles)
            {
                // An EditorViewModel will be used by Editor Template:
                var rvm = new SelectRoleEditorViewModel(role);
                this.Roles.Add(rvm);
            }
            // Set the Selected property to true for those roles for which the current user is a member:

            ApplicationUserManager UserManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roles = UserManager.GetRoles(user.Id);
            foreach (var userRole in roles)
            {
                var checkUserRole = this.Roles.Find(r => r.RoleName == _db.Roles.Where(rn => rn.Name.Equals(userRole)).First().Name);
                checkUserRole.Selected = true;
            }
        }
        #endregion Constructors
        #region Properties
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<SelectRoleEditorViewModel> Roles { get; set; }
        #endregion Properties
    }
}