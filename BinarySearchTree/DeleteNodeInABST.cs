using System;
using DataStructure;

namespace BinarySearchTree
{
    internal class DeleteNodeInABST
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null || (root.left == null && root.right == null && root.val == key)) return null;
            target = key;
            found = false;
            InorderTraverseAndLookForTargetNode(root, null, false);
            return root;
        }

        private int target;
        private bool found;
        private void InorderTraverseAndLookForTargetNode(TreeNode i, TreeNode father, bool isLeftChild)
        {
            if (found || i == null) return;

            InorderTraverseAndLookForTargetNode(i.left, i, true);
            if (found) return;

            if (i.val == target)
            {
                found = true;
                DeleteTargetNode(i, father, isLeftChild);
            }

            if (found) return;
            InorderTraverseAndLookForTargetNode(i.right, i, false);           
        }

        private void DeleteTargetNode(TreeNode i, TreeNode father, bool isLeftChild)
        {
            if (IsALeafNode(i))
            {
                // father node will not be null, because the case of father == null already been taken case of in the previous part of the solution.
                DeleteTheLeafNode(father, isLeftChild);
            }
            else if (i.left != null)
            {
                SwapTheLargestValueInItsLeftSubtreeAndDeleteTheNodeUsed(i);
            }
            else if (i.right != null)
            {
                SwapTheSmallestValueInItsRightSubtreeAndDeleteTheNodeOfUsed(i);
            }
        }

        private void SwapTheLargestValueInItsLeftSubtreeAndDeleteTheNodeUsed(TreeNode targetNode)
        {          
            TreeNode father = targetNode;
            TreeNode i = targetNode.left;
            bool isLeftChild = true;
            while (i.right != null)
            {
                father = i;
                i = i.right;
                isLeftChild = false;
            }

            targetNode.val = i.val;// swap value
            DeleteTargetNode(i, father, isLeftChild); //delete the node of used
        }

        private void SwapTheSmallestValueInItsRightSubtreeAndDeleteTheNodeOfUsed(TreeNode targetNode)
        {          
            TreeNode father = targetNode;
            TreeNode i = targetNode.right;
            bool isLeftChild = false;

            while (i.left != null)
            {
                father = i;
                i = i.left;
                isLeftChild = true;
            }

            targetNode.val = i.val; // swap value
            DeleteTargetNode(i, father, isLeftChild); //delete the node of used
        }

        private bool IsALeafNode(TreeNode i)
        {
            return i != null && i.left == null && i.right == null;
        }

        private void DeleteTheLeafNode(TreeNode father, bool isLeftChild)
        {
            if (father == null) return;
            if (isLeftChild)
            {
                father.left = null;
            }
            else
            {
                father.right = null;
            }
        }
    
    }
}
