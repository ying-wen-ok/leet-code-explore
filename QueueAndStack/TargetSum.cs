using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class TargetSum
    {
        public int FindTargetSumWays(int[] _nums, int _target)
        {
            nums = _nums;
            target = _target;
            n = nums.Length;
            calculate(0, 0);
            return ways;
        }

        int[] nums;
        int n;
        int ways = 0;
        int target;
        private void calculate(int cur, int i)
        {
            if(i == n)
            {
                if (cur == target) ways++;
                return;
            }
            
            calculate(cur + nums[i], i + 1);                     
            calculate(cur - nums[i], i + 1);
        }
    }
}
