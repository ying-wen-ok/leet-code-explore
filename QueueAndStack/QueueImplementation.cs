using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class QueueImplementation
    {
        private int headIndex;
        private List<int> data;
        public QueueImplementation()
        {
            headIndex = 0;
            data = new List<int>();
        }

        public void Enqueue(int i)
        {
            data.Add(i);
        }

        public int? Dequeue()
        {
            if (IsQueueEmpty()) return null;
            int headElement = data[headIndex];
            headIndex--;
            return headElement;
        }

        public int? Peek()
        {
            if (IsQueueEmpty()) return null;
            return data[headIndex];
        }

        private bool IsQueueEmpty()
        {
            return headIndex >= data.Count;
        }
    }
}
