using DataStructure;
using System;
using System.Collections.Generic;

namespace Recursion
{
    public class ValidateBinarySearchTree
    {
        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;
            DivideAndConqueSubtree(root);
            return !isNotValid;
        }

        bool isNotValid = false;
        private (int max, int min)? DivideAndConqueSubtree(TreeNode i)
        {
            if (i == null) return null;

            var left = DivideAndConqueSubtree(i.left);
            if (isNotValid) return null;

            var right = DivideAndConqueSubtree(i.right);
            if (isNotValid) return null;

            isNotValid = (left.HasValue && i.val <= left.Value.max)
                || (right.HasValue && i.val >= right.Value.min);
            if (isNotValid) return null;

            int max = right.HasValue ? right.Value.max : i.val;
            int min = left.HasValue ? left.Value.min : i.val;

            return (max, min);
        }
    }  
}
