using DataStructure;
using System;
using System.Collections.Generic;

namespace Recursion
{
    public class SearchInABinarySearchTree
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null) return null;

            if (root.val == val) return root;
            else if (root.val > val) return SearchBST(root.left, val);
            else return SearchBST(root.right, val);
        }
    }
}
