using System;

namespace _03Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int neededCourses = 0;

            while (people>)
            {
                neededCourses++;
                people -= capacity;
            }
            //if (people <= capacity)
            //{
            //    neededCourses = 1;
            //}
            //else
            //{
            //    neededCourses = people / capacity;
            //    if (people % capacity != 0)
            //    {
            //        neededCourses++;
            //    }

            //}

            Console.WriteLine(neededCourses);
        }
    }
}
