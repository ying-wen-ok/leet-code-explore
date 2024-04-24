using System;
using System.Runtime.CompilerServices;
using DataStructure;

namespace LinkedList
{
    public class MyDoublyLinkedList
    {
        private ListNode head;
        private ListNode tail;
        private int length;

        public MyDoublyLinkedList()
        {
            head = null;
            tail = null;
            length = 0;
        }

        public int Get(int index)
        {
            ListNode i = FindAtIndex(index);
            if(i == null) return -1;
            return i.val;
        }

        public void AddAtHead(int val)
        {
            ListNode newHead = new ListNode(val);

            newHead.next = head;
            if (head != null) head.prev = newHead;
            if (tail == null) tail = newHead;
            head = newHead;
            length++;
        }

        public void AddAtTail(int val)
        {
            ListNode newTail = new ListNode(val);
            if (length > 0)
            {
                tail.next = newTail;
                newTail.prev = tail;

                tail = newTail;
            }
            else
            {
                head = newTail;
                tail = newTail;
            }

            length++;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index == 0) { AddAtHead(val); }
            else if (index == length) { AddAtTail(val); }
            else
            {
                ListNode i = FindAtIndex(index);
                if (i == null) return;

                ListNode newNode = new ListNode(val);
                ListNode prev = i.prev;

                prev.next = newNode;
                newNode.prev = prev;

                newNode.next = i;
                i.prev = newNode;
                length++;
            }
        }

        public void DeleteAtIndex(int index)
        {
            if (index == 0) { DeletetHead(); }
            else if (index == length - 1) { DeleteTail(); }
            else
            {
                ListNode i = FindAtIndex(index);
                if (i == null) return;

                ListNode prev = i.prev;
                ListNode next = i.next;

                i.next = null;
                i.prev = null;

                prev.next = next;
                next.prev = prev;
                length--;
            }          
        }
            
        private void DeletetHead()
        {
            if (length == 0) { return; }
            else if (length == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                ListNode newHead = head.next;
                head.next = null;
                newHead.prev = null;

                head = newHead;
            }
            length--;
        }

        private void DeleteTail()
        {
            if (length == 0) { return; }
            else if(length == 1)
            {
                head = null;
                tail = null;
            }
            else
            {         
                tail = tail.prev;
                tail.next = null;
            }
            length--;
        }

        private ListNode FindAtIndex(int index)
        {
            if (index >= length || index < 0) return null;
            ListNode i = head;
            while(index > 0 && i != null)
            {
                i = i.next;
                index--;
            }
            return i;
        }
        
    }    
}
