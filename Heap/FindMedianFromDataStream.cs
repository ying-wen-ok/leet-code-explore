using System;
using System.Collections.Generic;

namespace Heap
{
    public class MedianFinder
    {
        private PriorityQueue<double, double> left;
        private PriorityQueue<double, double> right; 
     
        public MedianFinder()
        {
            left = new PriorityQueue<double, double>();
            right = new PriorityQueue<double, double>();
        }

        public void AddNum(int num)
        { 
            if (right.Count == 0 || num >= right.Peek()) right.Enqueue(num,num);
            else { left.Enqueue(num, -num); }

            if(right.Count - left.Count > 1)
            {
                double temp = right.Dequeue();
                left.Enqueue(temp, -temp);
            }
            else if (left.Count > right.Count)
            {
                double temp = left.Dequeue();
                right.Enqueue(temp, temp);
            }
        }

        public double FindMedian()
        {
           if((left.Count + right.Count) % 2 == 0)
           {
                return (left.Peek() + right.Peek()) / 2;
            }
           else
           {
                return right.Peek();
            }            
        }
    }

}
