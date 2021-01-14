using System;
using System.Collections.Generic;
using System.Linq;

namespace _08AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "3:1")
            {
                string[] tokens = input.Split();

                string command = tokens[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }else if(startIndex>= list.Count)
                    {
                        continue;
                    }

                    if (endIndex >= list.Count)
                    {
                        endIndex = list.Count - 1;
                    }

                    list = Merge(list, startIndex, endIndex);
                    Console.WriteLine(string.Join(" ", list));
                }
                else if (command == "divide")
                {
                    int index = int.Parse(tokens[1]);
                    int partitions = int.Parse(tokens[2]);
                    if (partitions <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (list[index].Length % partitions == 0)
                        {
                            list = DivideDivisableString(list, index, partitions);
                        }
                        else
                        {
                            list = DivideNonDivisableString(list, index, partitions);
                        }

                        Console.WriteLine(string.Join(" ", list));
                    }
                    
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }

        static List<string> DivideNonDivisableString(List<string> list, int index, int partitions)
        {
            string stringTodivide = list[index];
            List<string> dividedString = new List<string>();

            int longestString = stringTodivide.Length % partitions + stringTodivide.Length / partitions;
            int shortStrings = stringTodivide.Length / partitions;
            int indexOfLastPartition = stringTodivide.Length - longestString;

            list.RemoveAt(index);
            
            for (int i = 0; i <= indexOfLastPartition-1; i += shortStrings)
            {
                dividedString.Add(stringTodivide.Substring(i, shortStrings));
            }
            dividedString.Add(stringTodivide.Substring(indexOfLastPartition, longestString));

            dividedString.Reverse();

            for (int i = 0; i < dividedString.Count; i++)
            {
                list.Insert(index, dividedString[i]);
            }

            return list;
        }
        static List<string> DivideDivisableString(List<string> list, int index, int partitions)
        {
            string stringTodivide = list[index];
            List<string> dividedString = new List<string>();

            int subString = stringTodivide.Length / partitions;
            list.RemoveAt(index);
            for (int i = 0; i < stringTodivide.Length; i += subString)
            {
                dividedString.Add(stringTodivide.Substring(i, subString));
            }

            dividedString.Reverse();

            for (int i = 0; i < dividedString.Count; i++)
            {
                list.Insert(index, dividedString[i]);
            }

            return list;
        }

        static List<string> Merge(List<string> list, int startIndex, int endIndex)
        {
            int firstIndex = startIndex;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (startIndex + 1 > list.Count - 1)
                {
                    break;
                }

                list[firstIndex] += list[startIndex + 1];
                list.RemoveAt(startIndex + 1);
            }

            return list;
        }
    }
}
