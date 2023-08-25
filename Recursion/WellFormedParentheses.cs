using System.Text;
using System;
using System.Collections.Generic;

namespace Recursion
{
    public class WellFormedParentheses
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> parenthesis = new List<string>();
            int totalLength = 2 * n;

            Stack<StringBuilder> stack = new Stack<StringBuilder>();
            stack.Push(new StringBuilder());
            while (stack.Count > 0)
            {
                StringBuilder i = stack.Pop();
                if (i.Length == totalLength)
                {
                    if (isValidParenthesis(i)) parenthesis.Add(i.ToString());
                    continue;
                }

                StringBuilder iPlusOpen = copyStringBuilder(i);
                iPlusOpen.Append(open);
                stack.Push(iPlusOpen);

                StringBuilder iPlusClose = copyStringBuilder(i);
                iPlusClose.Append(close);
                stack.Push(iPlusClose);
            }
            return parenthesis;
        }

        char open = '(';
        char close = ')';
        private StringBuilder copyStringBuilder(StringBuilder original)
        {
            StringBuilder copy = new StringBuilder(original.Length);
            copy.Append(original);
            return copy;
        }

        private bool isValidParenthesis(StringBuilder cur)
        {
            Stack<char> s = new Stack<char>();
            string curParenthesis = cur.ToString();
            foreach (char c in curParenthesis)
            {
                if (c == open) s.Push(c);
                else if (c == close)
                {
                    if (s.Count > 0) s.Pop();
                    else return false;
                }
            }
            return s.Count == 0;
        }
    }
}
