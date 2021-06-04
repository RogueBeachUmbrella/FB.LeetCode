using System;
using System.Collections.Generic;

namespace MaxSubArray
{
    class Program
    {
        /*
            Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

            Example 1:

            Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
            Output: 6
            Explanation: [4,-1,2,1] has the largest sum = 6.
            
            Example 2:

            Input: nums = [1]
            Output: 1
            
            Example 3:

            Input: nums = [5,4,-1,7,8]
            Output: 23
 

            Constraints:

            1 <= nums.length <= 3 * 104
            -105 <= nums[i] <= 105
 
         */
        static void Main(string[] args)
        {
            List<int[]> list = new List<int[]>() {
                { new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 } },
                { new int[] { 1 } },
                { new int[] { 5, 4, -1, 7, 8 } }
            };

            Solution solution = new Solution();
            list.ForEach(arr => solution.MaxSubArray(arr));
        }

        public class Solution
        {
            public int MaxSubArray(int[] nums)
            {

                (int buy, int sell, int profit) = FindMaxSubarray(nums, 0, nums.Length - 1);

                Console.WriteLine($"Buy: ({buy}) Sell: ({sell}) Max Profit: ({profit})");

                return profit;
            }

            public (int maxLeft, int maxRight, int sum) FindMaxSubarray(int[] nums, int low, int high)
            {
                if(high == low)
                {
                    return (low, high, nums[low]);
                }

                int mid = (low + high) / 2; 

                (int leftLow, int leftHigh, int leftSum) = FindMaxSubarray(nums, low, mid);
                (int rightLow, int rightHigh, int rightSum) = FindMaxSubarray(nums, mid + 1, high);
                (int crossLow, int crossHigh, int crossSum) = FindMaxCrossingSubarray(nums, low, mid, high);

                if(leftSum >= rightSum && leftSum >= crossSum)
                {
                    return (leftLow, leftHigh, leftSum);
                }
                else if(rightSum >= leftSum && rightSum >= crossSum)
                {
                    return (rightHigh, rightLow, rightSum);
                }
                else
                {
                    return (crossLow, crossHigh, crossSum);
                }
            }


            public (int maxLeft, int maxRight, int sum) FindMaxCrossingSubarray(int[] nums, int low, int mid, int high)
            {

                int sum;
                int maxLeft = low;
                int maxRight = high;

                sum = 0;
                int leftSum = 0;
                for (int i = mid; i >= 0; i--)
                {
                    sum = sum + nums[i];
                    if (sum > leftSum)
                    {
                        leftSum = sum;
                        maxLeft = i;
                    }
                }

                sum = 0;
                int rightSum = 0;
                for (int j = mid + 1; j < nums.Length; j++)
                {
                    sum = sum + nums[j];
                    if (sum > rightSum)
                    {
                        rightSum = sum;
                        maxRight = j;
                    }
                }

                return (maxLeft, maxRight, leftSum + rightSum);
            }
        }
    }
}
