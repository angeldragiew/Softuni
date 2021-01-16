using System;
using System.Collections.Generic;
using System.Linq;

namespace _3SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            Stack<string> expression = new Stack<string>(input.Reverse());

            while (expression.Count>1)
            {
                int firstNum = int.Parse(expression.Pop());
                string sign = expression.Pop();
                int secondNum = int.Parse(expression.Pop());

                int result = 0;
                if (sign == "+")
                {
                    result = firstNum + secondNum;
                    expression.Push(result.ToString());
                }
                else
                {
                    result = firstNum - secondNum;
                    expression.Push(result.ToString());
                }
            }
            Console.WriteLine(expression.Pop());
        }
    }
}
