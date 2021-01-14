using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string op = Console.ReadLine();
            double result = 0;
            string evenOrOdd = "";

            switch (op)
            {
                case "+":
                    result = n1 + n2;
                    if(result%2 == 0)
                    {
                        evenOrOdd ="even";
                    }
                    else
                    {
                        evenOrOdd = "odd";
                    }
                    break;
                case "-":
                    result = n1 - n2;
                    if (result % 2 == 0)
                    {
                        evenOrOdd = "even";
                    }
                    else
                    {
                        evenOrOdd = "odd";
                    }
                    break;
                case "*":
                    result = n1 * n2;
                    if (result % 2 == 0)
                    {
                        evenOrOdd = "even";
                    }
                    else
                    {
                        evenOrOdd = "odd";
                    }
                    break;
                case "/":
                        result = n1 / n2;               
                    break;
                case "%":
                        result = n1 % n2;
                    break;
            }

            switch (op)
            {
                case "+":
                case "-":
                case "*":
                    Console.WriteLine($"{n1} {op} {n2} = {result} - {evenOrOdd}");
                    break;
                case "/":
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} / {n2} = {result:f2}");
                    }
                    break;
                case "%":
                    if (n2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} % {n2} = {result}");
                    }
                    break;
            }
        }
    }
}
