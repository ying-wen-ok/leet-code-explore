using System;
using DataStructure;

namespace BinaryTree
{
    public class BinaryTreeLevelOrderTraversal
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            int maxDepthOfTree = 2000;
            resultByDepth = new List<int>[maxDepthOfTree];
            for (int i = 0; i < maxDepthOfTree; i++) resultByDepth[i] = new List<int>();
            TraverseNodeByDepthRecusively(root, 0);
            return removeNullList();
        }

        private List<int>[] resultByDepth;
        private void TraverseNodeByDepthRecusively(TreeNode node, int depth)
        {
            if (node == null) return;
            resultByDepth[depth].Add(node.val);
            TraverseNodeByDepthRecusively(node.left, depth + 1);
            TraverseNodeByDepthRecusively(node.right, depth + 1);
        }


        private List<IList<int>> removeNullList()
        {
            List<IList<int>> result = new List<IList<int>>();
            foreach(List<int> l in resultByDepth)
            {
                if (l.Count == 0) break;
                result.Add(l);
            }

            return result;
        }
    }
}
