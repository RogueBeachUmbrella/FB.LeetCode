using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3Sum
{
    /*
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

        Constraints:
            0 <= nums.length <= 3000
            -105 <= nums[i] <= 105
             
        Hint #1  
            So, we essentially need to find three numbers x, y, and z such that they add up to the given value. 
            If we fix one of the numbers say x, we are left with the two-sum problem at hand!
        Hint #2  
            For the two-sum problem, if we fix one of the numbers, say
            , we have to scan the entire array to find the next number
            y
            x
            which is
            value - x
            where value is the input parameter. Can we change our array somehow so that this search becomes faster?
        Hint #3  
            The second train of thought for two-sum is, without changing the array, can we use additional space somehow? Like maybe a hash map to speed up the search?
     */
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            List<int[]> arrs = new List<int[]>()
            {
                { new int[] { -1, 0, 1, 2, -1, -4 } }, // Output: [[-1,-1,2],[-1,0,1]]
                { new int[] { } }, // Output: []
                { new int[] { 0 } } //Output: []
            };
            arrs.ForEach(a =>
            {
                IList<IList<int>> result = solution.ThreeSum(a);

                foreach (var array in result)
                    Console.WriteLine(string.Join(" ", array));
            });
        }

        public class Solution
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {              
                Array.Sort(nums);
                HashSet<IList<int>> result = new HashSet<IList<int>>();
                for (int i = 0; i < nums.Length && nums[i] <= 0; i++)
                {
                    if (i == 0 || nums[i - 1] != nums[i])
                    {
                        HashSet<int> seen = new HashSet<int>();
                        for(int j = i + 1; j < nums.Length; j++)
                        {
                            int complement = -nums[i] - nums[j];
                            if (seen.Contains(complement))
                            {
                                int[] set = { nums[i], nums[j], complement };
                                result.Add(set.ToList());
                                while(j + 1 < nums.Length && nums[j] == nums[j + 1])
                                {
                                    j++;
                                }
                            }
                            seen.Add(nums[j]);
                        }
                    }
                }
                return result.ToList();
            }
        }
    }
}
