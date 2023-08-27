using System;
using System.Collections.Generic;

namespace Recursion
{
    public class InplaceReverseString
    {
        public void ReverseString(char[] s)
        {
            swapIJ(s, 0, s.Length - 1);
        }

        private void swapIJ(char[] s, int i, int j)
        {
            if (i >= j) return;

            char temp = s[i]; 
            s[i] = s[j]; 
            s[j] = temp;

            i++;
            j--;
            swapIJ(s, i, j);
        }
    }
}
