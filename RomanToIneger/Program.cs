﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanToIneger
{
    /*
        Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

        Symbol       Value
        I             1
        V             5
        X             10
        L             50
        C             100
        D             500
        M             1000

        For example, 2 is written as II in Roman numeral, just two one's added together. 
        12 is written as XII, which is simply X + II. 
        The number 27 is written as XXVII, which is XX + V + II.

        Roman numerals are usually written largest to smallest from left to right. 
        However, the numeral for four is not IIII. Instead, the number four is written as IV. 
        Because the one is before the five we subtract it making four. 
        The same principle applies to the number nine, which is written as IX. 
        There are six instances where subtraction is used:

        I can be placed before V (5) and X (10) to make 4 and 9. 
        X can be placed before L (50) and C (100) to make 40 and 90. 
        C can be placed before D (500) and M (1000) to make 400 and 900.
        Given a roman numeral, convert it to an integer.

     */
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>()
            {
                "IV",           //4
                "IX",           //9
                "LVIII",        //58
                "MCMXCIV",      //1994
            };

            Solution solution = new Solution();
            strings.ForEach(s => {
                Console.WriteLine($"String: ({s}) Result: ({solution.RomanToInt(s)})");
            });
        }

        public class Solution
        {
            public int RomanToInt(string s)
            {

                Dictionary<char, int> dict = new Dictionary<char, int>() 
                {
                    {' ', 0 },
                    {'I', 1},
                    {'V', 5},
                    {'X', 10},
                    {'L', 50},
                    {'C', 100},
                    {'D', 500},
                    {'M', 1000}
                };

                char[] arr = s.ToCharArray();
                int result = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    char v1 = arr[i]; 
                    char v2 = i + 1 < arr.Length ? arr[i+1] : ' ';


                    char[] seq = new char[] { v1, v2 };
                    if (IsSubtract(seq))
                    {
                        result = DoSub(result, dict[seq[0]], dict[seq[1]]);
                        i++;
                    }
                    else
                    {
                        result = DoAdd(result, dict[seq[0]]);
                    }
                }
                return result;
            }

            public bool IsSubtract(char[] chars)
            {
                bool sub = false;

                if (
                        chars.SequenceEqual(new char[] { 'I', 'V' }) 
                        || chars.SequenceEqual(new char[] { 'I', 'X' }) 
                        || chars.SequenceEqual(new char[] { 'X', 'L' }) 
                        || chars.SequenceEqual(new char[] { 'X', 'C' }) 
                        || chars.SequenceEqual(new char[] { 'C', 'D' }) 
                        || chars.SequenceEqual(new char[] { 'C', 'M' }) 
                    )
                {
                    sub = true;
                }

                return sub;
            }

            public int DoAdd(int v, int n)
            {
                return v + n;
            }
            public int DoSub(int v, int n1, int n2)
            {
                return v + (n2 - n1);
            }
        }
    }
}
