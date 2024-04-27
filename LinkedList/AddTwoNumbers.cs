using System;
using DataStructure;

namespace LinkedList
{
    public class AddTwoNumbersSolution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode fakeHead = new ListNode(-1);
            ListNode i = fakeHead;
            int carry = 0;
            while (l1 != null || l2 != null)
            {
                int d1 = 0;
                int d2 = 0;
                if (l1 != null) { d1 = l1.val; l1 = l1.next; }
                if (l2 != null) { d2 = l2.val; l2 = l2.next; }

                int sum = carry + d1 + d2;
                carry = sum / 10;

                i.next = new ListNode(sum % 10);
                i = i.next;
            }
            if (carry > 0) i.next = new ListNode(carry);
            return fakeHead.next;
        }
    }
}
