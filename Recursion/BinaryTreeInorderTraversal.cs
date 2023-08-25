using DataStructure;
using System;
using System.Collections.Generic;

namespace Recursion
{
    public class BinaryTreeInorderTraversal
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            Stack<TreeNode> S = new Stack<TreeNode>();
            S.Push(root);
            List<int> value = new List<int>();
            while (S.Count > 0)
            {
                TreeNode i = S.Pop();
                if (i == null) continue;

                TreeNode left = i.left;
                TreeNode right = i.right;

                i.left = null;
                i.right = null;

                if (left == null && right == null)
                {
                    value.Add(i.val);
                }
                else if (left != null && right == null)
                {
                    S.Push(i);
                    S.Push(left);
                }
                else if (left == null && right != null)
                {
                    value.Add(i.val);
                    S.Push(right);
                }
                else if (left != null && right != null)
                {
                    S.Push(right);
                    S.Push(i);
                    S.Push(left);
                }
            }
            return value;
        }
    }
}
