using System;
using System.Collections.Generic;
using DataStructure;

namespace Graph
{
    public class NaryTreeLevelOrderTraversal
    {
        public IList<IList<int>> LevelOrder(Node root)
        {
            List<List<int>> result = new List<List<int>>();
            Queue<(Node node, int depth)> Q = new Queue<(Node node, int depth)>();
            Q.Enqueue((root, 0));
            while (Q.Count > 0)
            {
                (Node node, int depth) = Q.Dequeue();

                if (node == null) continue;
                while (result.Count <= depth)
                {
                    result.Add(new List<int>());
                }

                result[depth].Add(node.val);
                foreach (Node i in node.children)
                {
                    Q.Enqueue((i, depth + 1));
                }
            }
            return result.ToArray();
        }
    }
    
}
