using System;
using System.Collections.Generic;

namespace Trie
{
    public class MapSum
    {
        MapSumTriesNode root;
        public MapSum()
        {
            root = new MapSumTriesNode();
        }

        public void Insert(string key, int val)
        {
            if (key == null || key.Length == 0) return;
            (bool containsTheKey, int value) = ContainsKey(key);

            if(containsTheKey)
            {
                UpdateAnExistingPair(key, val, value);
            }
            else
            {
                InsertANewPair(key, val);
            }
        }

        private void UpdateAnExistingPair(string key, int newVal, int oldValue)
        {
            if (key == null || key.Length == 0) return;
            MapSumTriesNode cur = root;
            foreach (char c in key)
            {
                int index = c - 'a';
              
                cur = cur.nexts[index];

                cur.pathSum -= oldValue;
                cur.pathSum += newVal;
            }

            cur.value = newVal;
        }

        private void InsertANewPair(string key, int val)
        {
            if (key == null || key.Length == 0) return;
            MapSumTriesNode cur = root;
            foreach (char c in key)
            {
                int index = c - 'a';
                if (cur.nexts[index] == null) cur.nexts[index] = new MapSumTriesNode();
                cur = cur.nexts[index];

                cur.pathSum += val;
            }

            cur.value = val;
        }

        private (bool containsTheKey, int value) ContainsKey(string key)
        {
            if (key == null || key.Length == 0) return (false, 0);
            MapSumTriesNode cur = root;
            foreach (char c in key)
            {
                int index = c - 'a';
                if (cur.nexts[index] == null) return (false, 0);
                cur = cur.nexts[index];
            }
            return (true, cur.value);
        }

        public int Sum(string prefix)
        {
            if (prefix == null || prefix.Length == 0) return 0;
            MapSumTriesNode cur = root;
            foreach (char c in prefix)
            {
                int index = c - 'a';
                if (cur.nexts[index] == null) return 0;
                cur = cur.nexts[index];
            }
            return cur.pathSum;
        }
    }

    public class MapSumTriesNode
    {
        public MapSumTriesNode[] nexts;
        public int pathSum;
        public int value;
       
        public MapSumTriesNode()
        {
            nexts = new MapSumTriesNode[26];
            value = 0;
            pathSum = 0;
        }
    }


}
