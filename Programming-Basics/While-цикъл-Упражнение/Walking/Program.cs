using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsGoal = 10000;

            int totalSteps = 0;
            while (totalSteps<stepsGoal)
            {
                string input = Console.ReadLine(); ;
                if(input== "Going home")
                {
                    int stepsToHome = int.Parse(Console.ReadLine());
                    totalSteps += stepsToHome;
                    break;
                }
                int steps = int.Parse(input);
                totalSteps += steps;
                
            }

            if (totalSteps>=stepsGoal)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{totalSteps-stepsGoal} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(stepsGoal-totalSteps)} more steps to reach goal.");
            }
        }
    }
}
