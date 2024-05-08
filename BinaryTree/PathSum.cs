using System;
using DataStructure;


namespace BinaryTree
{
    public class PathSum
    {
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            targetSumValue = targetSum;
            GetSumInTHePath(root, 0);
            return foundAPath;
        }

        private bool foundAPath = false;
        private int targetSumValue;

        private void GetSumInTHePath(TreeNode node, int sumOfAncestorNodes)
        {
            if (node == null || foundAPath) return;
            sumOfAncestorNodes += node.val;
            if (node.left == null && node.right == null)
            {
                if(sumOfAncestorNodes == targetSumValue) foundAPath = true;
                return;
            }

            GetSumInTHePath(node.left, sumOfAncestorNodes);
            GetSumInTHePath(node.right,sumOfAncestorNodes);
        }
    
    }
}
