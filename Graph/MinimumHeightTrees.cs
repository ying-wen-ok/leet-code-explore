using System;
using System.Collections.Generic;

namespace Graph
{
    public class MinimumHeightTrees
    {
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            List<int>[] adjecency = new List<int>[n];
            for (int i = 0; i < n; i++) adjecency[i] = new List<int>();
            foreach (int[] edge in edges)
            {
                adjecency[edge[0]].Add(edge[1]);
                adjecency[edge[1]].Add(edge[0]);
            }

            int[] degree = new int[n];
            int[] heights = new int[n];
            Queue<int> leafs = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                degree[i] = adjecency[i].Count;
                if (degree[i] == 1)
                {
                    leafs.Enqueue(i);
                    heights[i] = 1;
                }
            }

            while (leafs.Count > 0)
            {
                int leaf = leafs.Dequeue();
                foreach (int parent in adjecency[leaf])
                {
                    degree[parent]--;
                    if (degree[parent] == 1)
                    {
                        heights[parent] = Math.Max(heights[parent], heights[leaf] + 1);
                        leafs.Enqueue(parent);
                    }
                }
            }

            List<int> result = new List<int>();
            int maxHeight = heights.Max();
            for (int i = 0; i < n; i++)
                if (heights[i] == maxHeight)
                    result.Add(i);

            return result;
        }
    }
}
