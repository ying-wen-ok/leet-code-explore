using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class FindIfPathExistsInGraphBFS
    {
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            List<int>[] adjecency = GetAdjecencyInnonDirectionGraph(n, edges);
            bool[] visited = new bool[n];

            Queue<int> Q = new Queue<int>();
            Q.Enqueue(source);

            while (Q.Count > 0)
            {
                int i = Q.Dequeue();
                if (i == destination) return true;
                if (visited[i]) continue;
                visited[i] = true;
                foreach (int j in adjecency[i])
                {
                    if (visited[j]) continue;
                    Q.Enqueue(j);
                }
            }

            return false;
        }


        private List<int>[] GetAdjecencyInnonDirectionGraph(int n, int[][] nonDirectionEdges)
        {
            List<int>[] adjecency = new List<int>[n];
            for (int i = 0; i < n; i++) adjecency[i] = new List<int>();

            foreach (int[] edge in nonDirectionEdges)
            {
                int i = edge[0];
                int j = edge[1];

                adjecency[i].Add(j);
                adjecency[j].Add(i);
            }
            return adjecency;
        }
    }
}
