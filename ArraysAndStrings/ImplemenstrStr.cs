using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class ImplemenstrStr
    {
        public int StrStr(string haystack, string needle)
        {
            int n = haystack.Length;
            int m = needle.Length;
            for(int i = 0; i < n;i ++) 
            {
                if (haystack[i] == needle[0])
                {
                    bool success = true;
                    for(int j = 1; j < m; j ++)
                    {
                        if (i + j >= n || haystack[i + j] != needle[j])
                        {
                            success = false;
                            break;
                        }
                    }
                    if (success) return i;
                }
            }

            return -1;
        }
    }
}
