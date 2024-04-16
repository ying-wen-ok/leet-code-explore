using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;

namespace LinkedList
{
    public class LinkedListCycle
    {
        public bool HasCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;

            while (fast != null && slow != null)
            {
                fast = move(fast, 2);
                slow = move(slow, 1);
                if (fast == slow && slow != null && fast != null) return true;
            }
            return false;
        }

        private ListNode move(ListNode node, int countOfSteps)
        {
            while (countOfSteps > 0 && node != null)
            {
                countOfSteps--;
                node = node.next;
            }

            return node;
        }
    }
}