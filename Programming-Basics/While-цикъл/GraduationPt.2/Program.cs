using System;

namespace GraduationPt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string name = Console.ReadLine();
            string input = "";


            int schoolClass = 1;
            int classRepeat = 0;
            double total = 0;
            bool excluded = false;


            while (schoolClass <= 12) 
            {
                
                if (classRepeat == 2)
                {
                    excluded = true;
                    break;
                }
                input = Console.ReadLine();
                double grade = double.Parse(input);

                if (grade < 4)
                {
                    classRepeat++;
                    continue;
                }

                total += grade;
                schoolClass++;
                
            }

            if (excluded)
            {
                Console.WriteLine($"{name} has been excluded at {schoolClass} grade");
            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {total/12:f2}");
            }
        }
    }
}
