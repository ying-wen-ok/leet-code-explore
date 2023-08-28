using System;
using System.Collections.Generic;

namespace Graph
{
    public class ParallelCourses
    {
        public int MinimumSemesters(int n, int[][] relations)
        {

            int[] inDegree = new int[n + 1];
            List<int>[] adjecency = new List<int>[n + 1];
            for (int i = 0; i <= n; i++) adjecency[i] = new List<int>();
            foreach (int[] i in relations)
            {
                int pre = i[0];
                int next = i[1];

                adjecency[pre].Add(next);
                inDegree[next]++;
            }

            int[] height = new int[n + 1];
            Queue<int> leafs = new Queue<int>();
            for (int i = 1; i <= n; i++)
                if (inDegree[i] == 0)
                {
                    leafs.Enqueue(i);
                    height[i] = 1;
                }

            while (leafs.Count > 0)
            {
                int i = leafs.Dequeue();

                foreach (int j in adjecency[i])
                {
                    inDegree[j]--;
                    if (inDegree[j] == 0)
                    {
                        height[j] = height[i] + 1;
                        leafs.Enqueue(j);
                    }
                }
            }

            int maxHeight = 0;
            for (int i = 1; i <= n; i++)
            {
                if (height[i] == 0) return -1;
                maxHeight = Math.Max(maxHeight, height[i]);
            }

            return maxHeight;
        }
    }
}
