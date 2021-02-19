using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffectsInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] bombCasingsInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> bombEffects = new Queue<int>(bombEffectsInfo);
            Stack<int> bombCasings = new Stack<int>(bombCasingsInfo);

            Dictionary<string, int> bombs = new Dictionary<string, int>
            {
                {"Datura Bombs",0 },
                {"Cherry Bombs",0 },
                {"Smoke Decoy Bombs",0 }
            };

            while (bombEffects.Any() && bombCasings.Any() && IsPouchFull(bombs) == false)
            {
                int currEffect = bombEffects.Peek();
                int currCasing = bombCasings.Peek();

                int sum = currCasing + currEffect;
                string bombToAdd = string.Empty;
                if (sum == 40)
                {
                    bombToAdd = "Datura Bombs";
                }
                else if (sum == 60)
                {
                    bombToAdd = "Cherry Bombs";
                }
                else if (sum == 120)
                {
                    bombToAdd = "Smoke Decoy Bombs";
                }
                else
                {
                    currCasing -= 5;
                    bombCasings.Pop();
                    bombCasings.Push(currCasing);
                    continue;
                }
                bombEffects.Dequeue();
                bombCasings.Pop();
                bombs[bombToAdd]++;
            }

            if (IsPouchFull(bombs))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs.OrderBy(b=>b.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }

        public static bool IsPouchFull(Dictionary<string, int> bombs)
        {
            bool isFull = true;
            foreach (var bomb in bombs)
            {
                if (bomb.Value < 3)
                {
                    isFull = false;
                }
            }
            return isFull;
        }
    }
}
