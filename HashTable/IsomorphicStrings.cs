using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HashTable
{
    public class IsomorphicStrings
    {
        /// <Constraints>        
        ///  1 <= s.length <= 5 * 104
        ///  s and t consist of any valid ascii character.
        ///  </Constraints>      

        ///  <Space>
        ///  O(1) Constant.
        ///  In total, there are 256 ASCII characters, so the dictionaries' size will be 256
        ///  Extrs Space consumption will be  2 * 256
        ///  </Space>  
           
        /// <Time>
        /// O(n)
        /// </Time>
          
        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> dictOfMappingSToT = new Dictionary<char, char>();
            HashSet<char> setOfCharsBeenMappedTo = new HashSet<char>();

            int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                char charS = s[i];
                char charT = t[i];

                if (!dictOfMappingSToT.ContainsKey(charS))
                {
                    if (setOfCharsBeenMappedTo.Contains(charT)) return false;
                    setOfCharsBeenMappedTo.Add(charT);
                    dictOfMappingSToT.Add(charS, charT);
                }
                else if (dictOfMappingSToT[charS] != t[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
