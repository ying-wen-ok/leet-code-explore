using DataStructure;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Recursion
{
    internal class MergeTwoSortedLists
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode head = new ListNode();
            Merge(head, list1, list2);
            return head.next;
        }

        private void Merge(ListNode head, ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
            {
                head.next = l1 == null ? l2 : l1;
                return;
            }

            if (l1.val <= l2.val) 
            { 
                head.next = l1; 
                l1 = l1.next; 
            }
            else 
            { 
                head.next = l2; 
                l2 = l2.next; 
            }

            Merge(head.next, l1, l2);
        }
    }
}
