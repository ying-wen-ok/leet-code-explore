using System;
using System.Collections.Generic;

namespace HashTable
{
    public class GroupAnagramsTogether
    {
        // time: (100 * log(2,100) ) * 10000 < 700 * 10000 < 10^7  
        // space : 100 * 10^4 = 10^6  
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> gourpDict = new Dictionary<string, List<string>>();

            foreach(string s in strs)
            {
                string goupKey = SortChars(s);
                gourpDict.TryAdd(goupKey, new List<string>());
                gourpDict[goupKey].Add(s);
            }

            int n = gourpDict.Count;
            List<string>[] result = new List<string>[n];
            int i = 0;
            foreach(var keyValue in gourpDict)
            {
                result[i] = keyValue.Value;
                i++;
            }
            return result;
        }

        private string SortChars(string input)
        {
            char[] data = input.ToCharArray();
            Array.Sort(data);            
            return new string(data);
        }
    }
}