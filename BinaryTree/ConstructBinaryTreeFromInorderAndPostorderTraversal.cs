using System;
using DataStructure;

namespace BinaryTree
{
    public class ConstructBinaryTreeFromInorderAndPostorderTraversal
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return BuildTreeFromInorderAndPostorderTraversal(inorder.ToList(), postorder.ToList());
        }

        private TreeNode BuildTreeFromInorderAndPostorderTraversal(List<int>inorder, List<int> postorder)
        {
            if (inorder == null || postorder == null || inorder.Count == 0 || postorder.Count == 0) return null;

            int rootVal = postorder.Last();
            TreeNode root = new TreeNode(rootVal);

            (List<int> leftInorder, List<int> rightInorder) = breakInorderByRootValue(inorder, rootVal);
            (List<int> leftPostorder, List<int> rightPostorder) = breakPostorderByLeftSet(postorder, leftInorder);

            root.left = BuildTreeFromInorderAndPostorderTraversal(leftInorder, leftPostorder);
            root.right = BuildTreeFromInorderAndPostorderTraversal(rightInorder, rightPostorder);

            return root;
        }

        // inorder: left -> root -> right
        private (List<int> left, List<int> right) breakInorderByRootValue(List<int> inorder, int rootVal)
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            bool reachedRoot = false;
            int n = inorder.Count;
            for(int i = 0; i < n; i++)
            {
                if(inorder[i] == rootVal)
                {
                    reachedRoot = true;
                    continue;
                }

                if (reachedRoot)
                {
                    right.Add(inorder[i]);
                }
                else
                {                   
                    left.Add(inorder[i]);
                }
            }
            return (left, right);
        }

        // postorder: left -> right -> root
        private (List<int> left, List<int> right) breakPostorderByLeftSet(List<int> postorder, List<int> leftInorder)
        {           
            HashSet<int> leftSet = leftInorder.ToHashSet();
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int n = postorder.Count - 1;
            for (int i = 0; i < n; i++)
            {
                int val = postorder[i];
                if (leftSet.Contains(val))
                {
                    left.Add(val);
                }
                else
                {
                    right.Add(val);
                }
            }
            return (left, right);
        }
    }

}
