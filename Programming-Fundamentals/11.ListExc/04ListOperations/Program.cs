using System;
using System.Collections.Generic;
using System.Linq;

namespace _04ListOperations
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

            while ((input = Console.ReadLine())!="End")
            {
                string[] tokens = input.Split();
                int number;
                int index;
                if (tokens[0] == "Add")
                {
                    number = int.Parse(tokens[1]);
                    list.Add(number);
                }
                else if (tokens[0] == "Insert")
                {
                    number = int.Parse(tokens[1]);
                    index = int.Parse(tokens[2]);
                    if (index < list.Count && index >=0)
                    {
                        list.Insert(index, number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                    
                } 
                else if (tokens[0] == "Remove")
                {
                    index = int.Parse(tokens[1]);
                    if (index < list.Count && index >= 0)
                    {
                        list.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                    
                }
                else if (tokens[0] == "Shift")
                {
                    if (tokens[1] == "left")
                    {
                        number = int.Parse(tokens[2]);
                        list = ShiftLeft(list, number);
                    }
                    else if(tokens[1] == "right")
                    {
                        number = int.Parse(tokens[2]);
                        list = ShiftRight(list, number);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }

        static List<int> ShiftLeft(List<int> list, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int firstItem = list[0];
                list.RemoveAt(0);
                list.Add(firstItem);
            }
            return list;
        }

        static List<int> ShiftRight(List<int> list, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int lastItem = list[list.Count-1];
                list.RemoveAt(list.Count-1);
                list.Insert(0,lastItem);
            }
            return list;
        }
    }
}
