using System;
using System.Collections.Generic;

namespace Arrays
{
    public class TheValidMountainArray
    {
        public bool ValidMountainArray(int[] arr)
        {
            int n = arr.Length;
            if (n < 3 ) { return false; }

            bool startToIncrease = false;
            bool startToDecrease = false;

            for (int i = 0; i < n - 1; i++)
            {
                if(arr[i + 1] == arr[i]) { return false; }                
                bool increasing = arr[i + 1] > arr[i];

                if (increasing)
                {
                    if (startToDecrease) { return false; }
                    startToIncrease = true;             
                }
                else
                {
                    if (!startToIncrease) { return false; }
                   startToDecrease = true;                  
                }
            }

            return startToIncrease && startToDecrease;
        }
    }
}
