using DataStructure;

namespace Recursion
{
    public class MaximumDepthOfBinaryTree
    {
        public int MaxDepth(TreeNode root)
        {
            return GetNodeDepth(root, 0);
        }

        private int GetNodeDepth(TreeNode node, int d)
        {
            if (node == null) return d;
            return Math.Max(GetNodeDepth(node.left, d + 1), GetNodeDepth(node.right, d + 1));
        }
    }
}
