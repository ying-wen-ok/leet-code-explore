using System;
using System.Collections.Generic;

namespace Graph
{
    public class CourseScheduleII
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            int[] inDegreeCount = new int[numCourses];
            List<int>[] adjecency = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++) { adjecency[i] = new List<int>(); }
            foreach (int[] i in prerequisites)
            {
                int to = i[0];
                int from = i[1];

                adjecency[from].Add(to);
                inDegreeCount[to]++;
            }

            Queue<int> Q = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
                if (inDegreeCount[i] == 0) Q.Enqueue(i);

            List<int> toplogicalOrder = new List<int>();
            while (Q.Count > 0)
            {
                int from = Q.Dequeue();
                toplogicalOrder.Add(from);
                foreach (int to in adjecency[from])
                {
                    inDegreeCount[to]--;
                    if (inDegreeCount[to] == 0) Q.Enqueue(to);
                }
            }

            return toplogicalOrder.Count == numCourses ? toplogicalOrder.ToArray() : new int[0];
        }
    }
}
