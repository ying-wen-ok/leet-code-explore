using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class ValidParentheses
    {
        public bool IsValid(string s)
        {
            Stack<char> opens = new Stack<char>();
            foreach(char i in s)
            {
                switch(i)
                {
                    case ')':
                        if (opens.Count == 0 || opens.Pop() != '(') return false;
                        break;

                    case '}':
                        if (opens.Count == 0 || opens.Pop() != '{') return false;
                        break;

                    case ']':
                        if (opens.Count == 0 || opens.Pop() != '[') return false;
                        break;

                    default:
                        opens.Push(i);
                        break;
                }
            }

            return opens.Count == 0;
        }
    }
}
