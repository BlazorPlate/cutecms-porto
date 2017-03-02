using cutecms_porto.Areas.CMS.Models.DBModel;
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
        public static int Depth(MenuItem node)
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

    }
}