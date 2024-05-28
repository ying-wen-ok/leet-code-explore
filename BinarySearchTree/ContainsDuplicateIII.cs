using DataStructure;
using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
//using DataStructure;

namespace BinarySearchTree
{
    public class ContainsDuplicateIII
    {
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
        {
            MyTree valuesWithinTheWindow = new MyTree();

            int n = nums.Length;
            valuesWithinTheWindow.InsertIntoBST(nums[0]);
            for (int i = 1; i <= indexDiff && i < n; i++)
            {
                if (exsit(valuesWithinTheWindow, valueDiff, nums[i])) return true;
                valuesWithinTheWindow.InsertIntoBST(nums[i]);
            }

            for (int i = indexDiff + 1; i < n; i++)
            {
                int indexOfTheFirstElementInTheWindow = i - indexDiff - 1;
                valuesWithinTheWindow.DeleteNode(nums[indexOfTheFirstElementInTheWindow]);
                if (exsit(valuesWithinTheWindow, valueDiff, nums[i])) return true;
                valuesWithinTheWindow.InsertIntoBST(nums[i]);
            }
            return false;
        }

        private bool exsit(MyTree data, int valueDiff, int newlyAddedValue)
        {
            int? closestNeighbor = data.ClosestValue(newlyAddedValue);
            if (closestNeighbor == null) return false;
            return Math.Abs(closestNeighbor.Value - newlyAddedValue) <= valueDiff;
        }
    }

    public class MyTree
    {
        private TreeNode mytreeRoot;
        private int deletTarget;
        private bool deletePositionfound;
        private int addTarget;
        private bool addPositionFound;

        public MyTree()
        {

        }

        public int? ClosestValue(double target)
        {
            if (mytreeRoot == null) return null;
            TreeNode cur = mytreeRoot;
            int result = mytreeRoot.val;
            int lowerBound = mytreeRoot.val;
            int upperBound = mytreeRoot.val;

            while (cur != null)
            {
                if (cur.val > target)
                {
                    upperBound = cur.val;
                    cur = cur.left;
                }
                else if (cur.val < target)
                {
                    lowerBound = cur.val;
                    cur = cur.right;
                }
                else
                {
                    lowerBound = cur.val;
                    break;
                }
            }

            result = Math.Abs(lowerBound - target) < Math.Abs(upperBound - target) ? lowerBound : upperBound;
            return result;
        }

        public void InsertIntoBST(int val)
        {
            TreeNode root = mytreeRoot;
            addPositionFound = false;
            if (root == null)
            {
                mytreeRoot = new TreeNode(val);
                return;
            }
            addTarget = val;
            InorderTraverse(root);
            if (!addPositionFound) InsertTheNodeAsBiggestNodeInTheSubTree(root);
            mytreeRoot = root;
        }

        public void DeleteNode(int key)
        {
            TreeNode root = mytreeRoot;
            if (root == null || (root.left == null && root.right == null && root.val == key)) { mytreeRoot = null; return; }
            deletTarget = key;
            deletePositionfound = false;
            InorderTraverseAndLookForTargetNode(root, null, false);
            mytreeRoot = root;
        }

        private void InorderTraverse(TreeNode i)
        {
            if (i == null || addPositionFound) return;

            InorderTraverse(i.left);
            if (addPositionFound) return;

            if (i.val > addTarget)
            {
                InsertTheNodeAsLeftChild(i);
                addPositionFound = true;
                return;
            }
            InorderTraverse(i.right);
        }

        // new code will be the biggest in the left tree
        private void InsertTheNodeAsLeftChild(TreeNode parent)
        {
            if (parent.left == null) parent.left = new TreeNode(addTarget);
            else InsertTheNodeAsBiggestNodeInTheSubTree(parent.left);
        }

        private void InsertTheNodeAsBiggestNodeInTheSubTree(TreeNode root)
        {
            TreeNode biggestInTheSubTree = root;
            while (biggestInTheSubTree.right != null) biggestInTheSubTree = biggestInTheSubTree.right;
            biggestInTheSubTree.right = new TreeNode(addTarget);
        }

        private void InorderTraverseAndLookForTargetNode(TreeNode i, TreeNode father, bool isLeftChild)
        {
            if (deletePositionfound || i == null) return;

            InorderTraverseAndLookForTargetNode(i.left, i, true);
            if (deletePositionfound) return;

            if (i.val == deletTarget)
            {
                deletePositionfound = true;
                DeleteTargetNode(i, father, isLeftChild);
            }

            if (deletePositionfound) return;
            InorderTraverseAndLookForTargetNode(i.right, i, false);
        }

        private void DeleteTargetNode(TreeNode i, TreeNode father, bool isLeftChild)
        {
            if (IsALeafNode(i))
            {
                // father node will not be null, because the case of father == null already been taken case of in the previous part of the solution.
                DeleteTheLeafNode(father, isLeftChild);
            }
            else if (i.left != null)
            {
                SwapTheLargestValueInItsLeftSubtreeAndDeleteTheNodeUsed(i);
            }
            else if (i.right != null)
            {
                SwapTheSmallestValueInItsRightSubtreeAndDeleteTheNodeOfUsed(i);
            }
        }

        private void SwapTheLargestValueInItsLeftSubtreeAndDeleteTheNodeUsed(TreeNode targetNode)
        {
            TreeNode father = targetNode;
            TreeNode i = targetNode.left;
            bool isLeftChild = true;
            while (i.right != null)
            {
                father = i;
                i = i.right;
                isLeftChild = false;
            }

            targetNode.val = i.val;// swap value
            DeleteTargetNode(i, father, isLeftChild); //delete the node of used
        }

        private void SwapTheSmallestValueInItsRightSubtreeAndDeleteTheNodeOfUsed(TreeNode targetNode)
        {
            TreeNode father = targetNode;
            TreeNode i = targetNode.right;
            bool isLeftChild = false;

            while (i.left != null)
            {
                father = i;
                i = i.left;
                isLeftChild = true;
            }

            targetNode.val = i.val; // swap value
            DeleteTargetNode(i, father, isLeftChild); //delete the node of used
        }

        private bool IsALeafNode(TreeNode i)
        {
            return i != null && i.left == null && i.right == null;
        }

        private void DeleteTheLeafNode(TreeNode father, bool isLeftChild)
        {
            if (father == null) return;
            if (isLeftChild)
            {
                father.left = null;
            }
            else
            {
                father.right = null;
            }
        }
    }

}