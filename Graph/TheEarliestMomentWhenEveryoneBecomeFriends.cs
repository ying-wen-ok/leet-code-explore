using System;
using System.Collections.Generic;

namespace Graph
{
    public class TheEarliestMomentWhenEveryoneBecomeFriends
    {
        public int EarliestAcq(int[][] logs, int n)
        {
            int[][] sortedLog = logs.OrderBy(i => i[0]).ToArray();
            UnionFriends friendGoup = new UnionFriends(n);

            foreach (int[] log in sortedLog)
            {
                friendGoup.Union(log[1], log[2]);
                if (friendGoup.componentsCount == 1)
                    return log[0];
            }
            return -1;
        }
    }


    public class UnionFriends
    {
        private int[] r;
        public int componentsCount;
        public UnionFriends(int n)
        {
            componentsCount = n;
            r = new int[n];
            for (int i = 0; i < n; i++) { r[i] = i; }
        }

        public void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA == rootB) return;
            componentsCount--;

            int oldRoot = Math.Max(rootA, rootB);
            int onewRoot = Math.Min(rootA, rootB);

            for (int i = 0; i < r.Length; i++)
            {
                if (r[i] == oldRoot) r[i] = onewRoot;
            }
        }

        public int Find(int a)
        {
            if (a == r[a]) { return a; }
            return r[a] = Find(r[a]);
        }
    }
}
