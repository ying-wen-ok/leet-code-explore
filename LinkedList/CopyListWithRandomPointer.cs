using DataStructure;
using System;

namespace LinkedList
{
    public class CopyListWithRandomPointer
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;

            // key: original node, value : newly created node
            Dictionary<Node, Node> dict = new Dictionary<Node, Node>();

            Node newHead = new Node(head.val);
            Node pre = newHead;
            Node original = head.next;
            dict.Add(head, newHead);

            while (original != null)
            {
                Node copy = new Node(original.val);
                dict.Add(original, copy);

                pre.next = copy;

                pre = pre.next;
                original = original.next;
            }

            Node i = head;
            Node j = newHead;
            while (i != null)
            {
                if (i.random != null)
                {
                    Node originalRandom = i.random;
                    Node copyOfTheOriginalRandom = dict[originalRandom];
                    j.random = copyOfTheOriginalRandom;
                }

                i = i.next;
                j = j.next;
            }

            return newHead;
        }
    }
}
