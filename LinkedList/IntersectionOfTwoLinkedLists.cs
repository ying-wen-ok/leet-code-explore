using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class IntersectionOfTwoLinkedLists
    {
        public ListNode GetIntersectionNodeSolutiuon1(ListNode headA, ListNode headB)
        {
            ListNode a = headA;           
            while (a != null)
            {
                ListNode b = headB;
                while (b != null)
                {
                    if (a == b) return a;
                    b = b.next;
                }
                a = a.next;
            }
            return null;
        }

        public ListNode GetIntersectionNodeSolutiuon2(ListNode headA, ListNode headB)
        {
            HashSet<ListNode> aSet = new HashSet<ListNode>();
            ListNode a = headA;
            while (a != null){ aSet.Add(a); a = a.next; }

            ListNode b = headB;
            while (b != null)
            {
                if (aSet.Contains(b)) return b;
                b = b.next;                
            }
            return null;
        }
    }
}
