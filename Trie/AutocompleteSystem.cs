using System;
using System.Collections.Generic;
using System.Text;

namespace Trie
{

    public class AutocompleteSystem
    {
        TrieTreeForAutoComplete trie;
        private Dictionary<string, int> hotDegreeDict;
        StringBuilder word;

        public AutocompleteSystem(string[] sentences, int[] times)
        {
            trie = new TrieTreeForAutoComplete();
            hotDegreeDict = new Dictionary<string, int>();
            word = new StringBuilder();
            int n = sentences.Length;
            for (int i = 0; i < n; i++) AddNewWord(sentences[i], times[i]);
        }

        public IList<string> Input(char c)
        {
            IList<string> result = new List<string>();
            if (c == '#')
            {
                AddNewWord(word.ToString(), 1);
                word = new StringBuilder();
            }
            else
            {
                word.Append(c);
                trie.GoToNextChar(c);

                result = trie.curNode.top3Words.ToArray();
            }
            return result;
        }

        private void AddNewWord(string word, int time)
        {
            hotDegreeDict.TryAdd(word, 0);
            hotDegreeDict[word] -= time;
            trie.InsertWord(word);
            trie.UpdateEachNodeTop3Words(word, hotDegreeDict);
        }
    }

    public class TrieTreeForAutoComplete
    {
        public TrieTreeForAutoCompleteNodeForAutoComplete root;
        public TrieTreeForAutoCompleteNodeForAutoComplete curNode;

        public TrieTreeForAutoComplete()
        {
            root = new TrieTreeForAutoCompleteNodeForAutoComplete(27);
            curNode = root;
        }

        public void InsertWord(string word)
        {
            foreach (char ch in word) GoToNextChar(ch);
            ResetCurrentNode();
        }

        public void GoToNextChar(char c)
        {
            int index = GetIndex(c);
            if (curNode.children[index] == null) curNode.children[index] = new TrieTreeForAutoCompleteNodeForAutoComplete(27);
            curNode = curNode.children[index];
        }

        public void UpdateEachNodeTop3Words(string word, Dictionary<string, int> hotDegreeDict)
        {
            foreach (char c in word)
            {
                GoToNextChar(c);

                var top3Words = curNode.top3Words;
                if (!top3Words.Contains(word)) top3Words.Add(word);
                var wordsSorted = top3Words.Select(w => (hotDegreeDict[w], w)).ToList();
                wordsSorted.Sort();
                curNode.top3Words = wordsSorted.Take(3).Select(p => p.Item2).ToList();
            }
            ResetCurrentNode();
        }

        private void ResetCurrentNode()
        {
            curNode = root;
        }

        private int GetIndex(char c)
        {
            return (c == ' ') ? 26 : c - 'a';
        }
    }

    public class TrieTreeForAutoCompleteNodeForAutoComplete
    {
        public List<string> top3Words;
        public TrieTreeForAutoCompleteNodeForAutoComplete[] children;
        public TrieTreeForAutoCompleteNodeForAutoComplete(int n)
        {
            children = new TrieTreeForAutoCompleteNodeForAutoComplete[n];
            top3Words = new List<string>();
        }
    }

}
