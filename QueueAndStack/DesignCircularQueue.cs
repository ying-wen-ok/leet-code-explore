using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class MyCircularQueue
    {
        private int[] data;
        private int head;
        private int tail;
        private int size;

        //  Initializes the object with the size of the queue to be k.       
        public MyCircularQueue(int k)
        {
            size = k;
            data = new int[k];
            head = -1;
            tail = -1;
        }

        // Inserts an element into the circular queue.
        // Return true if the operation is successful.      
        public bool EnQueue(int value)
        {
            if (IsFull()) return false;
            if (IsEmpty()) head = 0;
            tail = (tail + 1) % size;
            data[tail] = value;

            return true;
        }

        // Deletes an element from the circular queue.
        // Return true if the operation is successful.
        public bool DeQueue()
        {
            if (IsEmpty()) return false;
            if (head == tail)
            {
                head = -1;
                tail = -1;
            }
            else
            {
                head = (head + 1) % size;
            }
            return true;
        }

        // Gets the front item from the queue. If the queue is empty, return -1.
        public int Front()
        {
            if (IsEmpty()) return -1;
            return data[head];
        }

        // Gets the last item from the queue. If the queue is empty, return -1.
        public int Rear()
        {
            if (IsEmpty()) return -1;
            return data[tail];
        }

        // Checks whether the circular queue is empty or not.
        public bool IsEmpty()
        {
            return head == -1 && tail == -1;
        }

        // Checks whether the circular queue is full or not.
        public bool IsFull()
        {
            return (tail + 1) % size == head;
        }
    }
}

