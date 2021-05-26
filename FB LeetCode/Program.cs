using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        /* Description: Given a string s, find the length of the longest substring without repeating characters.

            Example 1:
                Input: s = "abcabcbb"
                Output: 3
                Explanation: The answer is "abc", with the length of 3.
            Example 2:
                Input: s = "bbbbb"
                Output: 1
                Explanation: The answer is "b", with the length of 1.
            Example 3:
                Input: s = "pwwkew"
                Output: 3
                Explanation: The answer is "wke", with the length of 3.
                Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
            Example 4:
                Input: s = ""
                Output: 0
 
            Constraints:
                0 <= s.length <= 5 * 104
                s consists of English letters, digits, symbols and spaces.
         */
        static void Main(string[] args)
        {
            List<string> strings = new List<string>()
            {
                "abcabcbb",
                "bbbbb",
                "pwwkew",
                "",
                "aab",
                " ",
                "au"
            };

            Solution solution = new Solution();
            strings.ForEach(s => {
                Console.WriteLine();
                int length = solution.LengthOfLongestSubstring(s);
                Console.WriteLine($"String:({s}) Length:({length})");
            });
        }
        public class Solution
        {
            /* Success:
                Runtime: 92 ms, faster than 49.60% of C# online submissions for Longest Substring Without Repeating Characters.
                Memory Usage: 26.7 MB, less than 17.21% of C# online submissions for Longest Substring Without Repeating Characters.
             */
            public int LengthOfLongestSubstring(String s)
            {
                Dictionary<char, int> dict = s.ToHashSet().ToDictionary(k => k, v => -1);

                int left = 0;
                int right = 0;

                int res = 0;
                while (right < s.Length)
                {                
                    char r = s[right];
                    int index = dict[r];

                    if (index != -1 && index >= left && index < right)
                    {
                        left = index + 1;
                    }

                    res = Math.Max(res, right - left + 1);

                    dict[r] = right;
                    right++;
                }
                return res;
            }
        }
    }
}
