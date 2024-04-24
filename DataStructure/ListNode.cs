using System;

namespace DataStructure
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode prev;
        public ListNode(int val = -1, ListNode next = null, ListNode prev = null)
        {
            this.val = val;
            this.next = next;
            this.prev = prev;
        }
    }
}
