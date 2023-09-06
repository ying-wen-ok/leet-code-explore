using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysAndStrings
{
    public class AddTwoBinaryStrings
    {
        public string AddBinary(string a, string b)
        {
            int n = a.Length;
            int m = b.Length;
            int i = n - 1;
            int j = m - 1;
            Stack<int> s = new Stack<int>();

            int cur = 0;
            while(i >= 0 || j >= 0)
            {     
                if (i >= 0 && a[i] == '1') cur++;
                if (j >= 0 && b[j] == '1') cur++;
                s.Push(cur % 2);
                cur = cur / 2;
                i--;
                j--;
            }
            if(cur == 1) s.Push(cur);
            StringBuilder sb = new StringBuilder();
            while(s.Count > 0)
            {
                sb.Append(s.Pop().ToString());
            }
            return sb.ToString();
        }
    }
}
