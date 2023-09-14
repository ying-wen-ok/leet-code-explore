using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class PerfectSquares
    {
        public int NumSquares(int n)
        {
            Dictionary<int, int> stepsCount = new Dictionary<int, int>();
            List<int> pathsLength = new List<int>();
            Queue<int> Q = new Queue<int>();
           
            for (int i = 1; i < 101; i++)
            {
                int pathLength = i * i;
                if (pathLength > n) break;
                pathsLength.Add(pathLength);
                stepsCount.Add(pathLength, 1);
                Q.Enqueue(pathLength);
            }
            if (stepsCount.ContainsKey(n)) return 1;
            
         
            while (Q.Count > 0)
            {
                int cur = Q.Dequeue();
                int curCount = stepsCount[cur];

                foreach (int path in pathsLength)
                {
                    int nextArrival = cur + path;
                    if (nextArrival > n) continue;
                    if (nextArrival == n) return curCount + 1;
                    if (stepsCount.ContainsKey(nextArrival)) continue;
                    
                    stepsCount.Add(nextArrival, curCount + 1);       
                    Q.Enqueue(nextArrival);                    
                }
            }

            return -1;
        }
    }
}
