using System;
using DataStructure;

namespace LinkedList
{
    public class FlattenAMultilevelDoublyLinkedList
    {
        public Node Flatten(Node head)
        {
            Node fakeHead = new Node(-1);
            Node i = fakeHead;
            i.next = head;
            FlattenRecursively(i);
            return fakeHead.next;
        }

        private void FlattenRecursively(Node i)
        {
            if (i == null) return;

            if (i.child == null)
            {
                FlattenRecursively(i.next);
                return;
            }

            Node next = i.next;
            Node firstChild = i.child;
            i.child = null;

            FlattenRecursively(firstChild);

            i.next = firstChild;
            firstChild.prev = i;

            if (next == null) return;

            Node lastChild = firstChild;
            while (lastChild.next != null) { lastChild = lastChild.next; }

            lastChild.next = next;
            next.prev = lastChild;

            FlattenRecursively(next);
        }

    }
}
