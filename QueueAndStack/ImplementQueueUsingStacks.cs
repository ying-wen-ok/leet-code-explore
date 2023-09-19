using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class MyQueue
    {
        private Stack<int> data;

        public MyQueue()
        {
            data = new Stack<int>();
        }

        public void Push(int x)
        {
            Stack<int> temp = new Stack<int>();
            while(data.Count > 0)
            {
                temp.Push(data.Pop());
            }
            data.Push(x);

            while(temp.Count > 0)
            {
                data.Push(temp.Pop());
            }
        }

        public int Pop()
        {
            return data.Pop();
        }

        public int Peek()
        {
            return data.Peek();
        }

        public bool Empty()
        {
            return data.Count == 0;
        }
    }
}
