using System;
using DataStructure;

namespace BinaryTree
{
    public class BinaryTreePreorderTraversal
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            return PreorderTraverse(root);
        }

        private List<int> PreorderTraverse(TreeNode node)
        {
            if (node == null) return new List<int>();

            List<int> values = new List<int>();

            values.Add(node.val);
            values.AddRange(PreorderTraverse(node.left));
            values.AddRange(PreorderTraverse(node.right));

            return values;
        }
    }
}
