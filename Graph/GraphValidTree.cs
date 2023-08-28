using System;
using System.Collections.Generic;

namespace Graph
{
    public class GraphValidTree
    {
        public bool ValidTree(int n, int[][] edges)
        {
            if (edges.Length != n - 1) return false;
            UnionTreeNodes tree = new UnionTreeNodes(n);

            foreach (int[] edge in edges)
                if (!tree.Union(edge[0], edge[1]))
                    return false;

            return true;
        }
    }

    public class UnionTreeNodes
    {
        private int[] parent;
        public UnionTreeNodes(int n)
        {
            parent = new int[n];
            for (int i = 0; i < n; i++) { parent[i] = i; }
        }

        public bool Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA == rootB) return false;

            if (rootA < rootB) parent[b] = rootA;
            else if (rootA > rootB) parent[a] = rootB;
            return true;
        }

        public int Find(int a)
        {
            if (a == parent[a]) { return a; }
            return parent[a] = Find(parent[a]);
        }
    }
}
