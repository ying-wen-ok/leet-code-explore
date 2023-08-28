using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class MinCostToConnectAllPointsKruskalsAlgorithm
    {
        public int MinCostConnectPoints(int[][] points)
        {
            int n = points.Length;

            PriorityQueue<(int i, int j, int cost), int> edgesToBeAdded = new PriorityQueue<(int i, int j, int cost), int>();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < i; j++)
                {
                    int cost = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                    edgesToBeAdded.Enqueue((i, j, cost), cost);
                }

            int totalCost = 0;
            UnionPoints uf = new UnionPoints(n);
            while (uf.componentsCount > 1)
            {
                (int i, int j, int cost) = edgesToBeAdded.Dequeue();
                totalCost += uf.Union(i, j) ? cost : 0;
            }
            return totalCost;
        }
    }

    public class UnionPoints
    {
        public int[] r;
        public int componentsCount;
        public UnionPoints(int n)
        {
            componentsCount = n;
            r = new int[n];
            for (int i = 0; i < n; i++) { r[i] = i; }
        }

        public bool Union(int a, int b)
        {
            int rootA = r[a];
            int rootB = r[b];

            if (rootA == rootB) return false;
            componentsCount--;

            int oldRoot = Math.Max(rootA, rootB);
            int newRoot = Math.Min(rootA, rootB);

            r[oldRoot] = newRoot;
            for (int i = 0; i < r.Length; i++) Find(i);
            return true;
        }

        public int Find(int a)
        {
            if (a == r[a]) { return a; }
            return r[a] = Find(r[a]);
        }
    }
}
