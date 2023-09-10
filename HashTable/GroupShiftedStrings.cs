using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HashTable
{
    public class GroupShiftedStrings
    {
        public IList<IList<string>> GroupStrings(string[] strings)
        {
            Dictionary<string, List<string>> gourpDict = new Dictionary<string, List<string>>();

            foreach (string s in strings)
            {
                string goupKey = ShiftedStrings(s);
                gourpDict.TryAdd(goupKey, new List<string>());
                gourpDict[goupKey].Add(s);
            }

            int n = gourpDict.Count;
            List<string>[] result = new List<string>[n];
            int i = 0;
            foreach (var keyValue in gourpDict)
            {
                result[i] = keyValue.Value;
                i++;
            }
            return result;
        }

        // always shift the first char to 'z', countOfFristCharShiftsToZ will always be positive
        private string ShiftedStrings(string input)
        {
            if (input.Length == 0) return "";
            StringBuilder output = new StringBuilder();
            int countOfFristCharShiftsToZ = 'z' - input[0]; 
            foreach(char c in input)
            {
                output.Append(ShiftChar(c, countOfFristCharShiftsToZ));
            }
            return output.ToString();
        }

        private char ShiftChar(char c, int shifts)
        {                     
            char newC = (char)(c + shifts);
            if (newC > 'z') newC = (char) (newC - 26); 
            return newC;
        }
    }
}
