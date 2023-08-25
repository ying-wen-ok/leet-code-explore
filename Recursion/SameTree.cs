using DataStructure;
using System;
using System.Collections.Generic;

namespace Recursion
{
    public class SameTree
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            Stack<TreeNode> pstack = new Stack<TreeNode>();
            Stack<TreeNode> qstack = new Stack<TreeNode>();

            pstack.Push(p);
            qstack.Push(q);
            while (pstack.Count > 0 && qstack.Count > 0)
            {
                TreeNode i = pstack.Pop();
                TreeNode j = qstack.Pop();

                if (i == null && j == null) continue;
                if (i == null || j == null) return false;
                if (i.val != j.val) return false;

                pstack.Push(i.left);
                pstack.Push(i.right);

                qstack.Push(j.left);
                qstack.Push(j.right);
            }
            return true;
        }
    }
}
