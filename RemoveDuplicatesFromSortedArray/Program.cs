﻿using System;
using System.Collections.Generic;

namespace RemoveDuplicatesFromSortedArray
{
    /*
        Given a sorted array nums, remove the duplicates in-place such that each element appears only once and returns the new length.

        Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

        Clarification:

        Confused why the returned value is an integer but your answer is an array?

        Note that the input array is passed in by reference, which means a modification to the input array will be known to the caller as well.

        Internally you can think of this:

        // nums is passed in by reference. (i.e., without making a copy)
        int len = removeDuplicates(nums);

        // any modification to nums in your function would be known by the caller.
        // using the length returned by your function, it prints the first len elements.
        for (int i = 0; i < len; i++) {
            print(nums[i]);
        }
 

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2]
        Explanation: Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively. It doesn't matter what you leave beyond the returned length.
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4]
        Explanation: Your function should return length = 5, with the first five elements of nums being modified to 0, 1, 2, 3, and 4 respectively. It doesn't matter what values are set beyond the returned length.
 

        Constraints:

        0 <= nums.length <= 3 * 104
        -104 <= nums[i] <= 104
        nums is sorted in ascending order.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            List<int[]> list = new List<int[]>()
            {
                { new int[] { 1,1,2 }}, // Output: 2
                { new int[] { 0,0,1,1,1,2,2,3,3,4 }} // Output: 5
            };
            list.ForEach(a =>
            {
                Console.WriteLine($"Length: ({solution.RemoveDuplicates(a)})");
            });
        }

        public class Solution
        {
            public int RemoveDuplicates(int[] nums)
            {
                int i = 0;
                if (nums.Length == 0)
                {
                    return i;
                }
                for (int j = 1; j < nums.Length; j++)
                {
                    if (nums[j] != nums[i])
                    {
                        i++;
                        nums[i] = nums[j];
                    }
                }
                return i + 1;
            }

            //Review LeetCode to make note of why this was incorrect(ish)..
            //public int RemoveDuplicates(int[] nums)
            //{
            //    for(int i = 0; i < nums.Length - 1; i++)
            //    {
            //        if(nums[i] == nums[i+1])
            //        {
            //            nums[(i+1)..].CopyTo(nums, i);
            //            nums = nums[..^1];
            //            i--;
            //        }
            //    }
            //    return nums.Length;
            //}
        }
    }
}
