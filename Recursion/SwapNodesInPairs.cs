using System;
using System.Collections.Generic;
using DataStructure;

namespace Recursion
{
    public class SwapNodesInPairs
    {
        public ListNode SwapPairs(ListNode head)
        {
            return swapNodeIJ(head);
        }

        private ListNode swapNodeIJ(ListNode i)
        {
            if (i == null) return null;        
            if (i.next == null) return i;
          
            ListNode j = i.next;
            ListNode k = j.next;

            i.next = swapNodeIJ(k);
            j.next = i;

            return j;
        }
    }
}
