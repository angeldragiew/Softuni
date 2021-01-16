using System;
using System.Collections.Generic;

namespace _4MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> bracketsIndexes = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    bracketsIndexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex = bracketsIndexes.Pop();
                    string bracket = expression.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(bracket);
                }
            }
        }
    }
}
