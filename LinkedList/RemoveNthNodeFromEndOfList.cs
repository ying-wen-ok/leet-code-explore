using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class RemoveNthNodeFromEndOfList
    {
        public ListNode RemoveNthFromEndSolution1(ListNode head, int n)
        {
            Stack<ListNode> s = new Stack<ListNode>();
            ListNode i = head;
            while (i != null)
            {
                s.Push(i);
                i = i.next;
            }

            ListNode pre = null;
            ListNode cur = null; // the node to be deleted
            ListNode next = null;

            while (n >= 0 && s.Count >= 0)
            {
                next = cur;
                cur = pre;
                pre = s.Count > 0 ? s.Pop() : null;
                n--;
            }

            if (pre == null)  head = head.next; 
            else pre.next = next;
            return head;
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            // using 2 pointers p1 and p2. the distance between them is n. they are going to move together with same speed.
            // when p1 arrived at the last element position, then p2.next will be the target to be deleted. bacuase the distance between them is n

            ListNode p1 = head;
            while (n > 0)
            {
                p1 = p1.next;
                n--;
            }
            if (p1 == null) return head.next;

            ListNode p2 = head;
            while (p1.next != null)
            {
                p1 = p1.next;
                p2 = p2.next;
            }
            if (p2.next != null) p2.next = p2.next.next;
            return head;
        }
               
    }
}