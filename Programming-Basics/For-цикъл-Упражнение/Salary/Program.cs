using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            double facebook = 150;
            double instagram = 100;
            double reddit = 50;

            int n = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string tab = Console.ReadLine();
                if(tab== "Facebook")
                {
                    salary -= facebook;
                }
                else if(tab == "Instagram")
                {
                    salary -= instagram;
                }
                else if (tab == "Reddit")
                {
                    salary -= reddit;
                }

                if (salary <= 0)
                {
                    break;
                }
            }

            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary);
            }
        }
    }
}
