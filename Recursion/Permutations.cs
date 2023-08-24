using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Permutations
    {
        private List<IList<int>> permutations = new List<IList<int>>();
        private bool[] used;
        private int[] cur;
        private int n;
        private int[] nums;
        public IList<IList<int>> Permute(int[] _nums)
        {
            nums = _nums;
            n = nums.Length;
            used = new bool[n];
            cur = new int[n];

            Fill(0);

            return permutations;
        }

        private void Fill(int position)
        {
            if (position == n)
            {
                permutations.Add(cur.ToArray());
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (used[i]) continue;
                used[i] = true;
                cur[position] = nums[i];
                Fill(position + 1);
                used[i] = false;
            }
        }
    }

}
