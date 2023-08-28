using System;
using System.Collections.Generic;

namespace Graph
{
    public class FindIfPathExistsInGraphDFS
    {
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            Stack<int> S = new Stack<int>();
            S.Push(source);
            bool[] visited = new bool[n];
            List<int>[] adjecencies = new List<int>[n];
            for (int i = 0; i < n; i++) adjecencies[i] = new List<int>();
            foreach (int[] edge in edges)
            {
                int i = edge[0];
                int j = edge[1];

                adjecencies[i].Add(j);
                adjecencies[j].Add(i);
            }

            while (S.Count > 0)
            {
                int cur = S.Pop();
                if (cur == destination) { return true; }
                if (visited[cur]) continue;
                visited[cur] = true;

                foreach (int i in adjecencies[cur]) if (!visited[i]) S.Push(i);
            }

            return false;
        }
    }
}
