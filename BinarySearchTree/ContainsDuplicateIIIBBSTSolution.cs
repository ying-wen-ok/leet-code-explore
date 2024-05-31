using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class ContainsDuplicateIIIBBSTSolution
    {
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
        {
            int n = nums.Length;
            SortedList<int, int> list = new SortedList<int, int>(); // numbers in the current window(sliding window); Key: number, Value: count of the numbers of this value
            if (n == 0) return false;
            Add(ref list, nums[0]);

            for (int i = 1; i <= indexDiff && i < n; i++)
            {
                if (FindVidaValueInCurrentWindow(ref list, nums[i], valueDiff)) return true;
                Add(ref list, nums[i]);
            }

            for (int i = indexDiff + 1; i < n; i++)
            {
                int indexOfNumberToRemoveFromCurrentWindow = i - (indexDiff + 1);
                Delete(ref list, nums[indexOfNumberToRemoveFromCurrentWindow]);
                if (FindVidaValueInCurrentWindow(ref list, nums[i], valueDiff)) return true;
                Add(ref list, nums[i]);
            }

            return false;
        }

        private void Add(ref SortedList<int, int> list, int key)
        {
            list.TryAdd(key, 0);
            list[key]++;
        }

        private void Delete(ref SortedList<int, int> list, int key)
        {
            if (!list.ContainsKey(key)) return;

            list[key]--;
            if (list[key] == 0) list.Remove(key);
        }

        private (int, int) BinarySearchForTwoNearestNeighbors(ref SortedList<int, int> list, int number)
        {
            var keys = list.Keys;
            int n = keys.Count;
            int mid;
            int left = 0;
            int right = n - 1;

            while (left <= right)
            {
                mid = (left + right) / 2;

                if (keys[mid] == number) { return (number, number); }
                else if (keys[mid] < number) { left = mid + 1; }
                else if (keys[mid] > number) { right = mid - 1; }
            }

            if (left < n && right >= 0) return (keys[left], keys[right]);
            else if (left < n) return (keys[left], keys[left]);
            else return (keys[right], keys[right]);
        }

        private bool FindVidaValueInCurrentWindow(ref SortedList<int, int> list, int number, int valueDiff)
        {
            (int biggerNeighbor, int smallerNeighbor) = BinarySearchForTwoNearestNeighbors(ref list, number);

            return Math.Abs(biggerNeighbor - number) <= valueDiff
                || Math.Abs(smallerNeighbor - number) <= valueDiff
                ;
        }
    }
}
