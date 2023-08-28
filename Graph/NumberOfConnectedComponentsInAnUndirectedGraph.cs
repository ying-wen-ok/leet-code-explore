using System;
using System.Collections.Generic;

namespace Graph
{
    public class NumberOfConnectedComponentsInAnUndirectedGraph
    {
        public int CountComponents(int n, int[][] edges)
        {
            UnionComponents unionComponents = new UnionComponents(n);
            foreach (int[] edge in edges)
                unionComponents.Union(edge[0], edge[1]);

            return unionComponents.componentsCount;
        }
    }

    public class UnionComponents
    {
        private int[] r;
        public int componentsCount;
        public UnionComponents(int n)
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
            int onewRoot = Math.Min(rootA, rootB);

            for (int i = 0; i < r.Length; i++)
                if (r[i] == oldRoot)
                    r[i] = onewRoot;
        }

        public int Find(int a)
        {
            if (a == r[a]) { return a; }
            return r[a] = Find(r[a]);
        }
    }
}
