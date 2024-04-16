using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedListCycleII
    {
        /// <summary>
        /// solve it using O(n) memory?
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle_O_N_memory(ListNode head)
        {         
            ListNode i = head;
            HashSet<ListNode> visited = new HashSet<ListNode>();

            while(i != null)
            {
                if (visited.Contains(i)) { return i; }

                visited.Add(i);
                i = i.next;
            }

            return null;
        }

        public ListNode DetectCycle_O_1_memory(ListNode head)
        {
            ListNode? firstMeetingNode = HasCycle(head);
            if (firstMeetingNode == null) return null; // if there is no cycle

            ListNode a = head;
            ListNode b = firstMeetingNode;

            while (a != b)
            {
               a = moveForward(a, 1);
               b = moveForward(b, 1);
            }

            return a;
        }

        private ListNode? HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while(slow != null && fast != null)
            {
                slow = moveForward(slow, 1);
                fast = moveForward(fast, 2);

                if (slow == fast && slow != null) return fast;
            }
            return null;
        }

        private ListNode moveForward(ListNode node, int countOfSteps)
        {
            while(countOfSteps > 0 && node != null)
            {
                node = node.next;
                countOfSteps --;
            }

            return node;
        }
    }
}
