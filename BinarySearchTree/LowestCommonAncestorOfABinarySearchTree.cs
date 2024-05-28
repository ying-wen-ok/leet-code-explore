using System;
using DataStructure;

namespace BinarySearchTree
{
    internal class LowestCommonAncestorOfABinarySearchTree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == root || q == root) return root;
            TraverseTheTreeAndGetTheDictionary(root, root,false,0);

            int depthOfP = dict[p].depth;
            int depthOfQ= dict[q].depth;

            if(depthOfP < depthOfQ) { q = ClimbUp(depthOfQ - depthOfP, q);  }
            else if (depthOfP > depthOfQ) { p = ClimbUp(depthOfP - depthOfQ, p); }

            while(p != q)
            {
               p = dict[p].father;
               q = dict[q].father;
            }

            return p;
        }

        private Dictionary<TreeNode, (TreeNode father, bool isLeftChild, int depth)> dict = new Dictionary<TreeNode, (TreeNode father, bool isLeftChild, int depth)>();
        private void TraverseTheTreeAndGetTheDictionary(TreeNode i, TreeNode father, bool isLeftChild,  int depth)
        {
            if (i == null) return;
            dict.Add(i, (father, isLeftChild, depth));
            TraverseTheTreeAndGetTheDictionary(i.left,  i, true,depth + 1);
            TraverseTheTreeAndGetTheDictionary(i.right,  i, false,depth + 1);
        }

        private TreeNode ClimbUp(int coutOfSteps, TreeNode i)
        {
            if (coutOfSteps == 0) return i;
            TreeNode father = dict[i].father;
            return ClimbUp(coutOfSteps - 1, father);
        }
    }
}
