using System;
using DataStructure;

namespace BinarySearchTree
{
    internal class ValidateBinarySearchTree
    {
        public bool IsValidBST(TreeNode root)
        {
            inorderTraverse(root);
            return isBST;
        }

        private bool isBST = true;
        private int? previousValue = null;
        private void inorderTraverse(TreeNode node)
        {
            if (node == null || !isBST) return;

            inorderTraverse(node.left);

            if (previousValue == null)
            {
                previousValue = node.val;
            }
            else if (previousValue >= node.val)
            {
                isBST = false;
                return;
            }

            previousValue = node.val;
            inorderTraverse(node.right);
        }
    }
}
