using System;
using System.Collections.Generic;
using DataStructure;

namespace BinarySearch
{
    public class ClosestBinarySearchTreeValue
    {
        public int ClosestValue(TreeNode root, double target)
        {
            TreeNode cur = root;
            int result = root.val;
            int lowerBound = root.val;
            int upperBound = root.val;

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
    }
}
