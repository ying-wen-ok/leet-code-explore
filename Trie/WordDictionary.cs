using System;
using System.Collections.Generic;


namespace Trie
{

    public class WordDictionary
    {
        private WordDictionaryNode root;

        public WordDictionary()
        {
            root = new WordDictionaryNode();
        }

        public void AddWord(string word)
        {
            if (word == null || word.Length == 0) return;
            WordDictionaryNode cur = root;
            foreach (char c in word)
            {
                int index = c - 'a';
                if (cur.nexts[index] == null) cur.nexts[index] = new WordDictionaryNode();
                cur = cur.nexts[index];
            }
            cur.isEndOfTheWord = true;
        }

        public bool Search(string word)
        {
            if (word == null || word.Length == 0) return false;
            WordDictionaryNode cur = root;
            int n = word.Length;
            for (int i = 0; i < n; i++)
            {
                char c = word[i];
                if (c == '.')
                {
                    return wildSearch(cur, word, i);
                }
                else
                {
                    int index = c - 'a';

                    if (cur.nexts[index] == null) return false;
                    cur = cur.nexts[index];
                }
            }
            return cur.isEndOfTheWord;
        }

        private bool wildSearch(WordDictionaryNode cur, string word, int start)
        {
            if (word == null || word.Length == 0 || cur == null) return false;

            int n = word.Length;
            WordDictionaryNode[] nexts = cur.nexts;

            foreach (WordDictionaryNode next in nexts)
            {
                if (next == null) continue;

                WordDictionaryNode potentialNode = next;

                for (int i = start + 1; i <= n; i++)
                {
                    if (i == n)
                    {
                        if (potentialNode.isEndOfTheWord) return true;
                    }
                    else
                    {
                        char c = word[i];
                        if (c == '.')
                        {
                            bool searchResult = wildSearch(potentialNode, word, i);
                            if (searchResult) return true;
                            else break;
                        }
                        else
                        {
                            int index = c - 'a';

                            if (potentialNode.nexts[index] == null) break;
                            else potentialNode = potentialNode.nexts[index];
                        }
                    }

                }
            }
            return false;
        }


    }

    public class WordDictionaryNode
    {
        public bool isEndOfTheWord;
        public WordDictionaryNode[] nexts;
        public WordDictionaryNode()
        {
            nexts = new WordDictionaryNode[26];
            isEndOfTheWord = false;
        }
    }

}
