using System;
using DataStructure;

namespace BinarySearchTree
{
    internal class InorderSuccessorInBST
    {
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            successor = null;
            pvalue = p.val;
            InorderTraverseBST(root);
            return successor;
        }

        private TreeNode successor;
        private int pvalue;
        private void InorderTraverseBST(TreeNode node)
        {
            if (successor != null || node == null) return;

            InorderTraverseBST(node.left);
            if (successor != null) return;

            if (node.val > pvalue)
            {
                successor = node;
                return;
            }

            if (successor != null) return;
            InorderTraverseBST(node.right);
        }
    }
}
