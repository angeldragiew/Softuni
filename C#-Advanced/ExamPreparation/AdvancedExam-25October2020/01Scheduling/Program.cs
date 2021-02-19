using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksInfo = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threadsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> tasks = new Stack<int>(tasksInfo);
            Queue<int> threads = new Queue<int>(threadsInfo);

            int taskToKill = int.Parse(Console.ReadLine());
            bool isTaskAlive = true;

            while (isTaskAlive)
            {
                int currTask = tasks.Peek();
                int currThread = threads.Peek();

                if (currTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currThread} killed task {taskToKill}");
                    Console.WriteLine(string.Join(" ", threads));
                    isTaskAlive = false;
                }
                else if (currThread >= currTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (currThread < currTask)
                {
                    threads.Dequeue();
                }
            }
        }
    }
}
