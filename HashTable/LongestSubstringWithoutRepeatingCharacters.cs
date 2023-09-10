using System;
using System.Collections.Generic;

namespace HashTable
{
    public class LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            HashSet<char> set = new HashSet<char>();
            int maxLen = 0;
            int start = 0;
            for(int end = 0; end < n; end++)
            {
                char c = s[end];
                if (set.Contains(c))
                {
                    while(s[start] != c)
                    {
                        set.Remove(s[start]);
                        start++;
                    }
                    start++;
                }
                else
                {
                    set.Add(c);
                    maxLen = Math.Max(set.Count, maxLen);
                }
            }
            return maxLen;
        }
    }
}
