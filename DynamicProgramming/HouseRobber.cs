using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class HouseRobber
    {
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];

            int n = nums.Length;

            int pre2 = nums[0];
            int pre = Math.Max(nums[1], nums[0]);
            int cur = Math.Max(nums[1], nums[0]);

            for (int i = 2; i < n; i++)
            {
                cur = Math.Max(
                    pre,
                    pre2 + nums[i]
                );

                pre2 = pre;
                pre = cur;
            }
            return cur;
        }
    }
}
