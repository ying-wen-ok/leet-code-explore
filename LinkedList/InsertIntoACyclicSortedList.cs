using System;
using DataStructure;

namespace LinkedList
{
    public class InsertIntoACyclicSortedList
    {
        public Node Insert(Node head, int insertVal)
        {
            Node inserNode = new Node(insertVal);
            if (head == null)
            {
                inserNode.next = inserNode;
                return inserNode;
            }
            if (head.next == head)
            {
                head.next = inserNode;
                inserNode.next = head;
                return head;
            }

            (Node smallestNode, Node biggestNode) = FindTheSmallestNode(head);

            if (insertVal <= smallestNode.val || insertVal >= biggestNode.val)
            {
                inserNode.next = smallestNode;
                biggestNode.next = inserNode;
            }
            else
            {
                (Node FirstBiggerNode, Node preNode) = FindTheFirstBiggerNode(smallestNode, insertVal);

                inserNode.next = FirstBiggerNode;
                preNode.next = inserNode;
            }
            return head;
        }

        // minimal lenth of the list of nodes is 2
        private (Node smallestNode, Node biggestNode) FindTheSmallestNode(Node head)
        {
            Node i = head;
            Node j = head.next;

            while (j != head && j.val >= i.val)
            {
                i = i.next;
                j = j.next;
            }

            return (j, i);
        }

        private (Node FirstBiggerNode, Node preNode) FindTheFirstBiggerNode(Node smallestNode, int insertVal)
        {
            Node i = smallestNode;
            Node j = smallestNode.next;

            while (j != smallestNode)
            {
                if (j.val >= insertVal) break;
                i = i.next;
                j = j.next;
            }

            return (j, i);
        }
    }
}
