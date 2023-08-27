using System;
using System.Collections.Generic;

namespace Recursion
{
    public class PascalsTriangleII
    {       
        public IList<int> GetRow(int rowIndex)
        {
            IList<int> cur = new int[rowIndex + 1];
            cur[0] = 1;
            cur[rowIndex] = 1;
            if (rowIndex == 0) { 
                return cur; 
            }                 

            IList<int> pre = GetRow(rowIndex - 1);
            for(int i = 1; i < rowIndex; i++) {  
                cur[i] = pre[i - 1] + pre[i];   
            }
            return cur;
        }
        
    }
}
