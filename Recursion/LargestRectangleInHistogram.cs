using System;
using System.Collections.Generic;

namespace Recursion
{
    public class LargestRectangleInHistogram
    {
        public int LargestRectangleArea(int[] heights)
        {
            int largest = 0;
            int n = heights.Length;

            Stack<(int Index, int Height)> s = new Stack<(int Index, int Height)>();
            for (int iIndex = 0; iIndex <= n; iIndex++)
            {
                int iHeight = iIndex == n ? 0 : heights[iIndex];
                while (s.Count > 0 && s.Peek().Height > iHeight)
                {
                    int jHeight = s.Pop().Height;

                    int endIndexOfJHeightAre = iIndex - 1;
                    int startIndexOfJHeightAre = s.Count > 0 ? s.Peek().Index + 1 : 0;

                    int jArea = jHeight * (endIndexOfJHeightAre - startIndexOfJHeightAre + 1);
                    largest = Math.Max(jArea, largest);
                }

                s.Push((iIndex, iHeight));
            }

            return largest;
        }
    }
}
