using System;
using System.Collections.Generic;
using System.Text;

namespace QueueAndStack
{
    public class DecodeTheString
    {
        public string DecodeString(string s)
        {
            char open = '[';
            char close = ']';

            s = s + ']';
            Stack<string> data = new Stack<string>();
            StringBuilder curSb = new StringBuilder();

            foreach (char c in s)
            {
                if (c == close)
                {
                    if (curSb.Length > 0) { data.Push(curSb.ToString()); curSb = new StringBuilder(); }

                    while (data.Count > 1)
                    {
                        string secondStirng = secondStirng = data.Pop();
                        bool completed = data.Peek() == open.ToString();
                        if (completed) data.Pop();

                        string firstString = data.Count > 0 ? data.Pop() : "";
                        if (isAnInteger(firstString))
                        {
                            StringBuilder repeatedString = new StringBuilder();
                            int repeatTimes = Convert.ToInt32(firstString);
                            for (int i = 0; i < repeatTimes; i++) repeatedString.Append(secondStirng);
                            data.Push(repeatedString.ToString());
                        }
                        else
                        {
                            data.Push(firstString + secondStirng);
                        }

                        if (completed) break;
                    }
                }
                else if (c == open)
                {
                    if (curSb.Length > 0) data.Push(curSb.ToString());
                    data.Push(open.ToString());
                    curSb = new StringBuilder();
                }
                else
                {                    
                    if((isDigit(c) && isIntSB(curSb)) || (!isDigit(c) && isStringSB(curSb)))
                    {
                        curSb.Append(c);
                    }
                    else
                    {
                        data.Push(curSb.ToString());
                        curSb = new StringBuilder();
                        curSb.Append(c);
                    }
                }
            }
            return data.Pop();
        }

        private bool isAnInteger(string s)
        {
            if (s == null || s.Length == 0) return false;
            return isDigit(s[0]);
        }

        private bool isStringSB(StringBuilder sb)
        {
            int n = sb.Length;
            if (n == 0) return true;
            return isDigit(sb[0]);
        }

        private bool isIntSB(StringBuilder sb)
        {
            int n = sb.Length;
            if (n == 0) return true;
            return isDigit(sb[0]);
        }
       
        private bool isDigit(char c)
        {
            return c - '0' <= 9 && c - '0' >= 0;
        }
    }
}