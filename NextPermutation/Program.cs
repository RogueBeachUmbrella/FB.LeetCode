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
                //{ new int[] { 1, 2, 3 } }, // Output: [1,3,2]
                //    // num[2] ->  num[1]
                //    
                //{ new int[] { 3, 2, 1} }, // Output: [1,2,3]
                //    // None -> reverse
                //    
                //{ new int[] { 1, 1, 5} }, // Output: [1,5,1]
                //    // num[2] -> num[1]
                //
                //{ new int[] { 1 } }, // Output: [1]
                //
                //{ new int[] { 2, 3, 1 } }, 
                //    /*
                //                            [2,3,1]
                //        num[2] <-> num[1] = [2,1,3]
                //        num[2] <-> num[0] = [3,1,2]
                //     */
                //
                //{ new int[] { 1, 3, 2} } 
                /*
                                       [1,3,2]
                    num[2] -> num[1] = [1,2,3]
                    num[1] -> num[0] = [2,1,3]
                 */
                { new int[] { 2,2,7,5,4,3,2,2,1} } // [2,3,1,2,2,2,4,5,7]

            };

            list.ForEach(arr => solution.NextPermutation(arr));
        }

        public class Solution
        {
            public void NextPermutation(int[] nums)
            {
                if (nums.Length < 2)
                    return;

                int i = nums.Length - 2;
                while (i >= 0 && nums[i + 1] <= nums[i])
                {
                    i--;
                }

                if (i >= 0)
                {
                    int j = nums.Length - 1;
                    while (nums[j] <= nums[i])
                    {
                        j--;
                    }
                    Swap(nums, i, j);
                }
                Reverse(nums, i + 1);
            }

            public void Reverse(int[] nums, int start)
            {
                int i = start;
                int j = nums.Length - 1;

                while (i < j)
                {
                    Swap(nums, i, j);
                    i++;
                    j--;
                }
            }

            public void Swap(int[] nums, int i, int j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }
    }
}
