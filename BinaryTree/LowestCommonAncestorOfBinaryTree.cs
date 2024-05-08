using System;
using DataStructure;

namespace BinaryTree
{
    public class LowestCommonAncestorOfBinaryTree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode fakeHead = new TreeNode();
            TraverseTheTreeAndNoteFatherOfNodes(fakeHead, root, 0);

            (TreeNode fatherOfP, int depthOfP) = nodeDict[p];
            (TreeNode fatherOfQ, int depthOfQ) = nodeDict[q];

            int startOfDepth = Math.Min(depthOfP, depthOfQ);
            p = ClimbUpToNodeAtLevelX(p, startOfDepth);
            q = ClimbUpToNodeAtLevelX(q, startOfDepth);

            while (startOfDepth >= 0 && p != q)
            {
                p = nodeDict[p].father;
                q = nodeDict[q].father;
                startOfDepth--;
            }
            return p;
        }

        private Dictionary<TreeNode, (TreeNode father, int depth)> nodeDict = new Dictionary<TreeNode, (TreeNode father, int depth)>();
        private void TraverseTheTreeAndNoteFatherOfNodes(TreeNode iFather, TreeNode i, int depth)
        {
            if (i == null) return;
            nodeDict.Add(i, (iFather, depth));
            TraverseTheTreeAndNoteFatherOfNodes(i, i.left, depth + 1);
            TraverseTheTreeAndNoteFatherOfNodes(i, i.right, depth + 1);
        }

        private TreeNode ClimbUpToNodeAtLevelX(TreeNode i, int levelX)
        {
            (TreeNode father, int depth) = nodeDict[i];
            if (depth == levelX) return i;
            return ClimbUpToNodeAtLevelX(father, levelX);
        }
    }
}
