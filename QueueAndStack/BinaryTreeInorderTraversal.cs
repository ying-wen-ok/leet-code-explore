using DataStructure;
using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class BinaryTreeInorderTraversal
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            VisitNode(root);
            return data;
        }

        private List<int> data = new List<int>();
        private void VisitNode(TreeNode i)
        {
            if (i == null) return;
            VisitNode(i.left);
            data.Add(i.val);
            VisitNode(i.right);
        }
    }
}
