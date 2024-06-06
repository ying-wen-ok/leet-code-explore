using System;
using System.Collections.Generic;


namespace Trie
{
    public class Trie
    {
        private TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            if (word == null || word.Length == 0) return;

            TrieNode cur = root;
            foreach(char c in word)
            {
                int index = c - 'a';
                if (cur.nexts[index] == null) cur.nexts[index] = new TrieNode();
                cur = cur.nexts[index];               
            }
            cur.countOfWordsTail++;
        }

        public bool Search(string word)
        {
            if (word == null || word.Length == 0) return false;
            TrieNode cur = root;
            foreach (char c in word)
            {
                int index = c - 'a';
                cur = cur.nexts[index];
                if (cur == null) return false;
            }

            return cur.countOfWordsTail > 0;
        }

        public bool StartsWith(string prefix)
        {
            if (prefix == null || prefix.Length == 0) return false;
            TrieNode cur = root;
            foreach (char c in prefix)
            {
                int index = c - 'a';
                cur = cur.nexts[index];
                if (cur == null) return false;
            }

            return true;
        }
    }

    public class TrieNode
    {
        public TrieNode ()
        {
            nexts = new TrieNode[26];
            countOfWordsTail = 0;
        }

        public int countOfWordsTail;
        public TrieNode[] nexts;
    }
}
