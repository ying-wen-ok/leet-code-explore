using System;
using System.Collections.Generic;

namespace Graph
{
    public class EvaluateDivision
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            int n = equations.Count;
            UnionDivision unionDivision = new UnionDivision(equations);
            for (int i = 0; i < n; i++) unionDivision.Union(equations[i][0], equations[i][1], values[i]);
            unionDivision.CompressAllPaths();

            int m = queries.Count;
            double[] results = new double[m];
            for (int i = 0; i < m; i++)
            {
                results[i] = -1;

                string a = queries[i][0];
                string b = queries[i][1];

                if (!unionDivision.dict.ContainsKey(a) || !unionDivision.dict.ContainsKey(b)) continue;

                (string ParentItem, double multiple) dividend = unionDivision.dict[a];
                (string ParentItem, double multiple) divisor = unionDivision.dict[b];

                if (divisor.ParentItem != dividend.ParentItem) continue;

                results[i] = dividend.multiple / divisor.multiple;
            }
            return results;
        }
    }

    public class UnionDivision
    {
        public Dictionary<string, (string ParentItem, double multiple)> dict;

        public UnionDivision(IList<IList<string>> equations)
        {
            dict = new Dictionary<string, (string ParentItem, double multiple)>();
            int n = equations.Count;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < 2; j++)
                {
                    dict.TryAdd(equations[i][j], (equations[i][j], 1));
                }
        }

        public void Union(string dividend, string divisor, double value)
        {
            var dividendWithBase = Find(dividend);
            var divisorWithBase = Find(divisor);

            if (dividendWithBase.ParentItem == divisorWithBase.ParentItem) return;

            double divisorNewValue = dividendWithBase.multiple / (divisorWithBase.multiple * value);
            string divisorNewBaseNumber = dividendWithBase.ParentItem;

            dict[divisorWithBase.ParentItem] = (divisorNewBaseNumber, divisorNewValue);
        }

        public (string ParentItem, double multiple) Find(string a)
        {
            if (a == dict[a].ParentItem) { return dict[a]; }

            string nextLevelItem = dict[a].ParentItem;
            double aMultipleToNextLevel = dict[a].multiple;

            var root = Find(nextLevelItem);

            return dict[a] = (root.ParentItem, root.multiple * aMultipleToNextLevel);
        }

        public void CompressAllPaths()
        {
            foreach (string key in dict.Keys) Find(key);
        }
    }

}

