using System;
using System.Collections.Generic;

namespace HashTable
{
    /// <summary>
    /// Constrains:
    ///     0 <= key, value <= 10^6
    ///     At most 10^4 calls will be made to put, get, and remove.
    /// </summary>
    public class MyHashMap
    {
        private List<(int key, int value)>[] data;
        private int bucketCount = 1000;

        public MyHashMap()
        {
            data = new List<(int key, int value)>[bucketCount];

            for(int i = 0; i < bucketCount; i++)
            {
                data[i] = new List<(int key, int value)>(); 
            }
        }

        public void Put(int key, int value)
        {
            int index = LocateBucket(key);
            int n = data[index].Count;
            for (int i = 0; i < n; i++)
            {
                if (data[index][i].key == key)
                {
                    data[index][i] = (key, value);
                    return;
                }
            }

            data[index].Add((key, value));
        }

        public int Get(int key)
        {
            int index = LocateBucket(key);
            int n = data[index].Count;
            for (int i = 0; i < n; i++)
            {
                if (data[index][i].key == key)
                {                    
                    return data[index][i].value;
                }
            }
            return -1;
        }

        public void Remove(int key)
        {
            int index = LocateBucket(key);
            int n = data[index].Count;
            for (int i = 0; i < n; i++)
            {
                if (data[index][i].key == key)
                {
                    data[index][i] = (key, -1);
                    return;
                }
            }
        }

        private int LocateBucket(int key)
        {
            int lastTwoDigit = key % 100;
            return lastTwoDigit;
        }
    }
}
