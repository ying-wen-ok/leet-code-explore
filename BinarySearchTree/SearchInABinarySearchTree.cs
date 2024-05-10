using System;
using DataStructure;

namespace BinarySearchTree
{
    internal class SearchInABinarySearchTree
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            return SearchInSBT(root, val);
        }

        private TreeNode SearchInSBT(TreeNode i, int val)
        {
            if (i == null) return null;

            if (i.val == val) return i;
            else if (i.val < val) return SearchInSBT(i.right, val);
            else return SearchInSBT(i.left, val);
        }
    }
}
