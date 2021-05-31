using System;
using System.Collections.Generic;

namespace NextPermutation
{
    /*
        Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

        If such an arrangement is not possible, it must rearrange it as the lowest possible order (i.e., sorted in ascending order).

        The replacement must be in place and use only constant extra memory.

        Constraints:

        1 <= nums.length <= 100
        0 <= nums[i] <= 100

        https://en.wikipedia.org/wiki/Lexicographic_order

        https://medium.com/trick-the-interviwer/next-greater-permutation-bb12e014e797
     */
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            List<int[]> list = new List<int[]>()
            {
                // { new int[] { 1, 2, 3 } }, // Output: [1,3,2]
                // { new int[] { 3, 2, 1} }, // Output: [1,2,3]
                // { new int[] { 1, 1, 5} }, // Output: [1,5,1]
                // { new int[] { 1 } } // Output: [1]
                { new int[] {2, 3, 1} } // Output: 
            };

            list.ForEach(arr => solution.NextPermutation(arr));
        }

        public class Solution
        {
            public void NextPermutation(int[] nums)
            {
                if (nums.Length < 2)
                    return;

                int firstDecreasing = -1;

                for(int i = nums.Length -2; i>= 0; i--)
                {
                    if(nums[i] < nums[i + 1]){
                        firstDecreasing = i;
                        break;
                    }
                }

                if(firstDecreasing != -1)
                {
                    int temp = -1;
                    for(int i = firstDecreasing+1; i < nums.Length; i++)
                    {
                        if(nums[i] > nums[firstDecreasing])
                        {
                            if(temp != -1 && nums[temp] < nums[i])
                            {
                                //Do nothing.. 
                            }
                            else
                            {
                                temp = i;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    int current = nums[temp];
                    nums[temp] = nums[firstDecreasing];
                    nums[firstDecreasing] = current;
                }
                else
                {
                    Array.Reverse(nums);
                }   
            }
        }
    }
}
