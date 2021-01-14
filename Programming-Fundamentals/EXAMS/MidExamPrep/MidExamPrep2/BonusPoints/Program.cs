using System;

namespace ExamPrep2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int lecturesCount = int.Parse(Console.ReadLine());

            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            int maxBonusAttendances = 0;

            for (int i = 0; i < n; i++)
            {
                int attendances = int.Parse(Console.ReadLine());

                double totalBonus = attendances * 1.0 / lecturesCount
                * (5 + additionalBonus);

                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    maxBonusAttendances = attendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Round(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxBonusAttendances} lectures.");
        }
    }
}
