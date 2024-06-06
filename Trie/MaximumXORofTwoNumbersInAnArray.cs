using System;
using System.Collections;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;


namespace Trie
{
    // XOR
    // 如果a、b两个值不相同，则异或结果为1。
    // 如果a、b两个值相同，异或结果为0。
    public class MaximumXORofTwoNumbersInAnArray
    {
        public int FindMaximumXOR(int[] nums)
        {
            int n = nums.Length;
            string[] binaries = new string[n];
            int treeHeight = 0;
            for (int i = 0; i < n; i++)
            {
                binaries[i] = Convert.ToString(nums[i], 2);
                treeHeight = Math.Max(treeHeight, binaries[i].Length);
            }

            BinaryTrie root = new BinaryTrie(treeHeight);
            foreach (string s in binaries) root.Add(s);

            string[] maxXorResults = new string[n];
            for (int i = 0; i < n; i++) maxXorResults[i] = root.FindMaxXOR(binaries[i]);

            return Convert.ToInt32(maxXorResults.Max(), 2);
        }

    }

    public class BinaryTrie
    {
        private TrieNodeForBinary root;
        private int treeHeight;
        public BinaryTrie(int height)
        {
            root = new TrieNodeForBinary();
            treeHeight = height;
        }

        public void Add(string s)
        {
            int len = s.Length;

            TrieNodeForBinary cur = root;
            for (int i = 0; i < treeHeight - len; i++)
            {
                if (cur.nexts[0] == null) cur.nexts[0] = new TrieNodeForBinary();
                cur = cur.nexts[0];
            }

            for (int i = 0; i < len; i++)
            {
                int index = s[i] - '0';
                if (cur.nexts[index] == null) cur.nexts[index] = new TrieNodeForBinary();
                cur = cur.nexts[index];
            }
        }

        public string FindMaxXOR(string s)
        {
            TrieNodeForBinary cur = root;
            int len = s.Length;
            StringBuilder XORResult = new StringBuilder();

            for (int i = 0; i < treeHeight - len; i++)
            {
                if (cur.nexts[1] != null)
                {
                    cur = cur.nexts[1];
                    XORResult.Append('1');
                }
                else
                {
                    cur = cur.nexts[0];
                    XORResult.Append('0');
                }
            }

            for (int i = 0; i < len; i++)
            {
                int index = s[i] - '0';
                int XOrIndex = index == 0 ? 1 : 0;

                if (cur.nexts[XOrIndex] != null)
                {
                    cur = cur.nexts[XOrIndex];
                    XORResult.Append('1');
                }
                else
                {
                    cur = cur.nexts[index];
                    XORResult.Append('0');
                }
            }

            return XORResult.ToString();
        }
    }

    public class TrieNodeForBinary
    {
        public TrieNodeForBinary[] nexts;

        public TrieNodeForBinary()
        {
            nexts = new TrieNodeForBinary[2];
        }
    }

}
