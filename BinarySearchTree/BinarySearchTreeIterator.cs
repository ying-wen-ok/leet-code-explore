using System;
using DataStructure;

namespace BinarySearchTree
{
    public class BSTIterator
    {       
        private int curIndex;
        private List<TreeNode> list;

        public BSTIterator(TreeNode root)
        {
            curIndex = 0;
            list = new List<TreeNode>();
            GetOrderedNodes(root);
        }

        public int Next()
        {
            if (!HasNext()) return -1;

            int result = list[curIndex].val;
            curIndex++;
            return result;
        }

        public bool HasNext()
        {
            return curIndex < list.Count;
        }
       

        private void GetOrderedNodes(TreeNode i)
        {
            if (i == null) return;
            GetOrderedNodes(i.left);
            list.Add(i);
            GetOrderedNodes(i.right);
        }
    }
}
