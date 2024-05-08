using System;
using DataStructure;


namespace BinaryTree
{
    public class SymmetricTree
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            recursivelyCompare(root.left, root.right);
            return isSymmetric;
        }

        private bool isSymmetric = true;

        private void recursivelyCompare(TreeNode oneSide, TreeNode mirrorSide)
        {
            if (oneSide == null && mirrorSide == null) return;
            else if (oneSide == null && mirrorSide != null) isSymmetric = false;
            else if (oneSide != null && mirrorSide == null) isSymmetric = false;
            else isSymmetric = (oneSide.val == mirrorSide.val);

            if (!isSymmetric) return;            
            recursivelyCompare(oneSide.left, mirrorSide.right);
            
            if (!isSymmetric) return;
            recursivelyCompare(oneSide.right, mirrorSide.left);            
        }

    }
}
