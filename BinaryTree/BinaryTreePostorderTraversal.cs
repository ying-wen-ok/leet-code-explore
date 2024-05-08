using System;
using DataStructure;

namespace BinaryTree
{
    public class BinaryTreePostorderTraversal
    {
        public IList<int> PostorderTraversal(TreeNode root)
        {
            return PostorderTraverseRecursively(root);
        }

        private List<int> PostorderTraverseRecursively(TreeNode node)
        {
            List<int> values = new List<int>();
            if(node != null)
            {
                values.AddRange(PostorderTraverseRecursively(node.left));
                values.AddRange(PostorderTraverseRecursively(node.right));
                values.Add(node.val);
            }
            return values;
        }
    }
}
