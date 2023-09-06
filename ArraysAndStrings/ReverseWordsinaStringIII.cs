using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysAndStrings
{
    public class ReverseWordsinaStringIII
    {
        public string ReverseWords(string s)
        {
            char[] chars = s.ToCharArray();
            char whitespace = ' ';
            int n = s.Length;
            int i = 0; //endOfWord
            int j = 0; //startOfTheWord
            while (i < n) 
            {
                if (chars[i] == whitespace)
                {
                    ReverseWord(chars, j, i - 1);
                    j = i + 1;
                }
                i++;
            }
            ReverseWord(chars, j, n - 1);
            StringBuilder sb = new StringBuilder();   
            foreach(char c in chars ) { sb.Append( c ); }
            return sb.ToString();
        }

        private void ReverseWord(char[] chars, int start, int end)
        {
            while(start < end)
            {
                char temp = chars[start];
                chars[start] = chars[end];
                chars[end] = temp;

                start++;
                end--;
            }            
        }
    }
}
