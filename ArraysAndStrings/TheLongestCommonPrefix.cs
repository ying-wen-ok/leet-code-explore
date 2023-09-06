using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysAndStrings
{
    public class TheLongestCommonPrefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            int m = strs[0].Length;
            if (m == 0) return "";
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i < m)
            {
                bool same = true;
                foreach (string str in strs)
                {
                    if (i >= str.Length || strs[0][i] != str[i]) { same = false; break; }
                }
                if (same) sb.Append(strs[0][i]);
                else break;
                i++;
            }

            return sb.ToString();
        }


    }
}
