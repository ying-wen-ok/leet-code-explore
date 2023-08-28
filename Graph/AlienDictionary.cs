using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class AlienDictionary
    {
        public string AlienOrder(string[] words)
        {
            int totalAlphabetCount = 26;

            bool[] alphabetFound = new bool[totalAlphabetCount];
            foreach (string word in words)
                foreach (char c in word)
                    alphabetFound[CharToInt(c)] = true;

            int alphabetFoundTotalCount = 0;
            foreach (bool i in alphabetFound)
                if (i) alphabetFoundTotalCount++;

            HashSet<int>[] adjecency = new HashSet<int>[totalAlphabetCount];
            for (int i = 0; i < totalAlphabetCount; i++) adjecency[i] = new HashSet<int>();
            int n = words.Length;
            for (int i = 1; i < n; i++)
            {
                string pre = words[i - 1];
                string cur = words[i];
                int m = Math.Min(pre.Length, cur.Length);


                bool validOrderfund = false;
                for (int j = 0; j < m; j++)
                {
                    if (pre[j] != cur[j])
                    {
                        validOrderfund = true;

                        char parent = pre[j];
                        char child = cur[j];

                        adjecency[CharToInt(parent)].Add(CharToInt(child));
                        break;
                    }
                }

                if (!validOrderfund && pre.Length > cur.Length) return string.Empty;
            }

            int[] inDegreeCount = new int[totalAlphabetCount];
            for (int i = 0; i < totalAlphabetCount; i++)
                if (!alphabetFound[i])
                    inDegreeCount[i] = -1;

            for (int i = 0; i < totalAlphabetCount; i++)
                foreach (int child in adjecency[i])
                    inDegreeCount[child]++;

            Queue<int> Q = new Queue<int>();
            for (int i = 0; i < totalAlphabetCount; i++)
                if (inDegreeCount[i] == 0)
                    Q.Enqueue(i);

            List<int> toplogicalOrder = new List<int>();
            while (Q.Count > 0)
            {
                int parent = Q.Dequeue();
                toplogicalOrder.Add(parent);
                foreach (int i in adjecency[parent])
                {
                    inDegreeCount[i]--;
                    if (inDegreeCount[i] == 0) Q.Enqueue(i);
                }
            }

            if (toplogicalOrder.Count != alphabetFoundTotalCount) return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (int i in toplogicalOrder) sb.Append(IntToChar(i));
            return sb.ToString();
        }

        private int CharToInt(char c)
        {
            return c - 'a';
        }

        private char IntToChar(int i)
        {
            return (char)('a' + i);
        }

    }
}
