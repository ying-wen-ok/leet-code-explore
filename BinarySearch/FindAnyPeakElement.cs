using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public class FindAnyPeakElement
    {
        public int FindPeakElement(int[] arr)
        {
            int n = arr.Length;
            if (n == 1) return 0;

            int start = 0;
            int end = n - 1;
            int i;
            while (start <= end)
            {
                i = (start + end) / 2;

                if (i == n - 1) return (arr[n - 1] > arr[n - 2]) ? n - 1 : n - 2; 

                if (isDescending(arr, i)) end = i - 1;
                else start = i + 1;
            }

            return start;
        }

        private bool isDescending(int[] arr, int i)
        {
            return arr[i + 1] < arr[i];
        }
    }
}
