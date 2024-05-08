using System;
using DataStructure;


namespace BinaryTree
{
    public class MaximumDepthOfBinaryTree
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return (Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1);
        }
    }
}
