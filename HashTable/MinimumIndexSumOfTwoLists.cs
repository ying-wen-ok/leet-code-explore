using System;
using System.Collections.Generic;

namespace HashTable
{
    public class MinimumIndexSumOfTwoLists
    {
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            int n1 = list1.Length;
            int n2 = list2.Length;

            Dictionary<string, int> dictOfIndexsOfString = new Dictionary<string, int>();
            for (int i = 0; i < n1; i++) dictOfIndexsOfString.Add(list1[i], i);
            
            int leastIndexSum = n1 + n2;
            List<string> result = new List<string>();          
            for(int i = 0; i < n2; i++)
            {
                string s = list2[i];
                if(dictOfIndexsOfString.ContainsKey(s))
                {
                    int indexSum = i + dictOfIndexsOfString[s];

                    if (indexSum > leastIndexSum) 
                    { 
                        continue; 
                    }
                    else if (indexSum == leastIndexSum)
                    {
                        result.Add(s);
                    }
                    else if (indexSum < leastIndexSum)
                    {
                        leastIndexSum = indexSum;
                        result = new List<string>();
                        result.Add(s);
                    }
                }
            }
            return result.ToArray();
        }
    }
}
