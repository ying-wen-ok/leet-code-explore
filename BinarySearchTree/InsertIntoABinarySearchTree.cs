using System;
using DataStructure;

namespace BinarySearchTree
{
    internal class InsertIntoABinarySearchTree
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);
            target = val;
            InorderTraverse(root);
            if (!found) InsertTheNodeAsBiggestNodeInTheSubTree(root);
            return root;
        }

        private int target;
        private bool found = false;
        private void InorderTraverse(TreeNode i)
        {
            if (i == null || found) return;

            InorderTraverse(i.left);
            if (found) return;

            if (i.val > target)
            {
                InsertTheNodeAsLeftChild(i);
                found = true;
                return;
            }
            InorderTraverse(i.right);
        }


        // new code will be the biggest in the left tree
        private void InsertTheNodeAsLeftChild(TreeNode parent)
        {
            if (parent.left == null) parent.left = new TreeNode(target);
            else InsertTheNodeAsBiggestNodeInTheSubTree(parent.left);
        }

        private void InsertTheNodeAsBiggestNodeInTheSubTree(TreeNode root)
        {
            TreeNode biggestInTheSubTree = root;
            while (biggestInTheSubTree.right != null) biggestInTheSubTree = biggestInTheSubTree.right;
            biggestInTheSubTree.right = new TreeNode(target);
        }
    }
}
