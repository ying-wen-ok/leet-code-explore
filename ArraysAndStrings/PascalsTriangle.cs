using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class PascalsTriangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            List<int>[] result = new List<int>[numRows];
            result[0] = new List<int> { 1 };
            for (int i = 1; i < numRows; i++)
            {
                List<int> preRow = result[i - 1];
                List<int> row = new List<int>();
                row.Add(1);
                for (int j = 1; j < i; j++)
                {
                    row.Add(preRow[j - 1] + preRow[j]);
                }
                row.Add(1);
                result[i] = row;
            }
            return result;
        }
    }
}
