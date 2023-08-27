using DataStructure;
using System;
using System.Collections.Generic;

namespace Recursion
{
    public class ReverseLinkedList
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null) return null;
            Reverse(head);
            return tail;
        }

        ListNode tail = null;
        private void Reverse(ListNode node1)
        {
            ListNode node2 = node1.next;
            node1.next = null;  // break the linkage
           
            if (node2 == null)
            {
                tail = node1;
                return;
            }
                   
            Reverse(node2); 
            node2.next = node1;    // re-build the linkage
        }
    }
    
}
