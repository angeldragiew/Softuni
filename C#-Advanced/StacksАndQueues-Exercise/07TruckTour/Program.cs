using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] pumpInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(pumpInfo);
            }


            int pumpNumber = 0;

            for (int i = 0; i < n; i++)
            {
                int fuel = 0;
                int distance = 0;
                bool succeess = true;

                for (int z = 0; z < n; z++)
                {
                    fuel += pumps.Peek()[0];
                    distance = pumps.Peek()[1];
                    fuel -= distance;

                    pumps.Enqueue(pumps.Dequeue());
                    
                    if(fuel<0)
                    {
                        succeess = false;
                    }
                }

                if (succeess)
                {
                    pumpNumber = i;
                    break;
                }
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(pumpNumber);

        }
    }
}
