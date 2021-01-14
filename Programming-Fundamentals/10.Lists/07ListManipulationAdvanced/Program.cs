using System;
using System.Collections.Generic;
using System.Linq;

namespace _07ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            string input;
            bool isChanged = false;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();
                int num;
                int index;
                switch (tokens[0])
                {
                    case "Add":
                        num = int.Parse(tokens[1]);
                        nums.Add(num);
                        isChanged = true;
                        break;
                    case "Remove":
                        num = int.Parse(tokens[1]);
                        nums.Remove(num);
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        index = int.Parse(tokens[1]);
                        nums.RemoveAt(index);
                        isChanged = true;
                        break;
                    case "Insert":
                        num = int.Parse(tokens[1]);
                        index = int.Parse(tokens[2]);
                        nums.Insert(index, num);
                        isChanged = true;
                        break;
                    case "Contains":
                        num = int.Parse(tokens[1]);
                        if (nums.Contains(num))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        PrintEven(nums);
                        break;
                    case "PrintOdd":
                        PrintOdd(nums);
                        break;
                    case "GetSum":
                        GetSum(nums);
                        break;
                    case "Filter":
                        string sign = tokens[1];
                        num = int.Parse(tokens[2]);
                        Filter(nums, sign, num);
                        break;
                }
            }
        }

        private static void Filter(List<int> nums, string sign, int num)
        {
            List<int> newList = new List<int>();
            switch (sign)
            {
                case "<":
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] < num)
                        {
                            newList.Add(nums[i]);
                        }
                    }
                    break;
                case ">":
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] > num)
                        {
                            newList.Add(nums[i]);
                        }
                    }
                    break;
                case ">=":
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] >= num)
                        {
                            newList.Add(nums[i]);
                        }
                    }
                    break;
                case "<=":
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] <= num)
                        {
                            newList.Add(nums[i]);
                        }
                    }
                    break;
            }

            Console.WriteLine(string.Join(" ", newList));
        }

        static void PrintEven(List<int> nums)
        {
            List<int> evenNums = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    evenNums.Add(nums[i]);
                }
            }
            Console.WriteLine(string.Join(" ", evenNums));           
        }

        static void PrintOdd(List<int> nums)
        {
            List<int> oddNums = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 != 0)
                {
                    oddNums.Add(nums[i]);
                }
            }
            Console.WriteLine(string.Join(" ", oddNums));
        }

        static void GetSum(List<int> nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                sum += nums[i];
            }
            Console.WriteLine(sum);
        }
    }
}
