using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class MinCostToConnectAllPointsPrimsAlgorithm
    {
        public int MinCostConnectPoints(int[][] points)
        {
            int n = points.Length;
            int[][] adjecencyMatrix = new int[n][];
            for (int i = 0; i < n; i++) adjecencyMatrix[i] = new int[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || adjecencyMatrix[i][j] > 0) continue;
                    adjecencyMatrix[i][j] = CalculateManhattanDistance(points[i], points[j]);
                    adjecencyMatrix[j][i] = adjecencyMatrix[i][j];
                }
            }
            int[] a = new int[n];
            for (int i = 0; i < n; i++) a[i] = (int)1e9; // a[i] : cost of adding this node i to graph
            a[0] = 0;

            PriorityQueue<int, int> nodesToBeAdded = new PriorityQueue<int, int>();
            for (int i = 0; i < n; i++) nodesToBeAdded.Enqueue(i, a[i]);

            bool[] isNodeAdded = new bool[n];
            int totalCount = 0;
            int totalCost = 0;

            while (totalCount < n)
            {
                int arrivalNode = nodesToBeAdded.Dequeue();
                if (isNodeAdded[arrivalNode]) continue;
                totalCount++;
                isNodeAdded[arrivalNode] = true;
                totalCost += a[arrivalNode];

                for (int i = 0; i < n; i++) // nextNode : i
                {
                    if (isNodeAdded[i] || a[i] <= adjecencyMatrix[i][arrivalNode]) continue;
                    a[i] = adjecencyMatrix[i][arrivalNode];
                    nodesToBeAdded.Enqueue(i, a[i]);
                }
            }

            return totalCost;
        }

        private int CalculateManhattanDistance(int[] i, int[] j)
        {
            return Math.Abs(i[0] - j[0]) + Math.Abs(i[1] - j[1]);
        }
    }
}
