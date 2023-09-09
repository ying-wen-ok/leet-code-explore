using System;
using System.Collections.Generic;

namespace HashTable
{
    public class FirstUniqueCharacterinaString
    {
        /// <Constraints>
        /// 1 <= s.length <= 10^5
        /// s consists of only lowercase English letters.
        /// </Constraints>
        /// Space : O(1) constaint. As the dictionary size will be 26, 
        ///         as there will be only lowercase English letters.
        /// Time: O(n)
        public int FirstUniqChar(string s)
        {
            int n = s.Length;
            int maxIndex = n;
            Dictionary<char, int> charIndexDict = new Dictionary<char, int>();
           
            for(int i = 0; i < n; i++)
            {
                char c = s[i];
                if (charIndexDict.ContainsKey(c))
                {
                    charIndexDict[c] = maxIndex;
                }
                else
                {
                    charIndexDict.Add(c, i);
                }
            }

            int minIndex = maxIndex;
            foreach(var i in charIndexDict)
            {
                minIndex = Math.Min(i.Value, minIndex);
            }
            return minIndex == maxIndex ? -1 : minIndex;
        }
        
    }
}
