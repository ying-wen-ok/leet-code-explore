using System;
using System.Collections.Generic;

namespace HashTable
{
    /// <summary>
    /// Constraints: 
    ///     0 <= key <= 10^6
    ///     At most 10^4 calls will be made to add, remove, and contains.
    /// 
    /// bucketCount: 10^3, because there will be in total 10^4 data points needed to be saved, assume there will be 10 data points in one  bucket    
    /// Space: 0 ~ 4 * 10^3 byte
    /// Time: each bucket can have at most 10 data points, the worst case senario,
    /// all data in the same bucket, then it will take time of 10 to do Contains() operation. 
    /// </summary>
    public class MyHashSet
    {
        private List<int>[] data;
        private int bucketCount = 1000; 

        public MyHashSet()
        {          
            data = new List<int>[bucketCount];  

            for (int i = 0; i < bucketCount; i++)
            {
                data[i] = new List<int>();
            }
        }

        public void Add(int key)
        {            
            if (Contains(key)) return;
            int index = GetBucketIndex(key);
            data[index].Add(key);
        }

        public void Remove(int key)
        {
            if (!Contains(key)) return;
            int index = GetBucketIndex(key);
            data[index].Remove(index);
        }

        public bool Contains(int key)
        {
            int index = GetBucketIndex(key);
            return data[index].Contains(key);
        }

        private int GetBucketIndex(int key)
        {
            int lastTwoDogit = (key % bucketCount);
            return lastTwoDogit;
        }
    }

    /// <summary>
    /// Constraints: 
    ///     0 <= key <= 10^6
    ///     At most 10^4 calls will be made to add, remove, and contains.
    ///
    /// it is ok to use bool[] to indicate the data is because all keys are positive integers
    /// 
    /// Space: 10^6 byte
    /// Time: strictly O(1) time for each operation 
    /// 
    /// </summary>
    public class MyHashSetII
    {
        private bool[] data; // can use bool[] to indicate the numbers is because all keys are positive integers
        private int bucketCount = 1000001;

        public MyHashSetII()
        {
            data = new bool[bucketCount]; // size of 10^6 bool: 10^6 byte
        }

        public void Add(int key)
        {
            data[key] = true;
        }

        public void Remove(int key)
        {
            data[key] = false;
        }

        public bool Contains(int key)
        {          
            return data[key];
        }
    }
}
