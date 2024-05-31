using System;
using DataStructure;

namespace BinarySearchTree
{
    internal class ConvertSortedArrayToBinarySearchTree
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            sorted = nums;
            return Constract(0, nums.Length - 1);
        }

        private int[] sorted;
        private TreeNode Constract(int start, int end)
        {
            if (start > end) return null;
            if (start == end) return new TreeNode(sorted[start]);

            int mid = (start + end) / 2;
            TreeNode leftChildNode = Constract(start, mid - 1);
            TreeNode rightChildNode = Constract(mid + 1, end);
            return new TreeNode(sorted[mid], leftChildNode, rightChildNode);
        }
    }
}
