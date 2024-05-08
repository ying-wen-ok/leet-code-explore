using System;
using DataStructure;

namespace BinaryTree
{
    public class PopulatingNextRightPointersInEachNodeII
    {
        public Node Connect(Node root)
        {
            lastNodeAtThisLevel = new Node[maxDepthIndex + 1];
            for (int i = 0; i <= maxDepthIndex; i++) lastNodeAtThisLevel[i] = null;
            connectRecusively(root, 0);
            return root;
        }

        /// assuming root at depth index 0, 
        /// total number of nodes in the tree is in the range [0, 6000].
        /// int the max tree height case, the leaves can be depth of 6000;    
        private int maxDepthIndex = 6000;
        private Node[] lastNodeAtThisLevel;

        private void connectRecusively(Node node, int depth)
        {
            if (node == null) return;

            connectRecusively(node.left, depth + 1);

            if (lastNodeAtThisLevel[depth] == null) { lastNodeAtThisLevel[depth] = node; }
            else
            {
                lastNodeAtThisLevel[depth].next = node;
                lastNodeAtThisLevel[depth] = node;
            }

            connectRecusively(node.right, depth + 1);
        }
    }
}
