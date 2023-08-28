using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    public class WordBreaksI
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            int n = s.Length;
            HashSet<string> dict = wordDict.ToHashSet();
            bool[,] f = new bool[n + 1, n + 1]; // f[start index, end index] : 
            f[n, n] = true;

            for (int start = n - 1; start >= 0; start--)
            {
                StringBuilder subString = new StringBuilder();
                for (int end = start; end < n; end++)
                {
                    subString.Append(s[end]);
                    if (dict.Contains(subString.ToString())) f[start, end] = true;

                    f[start, n] = f[start, n] || (f[start, end] && f[end + 1, n]);
                }
            }

            return f[0, n];
        }
    }
}
