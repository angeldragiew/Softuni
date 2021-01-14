using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badMarks = int.Parse(Console.ReadLine());

            string excName = "";
            double mark = 0;

            string lastProblemName = "";
            double total = 0;
            int excCount = 0;
            int badMarksCount = 0;

            bool tooManyBadMarks = false;

            while (true)
            {
                excName = Console.ReadLine();
                if (excName == "Enough")
                {
                    break;
                }
                lastProblemName = excName;
                mark = double.Parse(Console.ReadLine());
                total += mark;
                excCount++;
                if (mark<=4)
                {
                    badMarksCount++;
                    badMarks--;
                }
                if (badMarks==0)
                {
                    tooManyBadMarks = true;
                    break;
                }
               
            }
          
            if (tooManyBadMarks)
            {
                Console.WriteLine($"You need a break, {badMarksCount} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {total / excCount:f2}");
                Console.WriteLine($"Number of problems: {excCount}");
                Console.WriteLine($"Last problem: {lastProblemName}");

            }
        }
    }
}
