using System;

namespace _09PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());
            int freeBelts = students / 6;

            lightsabersPrice *= Math.Ceiling(students * 1.10);

            robesPrice *= students;

            double beltFinalPrice = (students - freeBelts) * beltsPrice;

            double neededMoney = lightsabersPrice + robesPrice + beltFinalPrice;

            if (money >= neededMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {neededMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {neededMoney-money:f2}lv more.");
            }
        }
    }
}
