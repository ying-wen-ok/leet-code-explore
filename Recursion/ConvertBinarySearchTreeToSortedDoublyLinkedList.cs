using DataStructure;
using System;
using System.Collections.Generic;

namespace Recursion
{
    public class ConvertBinarySearchTreeToSortedDoublyLinkedList
    {
        public Node TreeToDoublyList(Node root)
        {
            InorderTraverse(root);
            return ConstructDoubleLinkedList();
        }

        Queue<Node> Q = new Queue<Node>();
        private void InorderTraverse(Node i)
        {
            if (i == null) return;
            InorderTraverse(i.left);
            Q.Enqueue(i);
            InorderTraverse(i.right);
        }

        private Node ConstructDoubleLinkedList()
        {
            if (Q.Count == 0) return null;
            Node head = Q.Dequeue();
            Node cur = head;

            while (Q.Count > 0)
            {
                Node next = Q.Dequeue();

                cur.right = next;
                next.left = cur;

                cur = cur.right;
            }

            cur.right = head;
            head.left = cur;
            return head;
        }
    }
}