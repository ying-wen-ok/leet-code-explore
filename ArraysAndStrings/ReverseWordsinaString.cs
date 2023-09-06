using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysAndStrings
{
    public class ReverseWordsinaString
    {
        public string ReverseWords(string s)
        {
            char whitespace = ' ';
            int n = s.Length;

            int i = n - 1; // end of the word
            int j = n - 1; // start of the word

            StringBuilder sb = new StringBuilder();  
            while(j >= 0)
            {
                if (s[j] == whitespace)
                {
                    recordWord(s, sb, j + 1, i);
                    i = j - 1;
                    sb.Append(whitespace);
                }
                j--;
            }
            recordWord(s, sb, 0, i);
            return sb.ToString();
        }

        private void recordWord(string s, StringBuilder sb, int start, int end)
        {
            for(int i = start; i <= end; i++)
            {
                sb.Append(s[i]);
            }
        }
    }
}
