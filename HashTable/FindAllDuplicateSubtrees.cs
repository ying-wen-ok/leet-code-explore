using System;
using System.Collections.Generic;
using DataStructure;
using System.Text;

namespace HashTable
{
    public class FindAllDuplicateSubtrees
    {
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            PrintTree(root);

            List<TreeNode> duplicateTrees = new List<TreeNode>();
            foreach (var keyValue in treePrintDcit)
            {
                if (keyValue.Value.Count > 1)
                {
                    duplicateTrees.Add(keyValue.Value.FirstOrDefault());
                }
            }
            return duplicateTrees.ToArray();
        }

        private Dictionary<string, List<TreeNode>> treePrintDcit = new Dictionary<string, List<TreeNode>>();
        private int nullNode = 201;
        private StringBuilder PrintTree(TreeNode node)
        {
            if (node == null) return new StringBuilder("n");

            StringBuilder left = PrintTree(node.left);
            StringBuilder right = PrintTree(node.right);
            StringBuilder whole = new StringBuilder();

            whole.Append("s"); // indicating tree start
            whole.Append(node.val);
            whole.Append("l"); // indicating left sub stree start
            whole.Append(left);
            whole.Append("r"); // indicating right sub stree start    
            whole.Append(right);

            string key = whole.ToString();
            treePrintDcit.TryAdd(key, new List<TreeNode>());
            treePrintDcit[key].Add(node);
            return whole;
        }
    }
}
