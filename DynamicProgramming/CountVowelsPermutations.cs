using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class CountVowelsPermutations
    {
        public int CountVowelPermutation(int n)
        {
            //   'a', 'e', 'i', 'o', 'u'
            //    0,   1,   2,   3,   4

            List<int>[] dict = new List<int>[5];
            dict[0] = new List<int>() { 1 };        // key: 'a'
            dict[1] = new List<int>() { 0, 2 };      //   'e'
            dict[2] = new List<int>() { 0, 1, 3, 4 };  //   'i'
            dict[3] = new List<int>() { 2, 4 };     //   'o'
            dict[4] = new List<int>() { 0 };        //   'u'

            long modulo = (int)1e9 + 7;
            long[,] dp = new long[n, 5];
            for (int j = 0; j < 5; j++) dp[0, j] = 1;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    foreach (int k in dict[j])
                    {
                        dp[i + 1, k] += dp[i, j];
                        dp[i + 1, k] = dp[i + 1, k] % modulo;
                    }
                }
            }
            long totalPermutation = 0;
            for (int i = 0; i < 5; i++)
            {
                totalPermutation += dp[n - 1, i];
                totalPermutation = totalPermutation % modulo;
            }
            return (int)totalPermutation;
        }
    }
}
