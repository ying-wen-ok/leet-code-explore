using System;
using System.Collections.Generic;

namespace Graph
{
    public class ReconstructItinerary
    {
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            List<string> airportNames = new List<string>();
            foreach (var path in tickets)
            {
                airportNames.Add(path[0]);
                airportNames.Add(path[1]);
            }
            airportNames = airportNames.Distinct().ToList();
            airportNames.Sort();

            int n = airportNames.Count;
            Dictionary<string, int> airportNameIdDictionarySoredByName = new Dictionary<string, int>();
            List<int>[] adjecencies = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                airportNameIdDictionarySoredByName.Add(airportNames[i], i);
                adjecencies[i] = new List<int>();
            }

            Dictionary<(int from, int to), int> pathCount = new Dictionary<(int from, int to), int>();
            foreach (var path in tickets)
            {
                string from = path[0];
                string to = path[1];

                adjecencies[airportNameIdDictionarySoredByName[from]].Add(airportNameIdDictionarySoredByName[to]);

                pathCount.TryAdd((airportNameIdDictionarySoredByName[from], airportNameIdDictionarySoredByName[to]), 0);
                pathCount[(airportNameIdDictionarySoredByName[from], airportNameIdDictionarySoredByName[to])]++;
            }

            for (int i = 0; i < n; i++) adjecencies[i].Sort();

            EulerianCircuit graph = new EulerianCircuit(adjecencies, pathCount);
            graph.SetStart(airportNameIdDictionarySoredByName["JFK"]);
            List<int> eulerianCircuitPath = graph.GetPath();

            int m = eulerianCircuitPath.Count;
            string[] itinerary = new string[m];
            for (int i = 0; i < m; i++) itinerary[i] = airportNames[eulerianCircuitPath[i]];
            return itinerary;
        }
    }


    public class EulerianCircuit
    {
        private List<int>[] adjecencies;
        private Dictionary<(int from, int to), int> edgeUsed;
        private List<int> order;
        private int startNode;

        public EulerianCircuit(List<int>[] adjecencies, Dictionary<(int from, int to), int> edgeUsed)
        {
            this.adjecencies = adjecencies;
            this.edgeUsed = edgeUsed;
            order = new List<int>();
        }

        public void SetStart(int i)
        {
            startNode = i;
        }

        public List<int> GetPath()
        {
            dfs(startNode);
            order.Reverse(0, order.Count);
            return order;
        }

        private void dfs(int i)
        {
            foreach (int j in adjecencies[i])
            {
                if (edgeUsed[(i, j)] > 0)
                {
                    edgeUsed[(i, j)]--;
                    dfs(j);
                }
            }
            order.Add(i);
        }
    }
}
