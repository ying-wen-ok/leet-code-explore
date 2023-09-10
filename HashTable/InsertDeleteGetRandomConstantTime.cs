using System;
using System.Collections.Generic;

namespace HashTable
{
    // You must implement the functions of the class such that each function works in average O(1) time complexity.
    public class RandomizedSet
    {
        private Dictionary<int, int> numberIndexDict;
        private List<int> numbers;
        private Random seed;
        public RandomizedSet()
        {
            numberIndexDict = new Dictionary<int, int>();
            numbers = new List<int>();
            seed = new Random();
        }

        // Inserts an item val into the set if not present.
        // Returns true if the item was not present, false otherwise.
        public bool Insert(int val)
        {
            bool isPresent = numberIndexDict.ContainsKey(val);
            if (isPresent) return false;
            int newIndex = numbers.Count;
            numbers.Add(val);
            numberIndexDict.Add(val, newIndex);
            return true;
        }

        //Removes an item val from the set if present.
        //Returns true if the item was present, false otherwise.
        public bool Remove(int val)
        {
            bool isPresent = numberIndexDict.ContainsKey(val);
            if (!isPresent) return false;

            int targetIndex = numberIndexDict[val];
            int lastIndex = numbers.Count - 1;

            numbers[targetIndex] = numbers[lastIndex];
            numberIndexDict[numbers[lastIndex]] = targetIndex;

            numbers.RemoveAt(lastIndex);
            numberIndexDict.Remove(val);
            return true;
        }

        // Returns a random element from the current set of elements
        // (it's guaranteed that at least one element exists when this method is called).
        // Each element must have the same probability of being returned.
        public int GetRandom()
        {
            int random = seed.Next(numbers.Count);
            return numbers[random];
        }
    }
}
