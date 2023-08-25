using DataStructure;
using System;
using System.Collections.Generic;

namespace Recursion
{
    public class BinaryTreeLevelOrderTraversal
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            Stack<(TreeNode, int)> s = new Stack<(TreeNode, int)>();
            if (root != null) s.Push((root, 0));

            while (s.Count > 0)
            {
                (TreeNode i, int level) = s.Pop();
                dic.TryAdd(level, new List<int>());
                dic[level].Add(i.val);
                if (i.right != null) s.Push((i.right, level + 1));
                if (i.left != null) s.Push((i.left, level + 1));
            }

            return dic.Values.ToArray();
        }
    }
}
