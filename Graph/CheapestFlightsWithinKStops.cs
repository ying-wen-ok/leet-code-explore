using System;
using System.Collections.Generic;

namespace Graph
{
    public class CheapestFlightsWithinKStops
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            List<(int to, int edgeCost)>[] adjecency = new List<(int to, int edgeCost)>[n];
            for (int i = 0; i < n; i++) adjecency[i] = new List<(int to, int edgeCost)>();
            foreach (int[] edge in flights)
            {
                int i = edge[0];
                int j = edge[1];
                int edgeCost = edge[2];

                adjecency[i].Add((j, edgeCost));
            }
            int infinity = (int)1e9;
            int[] price = new int[n];
            for (int i = 0; i < n; i++) price[i] = infinity;

            PriorityQueue<(int to, int cost, int stopped), (int stopped, int cost)> pq =
                new PriorityQueue<(int to, int cost, int stopped), (int stopped, int cost)>();
            pq.Enqueue((src, 0, 0), (0, 0));
            while (pq.Count > 0)
            {
                (int i, int cost, int stopped) = pq.Dequeue();
                if (cost >= price[i] || stopped > k) continue;

                price[i] = cost;
                foreach ((int j, int edgeCost) in adjecency[i])
                {
                    int newCost = cost + edgeCost;
                    int newStopped = stopped + (j == dst ? 0 : 1);

                    pq.Enqueue((j, newCost, newStopped), (newStopped, newCost));
                }
            }

            return price[dst] == infinity ? -1 : price[dst];
        }
    }
}
