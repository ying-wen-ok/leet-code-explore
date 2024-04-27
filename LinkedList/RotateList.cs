using System;
using DataStructure;

namespace LinkedList
{
    public class RotateList
    {
        public ListNode RotateRight(ListNode head, int k)
        {

            List<ListNode> list = new List<ListNode>();
            ListNode cur = head;
            while (cur != null) { list.Add(cur); cur = cur.next; }

            int length = list.Count;
            if (length == 0) return head;

            k = k % length;
            if (k == 0) return head;

            ListNode tail = list[length - 1];
            tail.next = head;

            ListNode newTail = list[length - 1 - k];
            newTail.next = null;

            ListNode newHead = list[length - 1 - k + 1];
            return newHead;
        }
    }
}
