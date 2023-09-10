using System;
using System.Collections.Generic;

namespace HashTable
{
    public class TwoSum
    {
        private Dictionary<int, int> dict;
        public TwoSum()
        {
            dict = new Dictionary<int, int>();
        }

        public void Add(int number)
        {
            dict.TryAdd(number, 0);
            dict[number]++;
        }

        public bool Find(int value)
        {
            foreach(int key in dict.Keys)
            {
                int anotherNumber = value - key;
                if(anotherNumber == key)
                {
                    if (dict[key] > 1) return true;
                }
                else
                {
                    if (dict.ContainsKey(anotherNumber)) return true;
                }                
            }
            return false;
        }
    }
}
