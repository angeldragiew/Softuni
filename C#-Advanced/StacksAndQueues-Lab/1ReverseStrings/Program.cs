using System;
using System.Collections;
using System.Collections.Generic;

namespace _1ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversedStack = new Stack<char>(input);

            while (reversedStack.Count>0)
            {
                Console.Write(reversedStack.Pop());
            }
        }
    }
}
