using System;
using System.Linq;

namespace _08LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string[] tasks = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double total = 0;
           
            for (int i = 0; i < tasks.Length; i++)
            {
                string task = tasks[i];

                char firstLetter = task[0];
                char secondLetter = task[task.Length - 1];

                task = task.Remove(0, 1);
                task = task.Remove(task.Length - 1, 1);
                
                double number = double.Parse(task);
                double resultedNum = 0;
                if (Char.IsUpper(firstLetter))
                {
                    int index = alphabet.IndexOf(firstLetter.ToString().ToUpper()) + 1;
                    resultedNum += number / index;
                }
                else
                {
                    int index = alphabet.IndexOf(firstLetter.ToString().ToUpper()) + 1;
                    resultedNum += number * index;
                }

                if (Char.IsUpper(secondLetter))
                {
                    int index = alphabet.IndexOf(secondLetter.ToString().ToUpper()) + 1;
                    resultedNum -= index;
                }
                else
                {
                    int index = alphabet.IndexOf(secondLetter.ToString().ToUpper()) + 1;
                    resultedNum += index;
                }
                total += resultedNum;
            }
            Console.WriteLine($"{total:f2}");
        }
    }
}
