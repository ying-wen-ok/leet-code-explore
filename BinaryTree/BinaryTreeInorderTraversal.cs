using System;
using DataStructure;

namespace BinaryTree
{
    public class BinaryTreeInorderTraversal
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            return InorderTraverseNodesRecursively(root);
        }

        private List<int> InorderTraverseNodesRecursively(TreeNode node)
        {
            List<int> values = new List<int>();
            if (node == null) return values;

            values.AddRange(InorderTraverseNodesRecursively(node.left));
            values.Add(node.val);
            values.AddRange(InorderTraverseNodesRecursively(node.right));
            return values;
        }
    }
}
