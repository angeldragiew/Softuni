using System;
using System.Collections.Generic;
using System.Linq;

namespace _08BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, char> brackets = new Dictionary<char, char>()
            {
                {')', '('},
                {']', '['},
                {'}', '{'},
                {'(', ')'},
                {'[', ']'},
                {'{', '}'}
            };

            Stack<char> parentheses = new Stack<char>();

            for (int z = 0; z < input.Length; z++)
            {
                if (parentheses.Count <= 0)
                {
                    parentheses.Push(input[z]);
                }
                else
                {
                    if (parentheses.Peek() == brackets[input[z]])
                    {
                        parentheses.Pop();
                    }
                    else
                    {
                        parentheses.Push(input[z]);
                    }
                }
            }

            if (parentheses.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
