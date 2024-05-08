using System;
using DataStructure;


namespace BinaryTree
{
    public class CountUnivalueSubtreesSolution
    {
        public int CountUnivalSubtrees(TreeNode root)
        {
            if (root == null) return 0;
            rootsOfUnivalSubtrees = new HashSet<TreeNode>();
            fatherDict = new Dictionary<TreeNode, (TreeNode fahter, bool isALeftChild)>();
            fatherDict.Add(root, (null, false));
            GetAllLeavesNodes(root);

            List<TreeNode> leaves = rootsOfUnivalSubtrees.ToList();
            foreach (TreeNode i in leaves) CountUnivalSubtreesFromTheLeaveNode(i);
           
            return rootsOfUnivalSubtrees.Count;
        }

        private HashSet<TreeNode> rootsOfUnivalSubtrees;
        private Dictionary<TreeNode, (TreeNode fahter, bool isALeftChild)> fatherDict; 

        private void GetAllLeavesNodes(TreeNode node)
        {
            if (node == null) return;
            if (node.left == null && node.right == null) rootsOfUnivalSubtrees.Add(node);            

            if(node.left != null)
            {
                fatherDict.Add(node.left, (node, true));
                GetAllLeavesNodes(node.left);
            }

            if (node.right != null)
            {
                fatherDict.Add(node.right, (node, false));
                GetAllLeavesNodes(node.right);
            }
        }

        private void CountUnivalSubtreesFromTheLeaveNode(TreeNode node)
        {
            if (node == null) return;

            (TreeNode father,  bool isALeftChild) = fatherDict[node];
            if (father == null) return;

            if (father.val != node.val) return;

            TreeNode sibling = isALeftChild ? father.right : father.left;
            if (sibling != null && (father.val != sibling.val || !rootsOfUnivalSubtrees.Contains(sibling))) return;

            rootsOfUnivalSubtrees.Add(father);
            CountUnivalSubtreesFromTheLeaveNode(father);
        }
    }
}
