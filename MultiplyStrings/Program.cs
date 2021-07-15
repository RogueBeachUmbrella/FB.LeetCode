using System;
using System.Collections.Generic;
using System.Numerics;

namespace MultiplyStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            Console.WriteLine(s.Multiply("123456789", "987654321")); //"121932631112635269"
        }

        public class Solution
        {
            public string Multiply(string num1, string num2)
            {
                string result = "0";
                int i = 0;
                for(int j = num2.Length - 1; j >= 0; j--)
                {
                    int n = int.Parse(num2[j].ToString());
                    string product = DoMultiply(num1, n);
                    result = AddProduct(result, product.PadRight((product.Length + i), '0'));
                    i++;
                }


                return result;
            }

            public string DoMultiply(string num1, int n)
            {
                string result = "";
                int remainder = 0;
                for(int j = num1.Length - 1; j >= 0; j--)
                {
                    int m = int.Parse(num1[j].ToString());
                    int x = (m * n) + remainder;

                    if(x > 9)
                    {
                        remainder = x / 10;
                        x = x - (remainder * 10);
                    }
                    else
                    {
                        remainder = 0;
                    }

                    result = x + result;
                }

                if(remainder > 0)
                {
                    result = remainder + result;
                }

                return result;
            }

            public string AddProduct(string number, string product)
            {
                if(number == "0")
                {
                    return product;
                }


                string result = "";
                int remainder = 0;
                int p = product.Length - 1;
                int b = number.Length - 1;
                
                for(int i = 0; i <= number.Length || i <= product.Length; i++)
                {
                    int n = 0;
                    if(b >= 0)
                    {
                        n = int.Parse(number[b].ToString());
                        b--;
                    }

                    int m = 0;
                    if (p >= 0)
                    {
                        m = int.Parse(product[p].ToString());
                        p--;
                    }

                    int x = n + m + remainder;

                    //int a = result == "" ? 0 : int.Parse(result[0].ToString());

                    if (x > 9)
                    {
                        remainder = x / 10;
                        x = x - (remainder * 10);
                    }
                    else
                    {
                        remainder = 0;
                    }

                    result = x + result;
                }

                return result.TrimStart('0');
            }
        }
    }
}