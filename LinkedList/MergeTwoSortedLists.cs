using System;
using DataStructure;

namespace LinkedList
{
    public class MergeTwoSortedListsIterationSolution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) { return list2; }
            else if (list2 == null) { return list1; }

            ListNode fackHead = new ListNode(-1000);
            ListNode i = fackHead;
            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    i.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    i.next = list2;
                    list2 = list2.next;
                }
                i = i.next;
            }

            if (list1 == null) { i.next = list2; }
            else if (list2 == null) { i.next = list1; }

            return fackHead.next;
        }
    }

    public class MergeTwoSortedListsRecursionSolution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            return MergeRecursively(list1, list2);
        }

        private ListNode MergeRecursively(ListNode l1, ListNode l2)
        {
            ListNode fackHead = new ListNode(-1000);

            if (l1 == null) { fackHead.next = l2; }
            else if (l2 == null) { fackHead.next = l1; }
            else if (l1.val <= l2.val)
            {
                ListNode i = fackHead;
                i.next = l1;
                i = i.next;
                l1 = l1.next;

                i.next = MergeRecursively(l1, l2);
            }
            else
            {
                ListNode i = fackHead;
                i.next = l2;
                i = i.next;
                l2 = l2.next;

                i.next = MergeRecursively(l1, l2);
            }
            return fackHead.next;
        }

    }

}
