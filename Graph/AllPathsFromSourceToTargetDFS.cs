using System;
using System.Collections.Generic;

namespace Graph
{
    public class AllPathsFromSourceToTargetDFS
    {
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            int n = graph.Length;

            source = 0;
            destination = n - 1;
            adjecencies = graph;

            visited = new bool[n];
            S = new Stack<int>();
            S.Push(source);

            result = new List<IList<int>>();
            path = new List<int>();
            dfsTraverse();
            return result;
        }

        Stack<int> S;
        IList<IList<int>> result;
        int[][] adjecencies;
        int source;
        int destination;
        bool[] visited;
        List<int> path;
        private void dfsTraverse()
        {
            if (S.Count == 0) return;

            int cur = S.Pop();
            if (visited[cur]) return;

            path.Add(cur);
            visited[cur] = true;

            if (cur == destination)
            {
                result.Add(path.ToArray());
            }
            else
            {
                foreach (int i in adjecencies[cur])
                {
                    if (!visited[i]) S.Push(i);
                    dfsTraverse();
                }
            }

            visited[cur] = false;
            path.Remove(cur);
        }
    }
}
