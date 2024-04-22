using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class OddEvenLinkedList
    {
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) return head;
            ListNode i = head;
            ListNode j = head.next;
            if (j == null) return head;
            i.next = null;
            ListNode evenHead = j;
            int x = 3;
            ListNode cur = j.next;
            j.next = null;

            while (cur != null)
            {
                if (x % 2 == 0)
                {
                    j.next = cur;
                    cur = cur.next;

                    j = j.next;
                    j.next = null;
                }
                else
                {
                    i.next = cur;
                    cur = cur.next;

                    i = i.next;
                    i.next = null;
                }
                x++;                
            }

            i.next = evenHead;
            return head;
        }
    }
}
