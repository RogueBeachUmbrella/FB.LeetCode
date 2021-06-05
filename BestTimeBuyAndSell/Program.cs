using System;
using System.Collections.Generic;

namespace BestTimeBuyAndSell
{
    class Program
    {
        /*
         You are given an array prices where prices[i] is the price of a given stock on the ith day.

        You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

        Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

 

        Example 1:

        Input: prices = [7,1,5,3,6,4]
        Output: 5

        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
        Example 2:

        Input: prices = [7,6,4,3,1]
        Output: 0

        Explanation: In this case, no transactions are done and the max profit = 0.
 

        Constraints:

        1 <= prices.length <= 105
        0 <= prices[i] <= 104
         */

        static void Main(string[] args)
        {
            List<int[]> list = new List<int[]>() {
                //{ new int[] { 7, 1, 5, 3, 6, 4 } },
                { new int[] { 7, 6, 4, 3, 1 } }
            };

            Solution solution = new Solution();
            list.ForEach(arr => solution.BestTimeBuyAndSell(arr));
        }

        public class Solution
        {
            public int BestTimeBuyAndSell(int[] nums)
            {
                if(nums.Length <= 0)
                {
                    return 0;
                }

                (int buy, int sell, int profit) = MaxSubArray(nums, 0, nums.Length - 1);

                Console.WriteLine($"Buy: ({buy}) Sell: ({sell})");
                Console.WriteLine($"Max Profit: ({profit})");

                return profit;
            }

            public (int maxLeft, int maxRight, int sum) MaxSubArray(int[] nums, int low, int high)
            {
                if (high == low)
                {
                    return (low, high, nums[low]);
                }

                int mid = (low + high) / 2;

                (int leftLow, int leftHigh, int leftSum) = MaxSubArray(nums, low, mid);
                (int rightLow, int rightHigh, int rightSum) = MaxSubArray(nums, mid + 1, high);
                (int crossLow, int crossHigh, int crossSum) = MaxCrossingSubarray(nums, low, mid, high);

                //if (crossHigh == 0 && crossLow == 0 && crossSum == 0) 
                //{
                //    return (0, 0, 0);
                //} 
                if(leftSum >= rightSum && leftSum >= crossSum)
                {
                    return (leftLow, leftHigh, leftSum);
                }
                else if (rightSum >= leftSum && rightSum >= crossSum)
                {
                    return (rightHigh, rightLow, rightSum);
                }
                else
                {
                    return (crossLow, crossHigh, crossSum);
                }
            }
            public (int maxLeft, int maxRight, int sum) MaxCrossingSubarray(int[] nums, int low, int mid, int high)
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

                if(maxLeft == 0 && rightSum/leftSum == 2)
                {
                    return (0, 0, 0);
                }
                
                return (maxLeft, maxRight, leftSum + rightSum);
            }

            // check output buy = 0 & sell == mid
        }
    }
}
