using System;
using System.Collections.Generic;

namespace Graph
{
    internal class CloneGraphNodes
    {
        public NodeWithNeighbors CloneGraph(NodeWithNeighbors node)
        {
            if (node == null) return null;

            NodeWithNeighbors[] newNodes = new NodeWithNeighbors[101];
            for (int i = 0; i < 101; i++) newNodes[i] = new NodeWithNeighbors(i);
            bool[] visited = new bool[101];
            Stack<NodeWithNeighbors> S = new Stack<NodeWithNeighbors>();

            S.Push(node);

            while (S.Count > 0)
            {
                NodeWithNeighbors nodeI = S.Pop();
                int i = nodeI.val;
                if (visited[i]) continue;
                visited[i] = true;

                foreach (NodeWithNeighbors nodeJ in nodeI.neighbors)
                {
                    S.Push(nodeJ);
                    newNodes[i].neighbors.Add(newNodes[nodeJ.val]);
                }
            }
            return newNodes[node.val];
        }
    }

    internal class NodeWithNeighbors
    {
        public int val;
        public IList<NodeWithNeighbors> neighbors;

        public NodeWithNeighbors()
        {
            val = 0;
            neighbors = new List<NodeWithNeighbors>();
        }

        public NodeWithNeighbors(int _val)
        {
            val = _val;
            neighbors = new List<NodeWithNeighbors>();
        }

        public NodeWithNeighbors(int _val, List<NodeWithNeighbors> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
