using System;
using DataStructure;

namespace BinarySearchTree
{
    internal class BalancedBinaryTree
    {
        public bool IsBalanced(TreeNode root)
        {
            MarkNodeHeight(root);
            checkHightBanlanced(root);
            return balanced;
        }
        private bool balanced = true;
        private Dictionary<TreeNode, int> dict = new Dictionary<TreeNode, int>();
        private int MarkNodeHeight(TreeNode i)
        {
            if (i == null) return 0;
            int height = 1 + Math.Max(MarkNodeHeight(i.left), MarkNodeHeight(i.right));
            dict.Add(i, height);
            return height;
        }

        private void checkHightBanlanced(TreeNode i)
        {
            if (i == null || !balanced) return;

            int leftHeight = i.left == null ? 0 : dict[i.left];
            int rightHeight = i.right == null ? 0 : dict[i.right];

            if ( Math.Abs(leftHeight - rightHeight) > 1)
            {
                balanced = false;
            }

            if (!balanced) return;
            checkHightBanlanced(i.left);
            if (!balanced) return;
            checkHightBanlanced(i.right);
        }
    }
}
