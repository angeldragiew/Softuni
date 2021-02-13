using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();
            string fullName = $"{firstInput[0]} {firstInput[1]}";
            string address = firstInput[2];
            string town = firstInput[3];
            if (firstInput.Length > 4)
            {
                town += $" {firstInput[4]}";
            }
            CustomThreeuple<string, string, string> firstThreeuple =
                new CustomThreeuple<string, string, string>(fullName, address, town);

            string[] secondInput = Console.ReadLine().Split();
            string secName = secondInput[0];
            int age = int.Parse(secondInput[1]);
            bool isDrunk = false;
            if(secondInput[2] == "drunk") { isDrunk = true; }
            CustomThreeuple<string, int, bool> secondThreeuple =
                new CustomThreeuple<string, int, bool>(secName, age, isDrunk);

            string[] thirdInput = Console.ReadLine().Split();
            string thirdName = thirdInput[0];
            double accountBalance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];
            CustomThreeuple<string, double, string> thirdThreeuple =
                new CustomThreeuple<string, double, string>(thirdName, accountBalance, bankName);

            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
