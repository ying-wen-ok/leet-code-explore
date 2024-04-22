using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class PalindromeLinkedList
    {
        public bool IsPalindromeSolutiuon1(ListNode head)
        {
            Stack<ListNode> tails = new Stack<ListNode>();
            ListNode i = head;
            int lengthOfLinkedList = 1;
            while (i.next != null)
            {
                lengthOfLinkedList++;
                i = i.next;
                tails.Push(i);
            }
            int maxlengthOfOneSide = lengthOfLinkedList / 2;
            while (maxlengthOfOneSide > 0)
            {
                if (head.val != tails.Pop().val) return false;
                head = head.next;
                maxlengthOfOneSide--;
            }

            return true;
        }

        public bool IsPalindromeSolutiuon2(ListNode head)
        {
            int l = getLengthOfTheList(head);

            ListNode i = findTheNodeAtPosition(l / 2, head);
            ListNode tail = reverseList(i);
            
            while (tail != null)
            {
                if (tail.val != head.val) return false;
                tail = tail.next;
                head = head.next;
            }
            return true;
        }

        private int getLengthOfTheList(ListNode head)
        {
            ListNode i = head;
            int lengthOfLinkedList = 1;
            while (i.next != null)
            {
                lengthOfLinkedList++;
                i = i.next;
            }

            return lengthOfLinkedList;
        }
    
        private ListNode findTheNodeAtPosition(int n, ListNode head)
        {
            ListNode i = head;
            while (n > 0 && i.next != null)
            {               
                i = i.next;
                n--;
            }
            return i;
        }

        public ListNode reverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode cur = head;
            ListNode next = cur.next;           
            cur.next = null;

            while (next != null)
            {
                ListNode nextNext = next.next;
                next.next = cur;

                cur = next;
                next = nextNext;
            }
            return cur;
        }
    
    }
}
