using System;
using System.Xml.Linq;
using DataStructure;

namespace BinarySearchTree
{
    public class KthLargest
    {
        private TreeNode root; // root of BST
        private int kth;
        private int kThLargetValue;
        private int currentCount;

        public KthLargest(int k, int[] nums)
        {
            this.kth = k;
            foreach (int i in nums) Add(i);           
        }

        public int Add(int val)
        {
            if (root == null) { root = new TreeNode(val); return val; }
            AddNode(val);
            getKthLargest();

            return kThLargetValue;
        }

        private void AddNode(int val)
        {           
            insertedSuccessfully = false;
            SearchAndAddNode(val, root);
        }

        // if equal go right
        private bool insertedSuccessfully;
        private void SearchAndAddNode(int val, TreeNode i)
        {
            if (insertedSuccessfully || i == null) return;

            if (val < i.val)
            {
                if(i.left == null)
                {
                    i.left = new TreeNode(val);
                    insertedSuccessfully = true;
                }
                else
                {
                    SearchAndAddNode(val, i.left);
                }
            }
            else
            {
                if(i.right == null)
                {
                    i.right = new TreeNode(val);
                    insertedSuccessfully = true;
                }
                else
                {
                    SearchAndAddNode(val, i.right);
                }
            }
        }

        private void getKthLargest()
        {
            currentCount = kth;
            traverseBSTByDescendingOrder(root);
        }
        
        private void traverseBSTByDescendingOrder(TreeNode i)
        {
            if(i == null || currentCount == 0) return;

            traverseBSTByDescendingOrder(i.right);
            if (currentCount == 0) return;

            currentCount--;
            if(currentCount == 0)
            {
                kThLargetValue = i.val;
                return;
            }

            traverseBSTByDescendingOrder(i.left);
        }
    
      
    }

}
                                         