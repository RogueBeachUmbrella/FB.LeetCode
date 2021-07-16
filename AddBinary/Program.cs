using System;

namespace AddBinary
{
    class Program
    {
        /*
            Given two binary strings a and b, return their sum as a binary string.

            Example 1:

            Input: a = "11", b = "1"
            Output: "100"
            Example 2:

            Input: a = "1010", b = "1011"
            Output: "10101"
 

            Constraints:

            1 <= a.length, b.length <= 104
            a and b consist only of '0' or '1' characters.
            Each string does not contain leading zeros except for the zero itself.
         
         */
        static void Main(string[] args)
        {
            Console.WriteLine(AddBinary("1111", "1111"));
        }

        public static string AddBinary(string a, string b)
        {
            string result = "";

            int i = a.Length - 1;
            int j = b.Length - 1;
            int r = 0;

            while (i >= 0 || j >= 0)
            {
                int n = 0;
                int m = 0;

                if(i >= 0)
                {
                    n = int.Parse(a.Substring(i, 1));
                    i--;
                }

                if (j >= 0)
                {
                    m = int.Parse(b.Substring(j, 1));
                    j--;
                }

                int sum = n + m + r;
                if (sum > 1)
                {
                    result = (sum % 2).ToString() + result;
                    r = 1;
                }
                else 
                {
                    result = sum.ToString() + result;
                    r = 0;
                }
            }

            return r > 0 ? "1" + result : result;
        }
    }
}
