using cutecms_porto.Areas.CMS.Models.DBModel;
using cutecms_porto.Areas.Identity.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cutecms_porto.Helpers
{
    public static class TreeHelper
    {
        public static IEnumerable<T> Traversal<T>(T root, Func<T, IEnumerable<T>> getChildren)
        {
            return new T[] { root }
                .Concat(getChildren(root)
                    .SelectMany(child => Traversal(child, getChildren)));
        }
        public static int MenuItemDepth(MenuItem node)
        {
            int i = -1;
            // Walk up the tree until we find the
            // root of the tree, keeping count of
            // how many nodes we walk over in
            // the process
            while (node != null)
            {
                i++;
                node = node.MenuItem1;
            }

            return i;
        }
        public static string DepartmentDepth(IdentityDepartment node,string culture)
        {
            int i = -1;
            string pathToRoot = string.Empty;
            List<IdentityDepartment> deptList = new List<IdentityDepartment>();
            // Walk up the tree until we find the
            // root of the tree, keeping count of
            // how many nodes we walk over in
            // the process
            deptList.Add(node);
            while (node != null)
            {
                i++;
                node = node.Department1;
                if (node != null)
                    deptList.Add(node);
            }
            deptList.Reverse();
            foreach (var item in deptList)
                pathToRoot += (item.DepartmentTerms.Where(d => d.Language.CultureName.Trim().Equals(culture)).FirstOrDefault()?.Value ?? item.Code) + "/";
            return pathToRoot.Remove(pathToRoot.LastIndexOf('/'));
        }

    }
}