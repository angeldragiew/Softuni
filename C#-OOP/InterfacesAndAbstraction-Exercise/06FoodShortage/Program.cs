using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            Citizen citizen = new Citizen("s", 2, "s", "s");
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();

                if (cmdArgs.Length == 3)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string group = cmdArgs[2];
                    IBuyer buyer = new Rebel(name, age, group);
                    buyers.Add(name, buyer);
                }
                else
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];
                    string birthdate = cmdArgs[3];
                    IBuyer buyer = new Citizen(name, age, id, birthdate);
                    buyers.Add(name, buyer);
                }
            }

            string input;
            while ((input = Console.ReadLine()) !="End")
            {
                string name = input;
                if (buyers.ContainsKey(name))
                {
                    buyers[name].BuyFood();
                }
            }

            int boughtFood = buyers.Sum(b => b.Value.Food);
            Console.WriteLine(boughtFood);
        }
    }
}
