using System;
using System.Collections.Generic;

namespace Graph
{
    public class AllPathsFromSourceToTargetBFS
    {
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            int start = 0;
            int n = graph.Length;
            int end = n - 1;

            Queue<List<int>> Q = new Queue<List<int>>();
            Q.Enqueue(new List<int>() { start });
            List<IList<int>> result = new List<IList<int>>();
            while (Q.Count > 0)
            {
                List<int> path = Q.Dequeue();
                int lastStop = path[path.Count - 1];
                if (lastStop == end)
                {
                    result.Add(path.ToList());
                    continue;
                }

                foreach (int i in graph[lastStop])
                {
                    if (i == lastStop) continue;
                    List<int> newPath = path.ToList();
                    newPath.Add(i);
                    Q.Enqueue(newPath);
                }
            }
            return result;
        }
    }
}
