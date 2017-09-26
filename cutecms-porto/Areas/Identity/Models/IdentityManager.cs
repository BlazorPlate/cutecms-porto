using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace cutecms_porto.Areas.Identity.Models
{
    public class IdentityManager
    {
        #region Fields
        // Swap ApplicationRole for IdentityRole:
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        private readonly RoleManager<ApplicationRole> _roleManager = new RoleManager<ApplicationRole>(
            new RoleStore<ApplicationRole>(new ApplicationDbContext()));

        private readonly UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext()));
        #endregion Fields

        #region Methods
        public bool RoleExists(string name)
        {
            return _roleManager.RoleExists(name);
        }

        public IdentityResult CreateRole(string name, string description = "")
        {
            // Swap ApplicationRole for IdentityRole:
            return _roleManager.Create(new ApplicationRole(name, description));
        }

        public IdentityResult CreateUser(ApplicationUser user, string password)
        {
            return _userManager.Create(user, password);
        }

        public IdentityResult AddUserToRole(string userId, string roleName)
        {
            return _userManager.AddToRole(userId, roleName);
        }

        public void ClearUserRoles(string userId)
        {
            var roles = _userManager.GetRoles(userId);
            foreach (var role in roles)
            {
                _userManager.RemoveFromRole(userId, role);
            }
        }

        public void RemoveFromRole(string userId, string roleName)
        {
            _userManager.RemoveFromRole(userId, roleName);
        }

        public void DeleteRole(string roleId)
        {
            IQueryable<ApplicationUser> roleUsers = _db.Users.Where(u => u.Roles.Any(r => r.RoleId == roleId));
            ApplicationRole role = _db.Roles.Find(roleId);

            foreach (ApplicationUser user in roleUsers)
            {
                RemoveFromRole(user.Id, role.Name);
            }
            _db.Roles.Remove(role);
            _db.SaveChanges();
        }

        public void CreateGroup(string groupName)
        {
            if (GroupNameExists(groupName))
            {
                throw new GroupExistsException(
                    "A group by that name already exists in the database. Please choose another name.");
            }

            var newGroup = new Group(groupName);
            _db.Groups.Add(newGroup);
            _db.SaveChanges();
        }

        public bool GroupNameExists(string groupName)
        {
            return _db.Groups.Any(gr => gr.Name == groupName);
        }

        public void ClearUserGroups(string userId)
        {
            ClearUserRoles(userId);
            ApplicationUser user = _db.Users.Find(userId);
            user.Groups.Clear();
            _db.SaveChanges();
        }

        public void AddUserToGroup(string userId, int groupId)
        {
            Group group = _db.Groups.Find(groupId);
            ApplicationUser user = _db.Users.Find(userId);

            var userGroup = new ApplicationUserGroup
            {
                Group = group,
                GroupId = group.Id,
                User = user,
                UserId = user.Id
            };

            foreach (ApplicationRoleGroup role in group.Roles)
            {
                _userManager.AddToRole(userId, role.Role.Name);
            }
            user.Groups.Add(userGroup);
            _db.SaveChanges();
        }
        public void ClearGroupRoles(int groupId)
        {
            var group = _db.Groups.Find(groupId);
            var rolesToRemove = group.Roles.ToList();
            var groupUsers = _db.Users.Where(u => u.Groups.Any(g => g.GroupId == group.Id)).ToList();
            foreach (var user in groupUsers)
            {
                foreach (var role in group.Roles)
                {
                    this.RemoveFromRole(user.Id, role.Role.Name);
                }
            }
            group.Roles.Clear();
            _db.SaveChanges();
        }

        public void AddRoleToGroup(int groupId, string roleName)
        {
            Group group = _db.Groups.Find(groupId);
            ApplicationRole role = _db.Roles.First(r => r.Name == roleName);

            var newgroupRole = new ApplicationRoleGroup
            {
                GroupId = group.Id,
                Group = group,
                RoleId = role.Id,
                Role = role
            };

            // make sure the groupRole is not already present
            if (!group.Roles.Contains(newgroupRole))
            {
                group.Roles.Add(newgroupRole);
                _db.SaveChanges();
            }

            // Add all of the users in this group to the new role:
            IQueryable<ApplicationUser> groupUsers = _db.Users.Where(u => u.Groups.Any(g => g.GroupId == group.Id));
            foreach (ApplicationUser user in groupUsers)
            {
                if (!(_userManager.IsInRole(user.Id, roleName)))
                {
                    AddUserToRole(user.Id, role.Name);
                }
            }
        }

        public void DeleteGroup(int groupId)
        {
            Group group = _db.Groups.Find(groupId);

            // Clear the roles from the group:
            ClearGroupRoles(groupId);
            _db.Groups.Remove(group);
            _db.SaveChanges();
        }
        #endregion Methods
    }
    [Serializable]
    public class GroupExistsException : Exception
    {
        #region Constructors
        public GroupExistsException()
        {
        }

        public GroupExistsException(string message)
            : base(message)
        {
        }

        public GroupExistsException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected GroupExistsException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
        #endregion Constructors
    }
}