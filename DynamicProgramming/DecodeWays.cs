using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    public class DecodeWays
    {
        public int NumDecodings(string s)
        {
            HashSet<string> dict = new HashSet<string>();
            for (int i = 1; i <= 26; i++) dict.Add(i.ToString());

            int n = s.Length;
            int[] f = new int[n + 1];
            f[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                StringBuilder subString = new StringBuilder();
                for (int j = i; j <= n && j < i + 3; j++)
                {
                    subString.Append(s[j - 1]);
                    if (dict.Contains(subString.ToString()) && f[i - 1] > 0)
                    {
                        f[j] += f[i - 1];
                    }
                }
            }

            return f[n];
        }
    }
}
