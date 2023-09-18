using DataStructure;
using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class CloneTheGraph
    {
        public Node CloneGraph(Node node)
        {
            return DeepCopy(node);
        }

        Node[] copy = new Node[101];
        private Node DeepCopy(Node node)
        {
            if (node == null) return null;
            if (copy[node.val] != null) return copy[node.val];

            Node nodeCopy = new Node(node.val);
            copy[node.val] = nodeCopy;

            foreach (Node neighbor in node.neighbors)
            {
                int i = neighbor.val;
                if (copy[i] == null) DeepCopy(neighbor);
                
                nodeCopy.neighbors.Add(copy[i]);
            }
            return nodeCopy;
        }
    }
}
