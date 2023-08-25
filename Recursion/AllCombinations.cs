using System;
using System.Collections.Generic;

namespace Recursion
{
    public class AllCombinations
    {
        public IList<IList<int>> Combine(int _n, int _k)
        {
            n = _n;
            k = _k;
            used = new bool[n + 1];
            cur = new int[k];
            result = new List<IList<int>>();

            Fill(0);
            return result;
        }

        int n;
        int k;
        int[] cur;
        bool[] used;
        List<IList<int>> result;

        private void Fill(int position)
        {
            if (position == k)
            {
                result.Add(cur.ToArray());
                return;
            }

            int prePostionValue = position == 0 ? 0 : cur[position - 1];
            for (int candidate = 1 + prePostionValue; candidate <= n; candidate++)
            {
                if (used[candidate]) continue;
                used[candidate] = true;
                cur[position] = candidate;
                Fill(position + 1);
                cur[position] = 0;
                used[candidate] = false;
            }
        }


    }

}
