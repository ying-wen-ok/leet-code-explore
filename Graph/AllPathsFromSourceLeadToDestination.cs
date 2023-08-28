using System;
using System.Collections.Generic;

namespace Graph
{
    public class AllPathsFromSourceLeadToDestination
    {
        public bool LeadsToDestination(int n, int[][] edges, int source, int _destination)
        {
            adjecency = new List<int>[n];
            selfCicle = new bool[n];
            visited = new bool[n];
            verticeOnCurrentPath = new bool[n];
            GetAdjecenciesInAGraphWithDirection(n, edges);
            destination = _destination;

            // check if the destination or source vertice are self circle vertice 
            if (selfCicle[source] || selfCicle[destination]) return false;

            // check if the destination or source have poper degree
            if (adjecency[source].Count == 0 && source != destination) return false;
            if (adjecency[destination].Count > 0) return false;

            dfs(source);

            return !foundDeadEnd && !foundCicle && findDestination;
        }

        private int destination;
        private bool[] visited;
        private bool[] verticeOnCurrentPath;
        private bool[] selfCicle;
        private List<int>[] adjecency;
        private bool foundCicle;
        private bool foundDeadEnd;
        private bool findDestination;

        private void GetAdjecenciesInAGraphWithDirection(int n, int[][] edges)
        {
            for (int i = 0; i < n; i++) adjecency[i] = new List<int>();

            foreach (int[] edge in edges)
            {
                int from = edge[0];
                int to = edge[1];

                adjecency[from].Add(to);

                if (from == to) selfCicle[from] = true;
            }
        }

        private void dfs(int i)
        {
            if (foundDeadEnd || foundCicle) return;
            if (selfCicle[i] || verticeOnCurrentPath[i]) { foundCicle = true; return; }

            if (visited[i]) return;
            visited[i] = true;

            if (i == destination) { findDestination = true; return; }
            if (adjecency[i].Count == 0) { foundDeadEnd = true; return; }

            verticeOnCurrentPath[i] = true;
            foreach (int j in adjecency[i]) dfs(j);
            verticeOnCurrentPath[i] = false;
        }
    }
}
