using System;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                if (command == "Push")
                {
                    string[] itemsToPush = cmdArgs.Skip(1).ToArray();
                    foreach (var num in itemsToPush)
                    {
                        stack.Push(int.Parse(num.TrimEnd(',')));
                    }
                }
                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            foreach (var num in stack)
            {
                Console.WriteLine(num);
            }

            foreach (var num in stack)
            {
                Console.WriteLine(num);
            }
        }
    }
}
