using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace ArraysAndStrings
{
    public class PascalsTriangleII
    {
        public IList<int> GetRow(int rowIndex)
        {
            int totalCount = rowIndex + 1;
            int[] cur = new int[totalCount];
            int[] pre = new int[totalCount];
            pre[0] = 1;
            for (int i = 1; i <= rowIndex; i++)
            {
                int count = i + 1;
                cur[0] = 1;
                cur[count - 1] = 1;
                for (int j = 1; j < count - 1; j++)
                {
                    cur[j] = pre[j] + pre[j - 1];
                }
                pre = cur.ToArray();
            }
            return pre;
        }
    }
}
