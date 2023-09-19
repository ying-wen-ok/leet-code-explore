using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class MyStack
    {
        Queue<int> data;
        public MyStack()
        {
            data = new Queue<int>();
        }

        public void Push(int x)
        {
            Queue<int> temp = new Queue<int>();
            while (data.Count > 0)
            {
                temp.Enqueue(data.Dequeue());
            }

            data.Enqueue(x);

            while (temp.Count > 0)
            {
                data.Enqueue(temp.Dequeue());
            }
        }

        public int Pop()
        {
            return data.Dequeue();
        }

        public int Top()
        {
            return data.Peek();
        }

        public bool Empty()
        {
            return data.Count == 0;
        }
    }

}
