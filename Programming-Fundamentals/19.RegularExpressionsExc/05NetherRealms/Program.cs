using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string healthPattern = @"[0-9+\-*\/.]";

            string[] input = Console.ReadLine()
                .Split(new string[] { ", ", ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<Demon> demons = new List<Demon>();

            foreach (string demon in input)
            {
                //bool isNameValid = IsNameValid(demon);
                //if (isNameValid)
                //{
                    string onlyLetters = Regex.Replace(demon, healthPattern, "");
                    int health = HealthCalculator(onlyLetters);
                    double damage = DamageCalculator(demon);
                    Demon currDemon = new Demon();
                    currDemon.Name = demon;
                    currDemon.Health = health;
                    currDemon.Damage = damage;
                    demons.Add(currDemon);
                //}
            }

            demons = demons.OrderBy(n => n.Name).ToList();

            foreach (var demon in demons)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }

        }
        //public static bool IsNameValid(string name)
        //{
        //    bool isValidName = true;

        //    foreach (var ch in name)
        //    {
        //        if (ch == ' ' || ch == ',')
        //        {
        //            isValidName = false;
        //            break;
        //        }
        //    }

        //    return isValidName;
        //}
        public static double DamageCalculator(string demon)
        {
            double damage = 0;
            string pattern = @"[+|-]?[\d]+([\.][\d]+)?";
            Regex regex = new Regex(pattern);

            MatchCollection array = regex.Matches(demon);

            foreach (Match match in array)
            {
                damage += double.Parse(match.Value);
            }

            foreach (var ch in demon)
            {
                if (ch == '*')
                {
                    damage *= 2.0;
                }
                else if (ch == '/')
                {
                    damage /= 2.0;
                }
            }

            return damage;
        }

        public static int HealthCalculator(string onlyLetters)
        {
            int health = 0;
            foreach (var letter in onlyLetters)
            {
                health += letter;
            }
            return health;
        }

        class Demon
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public double Damage { get; set; }
        }
    }
}
