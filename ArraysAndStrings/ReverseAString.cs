﻿using System;
using System.Collections.Generic;

namespace ArraysAndStrings
{
    public class ReverseAString
    {
        public void ReverseString(char[] s)
        {
            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                char temp = s[i];
                s[i] = s[j];
                s[j] = temp;

                i++;
                j--;
            }
        }
    }
}
