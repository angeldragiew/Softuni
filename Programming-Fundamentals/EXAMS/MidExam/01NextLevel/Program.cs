using System;

namespace _01NextLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int battleCount = int.Parse(Console.ReadLine());
            bool success = false;
            for (int i = 1; i <= battleCount; i++)
            {
                double experiencedGained = double.Parse(Console.ReadLine());

                if (i % 15 == 0)
                {
                    experiencedGained *= 1.05;
                }
                else if (i % 5 == 0)
                {
                    experiencedGained *= 0.90;
                }
                else if (i % 3 == 0)
                {
                    experiencedGained *= 1.15;
                }

                neededExperience -= experiencedGained;

                if(neededExperience<= 0)
                {
                    success = true;
                    Console.WriteLine($"Player successfully collected his needed experience for {i} battles.");
                    break;
                }
            }
            if (!success)
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience:f2} more needed.");
            }
            
        }
    }
}
