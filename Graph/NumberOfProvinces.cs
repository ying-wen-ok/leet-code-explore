using System;
using System.Collections.Generic;

namespace Graph
{
    public class NumberOfProvinces
    {
        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            UnionFindProvinces uf = new UnionFindProvinces(n);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (isConnected[i][j] == 1)
                        uf.Union(i, j);

            return uf.provincesHeadsCount;
        }
    }


    public class UnionFindProvinces
    {
        private int[] r;
        public int provincesHeadsCount;
        public UnionFindProvinces(int n)
        {
            provincesHeadsCount = n;
            r = new int[n];
            for (int i = 0; i < n; i++) r[i] = i;
        }

        public void Union(int a, int b)
        {
            int ra = r[a];
            int rb = r[b];

            if (ra == rb) return;
            else if (ra > rb) { provincesHeadsCount--; updateRootForAllMatchingNodes(ra, rb); }
            else if (ra < rb) { provincesHeadsCount--; updateRootForAllMatchingNodes(rb, ra); }
        }

        public int Find(int a)
        {
            return r[a];
        }

        private void updateRootForAllMatchingNodes(int oldRoot, int newRoot)
        {
            for (int i = 0; i < r.Length; i++)
                if (r[i] == oldRoot)
                    r[i] = newRoot;
        }

    }
}
