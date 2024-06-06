using System;
using System.Collections.Generic;
using System.Text;

namespace Trie
{
    public class ReplaceWordsWithRoots
    {
        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            TrieTree trie = new TrieTree();
            foreach(string s in dictionary) trie.AddKey(s);
           
            StringBuilder result = new StringBuilder();
            string[] words = sentence.Split(" ");
            int n = words.Length;
            for(int i = 0; i < n; i++)
            {
                string s = words[i];
                result.Append(trie.SearchKey(s));
                if(i < n - 1) result.Append(" ");
            }
            
            return result.ToString();
        }


    }

    public class TrieTree
    {
        private TrieTreeNode root;
        public TrieTree()
        {
            root = new TrieTreeNode();
        }

        public void AddKey(string key)
        {
            if (key == null || key.Length == 0) return;

            TrieTreeNode cur = root;
            foreach (char c in key)
            {
                int index = c - 'a';
                if (cur.nexts[index] == null) cur.nexts[index] = new TrieTreeNode();
                cur = cur.nexts[index];              
            }
            cur.value = key;
            cur.countOfKeysEndHere++;
        }

        public string SearchKey(string key)
        {
            if (key == null || key.Length == 0) return key;

            TrieTreeNode cur = root;
            foreach (char c in key)
            {            
                int index = c - 'a';
                if (cur.nexts[index] == null) return key;             
                cur = cur.nexts[index];
                if (cur.countOfKeysEndHere > 0) return cur.value;
            }
            return key;
        }
    }

    public class TrieTreeNode
    {
        public string value;
        public int countOfKeysEndHere;
        public TrieTreeNode[] nexts;
        public TrieTreeNode()
        {
            countOfKeysEndHere = 0;
            nexts = new TrieTreeNode[26];
        }
    }
}
