using System;
using System.Text;

namespace Recursion
{
    public class LetterCombinationsOfAPhoneNumbe
    {
        private int n;
        private bool[,] used;
        private List<string> combinations = new List<string>();
        public IList<string> LetterCombinations(string digits)
        {
            n = digits.Length;
            if (n == 0) { return new List<string>(); }
            used = new bool[n, 4];
            SetCharsDict();
            SetPositions(digits);
            fill(0);

            return combinations;
        }

        private List<char>[] dict = new List<char>[10];
        private void SetCharsDict()
        {
            dict[2] = new List<char>() { 'a', 'b', 'c' };
            dict[3] = new List<char>() { 'd', 'e', 'f' };
            dict[4] = new List<char>() { 'g', 'h', 'i' };
            dict[5] = new List<char>() { 'j', 'k', 'l' };
            dict[6] = new List<char>() { 'm', 'n', 'o' };
            dict[7] = new List<char>() { 'p', 'q', 'r', 's' };
            dict[8] = new List<char>() { 't', 'u', 'v' };
            dict[9] = new List<char>() { 'w', 'x', 'y', 'z' };
        }

        int[] digit;
        private void SetPositions(string digits)
        {
            digit = new int[n];
            for (int i = 0; i < n; i++)
                digit[i] = Convert.ToInt32(digits[i].ToString());
        }

        StringBuilder cur = new StringBuilder();
        private void fill(int position)
        {
            if (position == n)
            {
                combinations.Add(cur.ToString());
                return;
            }

            var candidates = dict[digit[position]];
            int m = candidates.Count;
            for (int i = 0; i < m; i++)
            {
                char candidate = candidates[i];
                if (used[position, i]) continue;

                used[position, i] = true;
                cur.Append(candidate);

                fill(position + 1);

                used[position, i] = false;
                cur.Remove(cur.Length - 1, 1);
            }
        }
    }

}
