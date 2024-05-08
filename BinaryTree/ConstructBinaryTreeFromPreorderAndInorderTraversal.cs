using System;
using DataStructure;

namespace BinaryTree
{
    public class ConstructBinaryTreeFromPreorderAndInorderTraversal
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return BuildTreeFromPreorderAndInorderTraversal(preorder.ToList(), inorder.ToList());
        }

        private TreeNode BuildTreeFromPreorderAndInorderTraversal(List<int> preorder, List<int> inorder)
        {
            if(preorder == null || inorder == null || preorder.Count == 0 || inorder.Count == 0) return null;

            int rootVal = preorder.First();
            TreeNode root = new TreeNode(rootVal);

            (List<int> inorderLeft, List<int> inorderRight) = identifyLeftRightTreeInorder(rootVal, inorder);
            (List<int> preorderLeft, List<int> preorderRight) = identifyLeftRightTreeInPreorder(preorder, inorderLeft);
              

            root.left = BuildTreeFromPreorderAndInorderTraversal(preorderLeft, inorderLeft);
            root.right = BuildTreeFromPreorderAndInorderTraversal(preorderRight, inorderRight);

            return root;
        }

        private (List<int> left, List<int> right) identifyLeftRightTreeInorder(int rootVal, List<int> inorder)
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            bool reachedRoot = false;
            int n = inorder.Count;
            for(int i = 0; i < n; i++)
            {
                if (inorder[i] == rootVal) { reachedRoot = true; continue; }

                if (reachedRoot) right.Add(inorder[i]); 
                else left.Add(inorder[i]);
            }

            return (left, right);
        }

        private (List<int> left, List<int> right) identifyLeftRightTreeInPreorder(List<int> preorder, List<int> leftNodes)
        {
            HashSet<int> leftNodesSet = leftNodes.ToHashSet();

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int n = preorder.Count;
            for (int i = 1; i < n; i++)
            {
                if (leftNodesSet.Contains(preorder[i])) left.Add(preorder[i]);
                else right.Add(preorder[i]);
            }
            return (left, right);
        }

   
    }
}
