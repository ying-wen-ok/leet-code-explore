using System;
using System.Collections.Generic;

namespace Recursion
{
    public class PowCalculation
    {
        public double MyPow(double x, int n)
        {
            if (x == 0) return 0;
            if (x == 1) return 1;
            if (x == -1) return n % 2 == 0 ? 1 : -1;
            if (n == 0) return 1;
            if (n == 1) return x;

            if (n < 0) return pow((1 / x), -n);
            return pow(x, n);
        }

        private double pow(double x, int n)
        {
            if (n == 0) return 1;
            if (n == 1) return x;

            if (n % 2 == 0)
            {
                double result = pow(x, n / 2);
                return result * result;
            }
            else
            {
                double result = pow(x, n / 2);
                return x * result * result;
            }
        }
    }
}
