using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class ReverseLinkedList
    {
        public ListNode ReverseListsolutiuon1(ListNode head)
        {
            ListNode i = head;
            if (i == null) return null;
            Stack<ListNode> s = new Stack<ListNode>();
            while (i != null)
            {
                s.Push(i);
                i = i.next;
            }

            ListNode newHead = s.Pop();
            ListNode cur = newHead;
            while (s.Count > 0)
            {
                ListNode j = s.Pop();
                j.next = null;
                cur.next = j;
                cur = cur.next;
            }

            return newHead;
        }

        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode cur = head;
            ListNode next = cur.next;
            cur.next = null;

            while (next != null)
            {
                ListNode nextNext = next.next;
                next.next = cur;

                (cur, next) = (next, nextNext);
            }
            return cur;
        }
    }

}
