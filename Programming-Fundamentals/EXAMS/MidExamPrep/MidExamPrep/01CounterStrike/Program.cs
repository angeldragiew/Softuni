using System;

namespace _01CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string input;
            int count = 0;
            bool outOfEnergy = false;
            while ((input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);
                if (energy - distance < 0)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {energy} energy");
                    outOfEnergy = true;
                    break;
                }
                else
                {
                    energy -= distance;
                    count++;
                    if (count % 3 == 0)
                    {
                        energy += count;
                    }
                }
               
            }

            if (!outOfEnergy)
            {
                Console.WriteLine($"Won battles: {count}. Energy left: {energy}");
            }
        }
    }
}
