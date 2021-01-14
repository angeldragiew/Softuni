using System;
using System.Collections.Generic;
using System.Linq;

namespace _03HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());

            Dictionary<string, HeroAbilities> heroes = new Dictionary<string, HeroAbilities>();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] heroesInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string heroName = heroesInfo[0];
                int heroHealth = int.Parse(heroesInfo[1]);
                int heroMana = int.Parse(heroesInfo[2]);

                heroes.Add(heroName, new HeroAbilities { Health = heroHealth, Mana = heroMana });
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = cmdArgs[0];

                if (command == "CastSpell")
                {
                    string heroName = cmdArgs[1];
                    int mana = int.Parse(cmdArgs[2]);
                    string spellName = cmdArgs[3];

                    if (heroes[heroName].Mana >= mana)
                    {
                        heroes[heroName].Mana -= mana;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].Mana} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command == "TakeDamage")
                {
                    string heroName = cmdArgs[1];
                    int damage = int.Parse(cmdArgs[2]);
                    string attacker = cmdArgs[3];

                    heroes[heroName].Health -= damage;

                    if (heroes[heroName].Health > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].Health} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (command == "Recharge")
                {
                    string heroName = cmdArgs[1];
                    int amount = int.Parse(cmdArgs[2]);
                    int manaAquired;
                    if (heroes[heroName].Mana + amount > 200)
                    {
                        manaAquired = 200 - heroes[heroName].Mana;
                        heroes[heroName].Mana = 200;
                    }
                    else
                    {
                        manaAquired = amount;
                        heroes[heroName].Mana += amount;
                    }

                    Console.WriteLine($"{heroName} recharged for {manaAquired} MP!");
                }
                else if (command == "Heal")
                {
                    string heroName = cmdArgs[1];
                    int amount = int.Parse(cmdArgs[2]);
                    int healthAquired;
                    if (heroes[heroName].Health + amount > 200)
                    {
                        healthAquired = 200 - heroes[heroName].Health;
                        heroes[heroName].Health = 200;
                    }
                    else
                    {
                        healthAquired = amount;
                        heroes[heroName].Health += amount;
                    }
                    Console.WriteLine($"{heroName} healed for {healthAquired} HP!");
                }
            }
            foreach (var hero in heroes.OrderByDescending(hp => hp.Value.Health).ThenBy(n => n.Key))
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"HP: {hero.Value.Health}");
                Console.WriteLine($"MP: {hero.Value.Mana}");
            }
        }

        class HeroAbilities
        {
            public int Health { get; set; }
            public int Mana { get; set; }
        }
    }
}

