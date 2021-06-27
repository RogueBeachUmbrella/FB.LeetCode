using System;
using System.Collections;
using System.Collections.Generic;

namespace ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

public class Solution
{
    public bool IsValid(string s)
    {
        bool valid = false;

        Stack<string> plain = new Stack<string>();
        Stack<string> square = new Stack<string>();
        Stack<string> curly = new Stack<string>();

        for (int i = 0; i < s.Length; i++)
        {
            string c = s[i].ToString();

            switch (c)
            {
                case "(":
                    plain.Push(c);
                    break;
                case "{":
                    curly.Push(c);
                    break;
                case "[":
                    square.Push(c);
                    break;
                case ")":
                    plain.Pop();
                    break;
                case "}":
                    curly.Pop();
                    break;
                case "]":
                    square.Pop();
                    break;
            }

        }



        return (plain.Count + curly.Count + square.Count) == 0 ? true : false;
    }


    public class Grouping
    {

        string _open { get; set; }
        string _close { get; set; }
        Stack _stack { get; set; }

        public Grouping(string open, string close)
        {
            _open = open;
            _close = close;
            _stack = new Stack();
        }
    }
}