using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;

            while ((input = Console.ReadLine())!="end")
            {
                string[] tokens = input.Split();

                if(tokens[0] == "Delete")
                {
                    int number = int.Parse(tokens[1]);
                    list.RemoveAll(item => item == number);
                }
                else
                {
                    int number = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    list.Insert(index,number);
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
