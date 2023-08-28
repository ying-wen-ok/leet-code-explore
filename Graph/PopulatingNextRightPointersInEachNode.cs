using System;
using System.Collections.Generic;
using DataStructure;

namespace Graph
{
    public class PopulatingNextRightPointersInEachNode
    {
        Node[] lastNodeInThisLevel = new Node[12];

        public Node Connect(Node root)
        {
            connectNodesInSameTreeDepth(0, root);
            return root;
        }

        private void connectNodesInSameTreeDepth(int depth, Node node)
        {
            if (node == null) return;

            if (lastNodeInThisLevel[depth] == null) lastNodeInThisLevel[depth] = node;
            else
            {
                lastNodeInThisLevel[depth].next = node;
                lastNodeInThisLevel[depth] = node;
            }
            connectNodesInSameTreeDepth(depth + 1, node.left);
            connectNodesInSameTreeDepth(depth + 1, node.right);
        }
    }
}
