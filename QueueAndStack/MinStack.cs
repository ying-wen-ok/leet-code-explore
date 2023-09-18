using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class MinStack
    {
        Stack<int> dataStack;
        Stack<(int index, int value)> minValueStack;
        public MinStack()
        {
            dataStack = new Stack<int>();
            minValueStack = new Stack<(int, int)>();
        }

        // pushes the element val onto the stack.
        public void Push(int val)
        {         
            if (IsEmpty())
            {
                minValueStack.Push((dataStack.Count, val));               
            }
            else
            {
                int min = GetMin();
                if (min > val)
                {
                    minValueStack.Push((dataStack.Count, val));
                }
            }
            dataStack.Push(val);
        }

        // removes the element on the top of the stack.
        public void Pop()
        {
            int popedValue = dataStack.Pop();
            if (dataStack.Count == minValueStack.Peek().index) minValueStack.Pop();
        }

        // gets the top element of the stack.
        public int Top()
        {
            return dataStack.Peek();
        }

        // retrieves the minimum element in the stack.
        public int GetMin()
        {
            return minValueStack.Peek().value;
        }

        private bool IsEmpty()
        {
            return dataStack.Count == 0;
        }
    }
}
