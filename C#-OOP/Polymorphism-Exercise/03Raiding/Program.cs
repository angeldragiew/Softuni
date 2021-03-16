using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Raiding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());

            while (raidGroup.Count!=n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                try
                {
                    BaseHero hero = CreateHero(heroName, heroType);
                    raidGroup.Add(hero);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int heroesPower = raidGroup.Sum(h => h.Power);
            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        public static BaseHero CreateHero(string heroName, string heroType)
        {
            BaseHero hero = null;

            if (heroType.ToLower() == "druid")
            {
                hero = new Druid(heroName);
            }
            else if (heroType.ToLower() == "paladin")
            {
                hero = new Paladin(heroName);
            }
            else if (heroType.ToLower() == "rogue")
            {
                hero = new Rogue(heroName);
            }
            else if (heroType.ToLower() == "warrior")
            {
                hero = new Warrior(heroName);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }
}
