using System;
using System.Collections.Generic;


namespace DynamicProgramming
{
    public class PaintFence
    {
        public int NumWays(int n, int k)
        {
            if (n == 1) return k;

            int f0 = k;
            int f1 = k * k;

            for (int i = 2; i < n; i++)
            {
                int fi =
                    f1 * (k - 1)     //  paint current post a different color than the previous post, for each color of previous post, total count as f1, there are k - 1 colors to choose from
                  + f0 * (k - 1);    //  paint current post the same color as the previous post, but have to be differnt color with the one before previous one.  for each color of the previous before previous post, total count as f0, there are k - 1 colors to choose from

                f0 = f1;
                f1 = fi;
            }

            return f1;
        }
    }
}
