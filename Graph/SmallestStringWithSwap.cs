using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class SmallestStringWithSwap
    {
        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            int n = s.Length;
            UnionFind unionFind = new UnionFind(n);
            foreach (List<int> pair in pairs) unionFind.Union(pair[0], pair[1]);
            for (int i = 0; i < n; i++) unionFind.Find(i);

            Dictionary<int, int[]> dict = new Dictionary<int, int[]>();
            for (int i = 0; i < n; i++)
            {
                int root = unionFind.r[i];
                dict.TryAdd(root, new int[26]);
                dict[root][s[i] - 'a']++;
            }

            int[] roots = unionFind.r;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                char c = 'a';
                int[] charsArray = dict[roots[i]];
                for (int j = 0; j < 26; j++)
                {
                    if (charsArray[j] > 0)
                    {
                        c = (char)('a' + j);
                        charsArray[j]--;
                        break;
                    }
                }
                sb.Append(c);
            }

            return sb.ToString();
        }
    }

    public class UnionFind
    {
        public int[] r;
        public int componentsCount;
        public UnionFind(int n)
        {
            componentsCount = n;
            r = new int[n];
            for (int i = 0; i < n; i++) { r[i] = i; }
        }

        public void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA == rootB) return;
            componentsCount--;

            int oldRoot = Math.Max(rootA, rootB);
            int newRoot = Math.Min(rootA, rootB);

            r[oldRoot] = newRoot;
        }

        public int Find(int a)
        {
            if (a == r[a]) { return a; }
            return r[a] = Find(r[a]);
        }
    }
}
