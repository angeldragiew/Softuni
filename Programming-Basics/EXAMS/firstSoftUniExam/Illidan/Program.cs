using System;

namespace Illidan
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int oneHumanPower = int.Parse(Console.ReadLine());
            int health = int.Parse(Console.ReadLine());

            int power = people * oneHumanPower;

            if (power >= health)
            {
                Console.WriteLine($"Illidan has been slain! You defeated him with {power-health} points.");
            }
            else
            {
                Console.WriteLine($"You are not prepared! You need {health-power} more points.");
            }
        }
    }
}
