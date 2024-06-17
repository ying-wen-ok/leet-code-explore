using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Trie
{
    public class WordSearchII
    {
        public IList<string> FindWords(char[][] board, string[] words)
        {
            WordTrie treeDict = new WordTrie();
            foreach (string word in words) treeDict.AddWord(word);

            map = board;
            n = board.Length;
            m = n == 0 ? 0 : board[0].Length;
            visited = new bool[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    WordTrieNode searchStart = treeDict.root;
                    dfs(i, j, searchStart);
                }
            }
            return result.ToArray();
        }

        private HashSet<string> result = new HashSet<string>();
        private char[][] map;
        private bool[,] visited;
        private int n;
        private int m;
        private (int i, int j)[] directions = new (int i, int j)[]
        {
            (0,1),
            (1,0),
            (0,-1),
            (-1,0)
        };

        private void dfs(int i, int j, WordTrieNode curNode)
        {
            if (curNode == null) return;
            if (curNode.word != null && curNode.word.Length > 0)
            {
                if (!result.Contains(curNode.word)) result.Add(curNode.word);
            }

            if (i >= n || j >= m || i < 0 || j < 0 || curNode == null || visited[i, j]) return;

            visited[i, j] = true;
            char currentChar = map[i][j];
            WordTrieNode nextNode = curNode.nexts[currentChar - 'a'];

            foreach (var direction in directions)
            {
                dfs(i + direction.i, j + direction.j, nextNode);
            }

            visited[i, j] = false;
        }
    }

    public class WordTrie
    {
        public WordTrieNode root;
        public WordTrie()
        {
            root = new WordTrieNode();
        }

        public void AddWord(string word)
        {
            WordTrieNode cur = root;
            foreach (char c in word)
            {
                int index = c - 'a';
                if (cur.nexts[index] == null) cur.nexts[index] = new WordTrieNode();
                cur = cur.nexts[index];
            }
            cur.word = word;
        }
    }

    public class WordTrieNode
    {
        public WordTrieNode[] nexts;
        public string word;
        public WordTrieNode()
        {
            nexts = new WordTrieNode[26];
        }

    }
}
