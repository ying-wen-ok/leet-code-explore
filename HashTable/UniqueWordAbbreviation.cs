using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    /// <Describtion>
    /// You can use the below problem statement if the original one on leetcode sounds twisting for you.
    /// 
    /// The abbreviation of a word is a concatenation of its first letter, 
    /// the number of characters between the first and last letter, and its last letter. 
    /// If a word has less than 3 characters, then it is an abbreviation of itself.
    /// 
    /// Implement the ValidWordAbbr class.
    /// 
    /// ValidWordAbbr(String[] dictionary) :  
    ///     Initializes the object with a dictionary of words.
    ///       
    /// boolean isUnique(string word)     
    /// 
    ///     Returns false if and only if:
    ///             In dictionary, there is same abbreviation, 
    ///             and olny one word exsit for this abbreviation, 
    ///             and this word in dictionary is different with the word of input
    /// </Describtion>
    public class ValidWordAbbr
    {
        private Dictionary<string, HashSet<string>> dict;
        public ValidWordAbbr(string[] dictionary)
        {
            dict = new Dictionary<string, HashSet<string>>();

            foreach(string word in dictionary)
            {
                string key = GetKey(word);
                dict.TryAdd(key, new HashSet<string>());
                dict[key].Add(word);
            }
        }

        public bool IsUnique(string word)
        {
            string key = GetKey(word);
            if (!dict.ContainsKey(key)) return true;
            if (dict[key].Count > 1) return false;
            if (dict[key].Contains(word)) return true;
            return false;
        }

        private string GetKey(string word)
        {
            int n = word.Length;
            if (n < 3) return word;
            StringBuilder sb = new StringBuilder();
            sb.Append(word[0]);
            sb.Append(n - 2);
            sb.Append(word[n - 1]);

            return sb.ToString();
        }
    }
}
