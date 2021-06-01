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
                    // num[2] ->  num[1]
                    
                //{ new int[] { 3, 2, 1} }, // Output: [1,2,3]
                    // None -> reverse
                    
                //{ new int[] { 1, 1, 5} }, // Output: [1,5,1]
                    // num[2] -> num[1]

                //{ new int[] { 1 } }, // Output: [1]

                //{ new int[] { 2, 3, 1 } }, 
                    /*
                                            [2,3,1]
                        num[2] <-> num[1] = [2,1,3]
                        num[2] <-> num[0] = [3,1,2]
                     */

                { new int[] { 1, 3, 2} } 
                    /*
                                           [1,3,2]
                        num[2] -> num[1] = [1,2,3]
                        num[1] -> num[0] = [2,1,3]
                     */

            };

            list.ForEach(arr => solution.NextPermutation(arr));
        }

        public class Solution
        {
            public void NextPermutation(int[] nums)
            {
                if (nums.Length < 2)
                    return;

                Console.Write("Input: ");
                foreach (int i in nums)
                {
                    Console.Write("{0} ", i);
                }

                int firstDecreasing = FirstDecreasing(nums);

                if (firstDecreasing != -1)
                {
                    int temp = firstDecreasing + 1;
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (nums[i] < nums[firstDecreasing])
                        {
                            if (temp != -1 && nums[temp] > nums[i])
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
                


                if (firstDecreasing == -1)
                {
                    Array.Reverse(nums);
                }

                Console.Write("Output: ");
                foreach (int i in nums)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine();

            }

            public int FirstDecreasing(int[] nums)
            {
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    if (nums[i] < nums[i - 1])
                    {
                        return i - 1;
                    }
                }
                return -1;
            }

            public int PositionsToShift(int[] nums, int firstDescending)
            {
                int pos = firstDescending - 1;
                while(nums[firstDescending] < nums[pos])
                {
                    pos++;
                }

                return -pos;
            }












            public void NextPermutation2(int[] nums)
            {
                if (nums.Length < 2)
                    return;

                Console.Write("Input: ");
                foreach (int i in nums)
                {
                    Console.Write("{0} ", i);
                }

                int firstDecreasing = -1;
                for(int i = nums.Length - 2; i >= 0; i--) 
                {
                    if(nums[i] < nums[i + 1] && firstDecreasing == -1)
                    {
                        firstDecreasing = i + 1;
                        int temp = nums[i];
                        nums[i] = nums[firstDecreasing];
                        nums[firstDecreasing] = temp;
                        i++;
                        for (int k = i + 1; k < nums.Length; k++)
                        {
                            if (nums[k] < nums[i])
                            {
                                temp = nums[k];
                                nums[k] = nums[i];
                                nums[i] = temp;
                            }
                            i++;
                        }
                    }
                }

                

                if (firstDecreasing == -1)
                {
                    Array.Reverse(nums);
                }

                Console.Write("Output: ");
                foreach (int i in nums)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine();

            }


            public void NextPermutation1(int[] nums)
            {
                if (nums.Length < 2)
                    return;

                int dec = -1;
                int i = -1;
                for(int j = nums.Length -2; j>= 0; j--)
                {
                    if(nums[j] < nums[j + 1]){
                        i = j;
                        break;
                    }                   
                }

                if (i != -1)
                {
                    int temp = -1;
                    for (int k = i + 1; k < nums.Length; k++)
                    {
                        if (nums[k] > nums[i])
                        {
                            if (temp != -1 && nums[temp] < nums[k])
                            {
                                //Do nothing.. 
                            }
                            else
                            {
                                temp = k;
                                dec = nums[temp];
                            }
                        }
                        //else
                        //{
                        //    break;
                        //}
                    }

                    int current = nums[temp];
                    nums[temp] = nums[i];
                    nums[i] = current;
                    temp = i;
                }

                if (i == -1)
                {
                    Array.Reverse(nums);
                }   
            }
        }
    }
}
