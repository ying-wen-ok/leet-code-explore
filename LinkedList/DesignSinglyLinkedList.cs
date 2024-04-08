using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;

namespace LinkedList
{
    public class MyLinkedList
    {
        private ListNode head;

        public MyLinkedList()
        {
            head = null;
        }

        public int Get(int index)
        {
            ListNode targetNode = searchNodeByIndex(index);
            if (targetNode == null) return -1;
            return targetNode.val;
        }

        public void AddAtHead(int val)
        {
            ListNode newHead = new ListNode(val, head);          
            
            head = newHead;
        }

        public void AddAtTail(int val)
        {
            ListNode newNode = new ListNode(val);
            if (head == null) head = newNode;
            else
            {
                ListNode findTail = head;
                while (findTail.next != null) findTail = findTail.next;
                findTail.next = newNode;
            }
        }

        public void AddAtIndex(int index, int val)
        {
            if (index == 0) { AddAtHead(val); return; }
           
            ListNode preNode = searchNodeByIndex(index - 1);

            if (preNode == null) return;          
            ListNode nextNode = preNode.next;

            ListNode curNode = new ListNode(val, nextNode);
            preNode.next = curNode;
        }

        public void DeleteAtIndex(int index)
        {
            if (head == null) { return; }
            if (index == 0) { head = head.next; return; }

            ListNode preNode = searchNodeByIndex(index - 1);
            if (preNode == null) return;
            ListNode nextNode = preNode.next;
            if (nextNode != null) preNode.next = nextNode.next;
        }

        private ListNode searchNodeByIndex(int index)
        {
            ListNode cur = head;
            while (index >= 0 && cur != null)
            {
                if (index == 0) return cur;
                cur = cur.next;
                index--;              
            }
            return null;
        }
    }

}
