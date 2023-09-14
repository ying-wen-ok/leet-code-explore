using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class MovingAverage
    {
        private Queue<int> data;
        private int n;
        private double sum;

        // Initializes the object with the size of the window size.
        public MovingAverage(int size)
        {
            data = new Queue<int>();
            n = size;
            sum = 0;
        }

        // Returns the moving average of the last size values of the stream.
        public double Next(int val)
        {
            sum += val;
            data.Enqueue(val);
            int count = data.Count;
            if (count > n) { sum -= data.Dequeue(); count = n; }
            return sum / count;
        }
    }

}
