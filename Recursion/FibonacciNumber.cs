using System;
using System.Collections.Generic;

namespace Recursion
{
    public class FibonacciNumber
    {
        int[] fibs;
        public int Fib(int n)
        {  
            if (n == 0) return 0;
            if (n == 1) return 1;
            
            fibs = new int[n + 1];  
            fibs[0] = 0;
            fibs[1] = 1;
            for (int i = 2; i <= n; i++) fibs[i] = -1;          
            return GetFib(n);
        }

        private int GetFib(int n)
        {
            if (fibs[n] < 0) fibs[n] = GetFib(n - 1) + GetFib(n - 2);
            return fibs[n];
        }
    }
}
