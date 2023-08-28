using System;
using System.Collections.Generic;

namespace Graph
{
    public class OptimizeWaterDistributionInAVillage
    {
        public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes)
        {
            List<(int to, int cost)>[] pipeDicts = new List<(int to, int cost)>[n + 1];
            for (int i = 0; i <= n; i++) pipeDicts[i] = new List<(int to, int cost)>();
            foreach (int[] pipe in pipes)
            {
                int cost = pipe[2];
                int i = pipe[0];
                int j = pipe[1];

                pipeDicts[i].Add((j, cost));
                pipeDicts[j].Add((i, cost));
            }

            for (int i = 1; i <= n; i++)
            {
                pipeDicts[0].Add((i, wells[i - 1]));
                pipeDicts[i].Add((0, wells[i - 1]));
            }

            int[] a = new int[n + 1];
            for (int i = 0; i <= n; i++) a[i] = (int)1e9; // a[i] : cost of adding this node i to graph
            a[0] = 0;

            PriorityQueue<int, int> nodesToBeAdded = new PriorityQueue<int, int>();
            for (int i = 0; i <= n; i++) nodesToBeAdded.Enqueue(i, a[i]);

            bool[] isNodeAdded = new bool[n + 1];
            int totalCount = 0;
            int totalCost = 0;

            while (totalCount <= n)
            {
                int arrival = nodesToBeAdded.Dequeue();
                if (isNodeAdded[arrival]) continue;

                totalCount++;
                isNodeAdded[arrival] = true;

                totalCost += a[arrival];

                foreach ((int to, int cost) in pipeDicts[arrival])
                {
                    if (a[to] <= cost || isNodeAdded[to]) continue;
                    a[to] = cost;
                    nodesToBeAdded.Enqueue(to, cost);
                }
            }
            return totalCost;
        }
    }
}
