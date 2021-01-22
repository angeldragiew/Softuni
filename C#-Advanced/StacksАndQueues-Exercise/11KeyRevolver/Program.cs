using System;
using System.Collections.Generic;
using System.Linq;

namespace _11KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> allBullets = new Stack<int>(bulletsInput);
            Queue<int> bullets = new Queue<int>();
            Reloading(bullets, allBullets, gunBarrelSize);

            Queue<int> locks = new Queue<int>(locksInput);

            while (locks.Any() && (allBullets.Any() || bullets.Any()))
            {
                int currBullet = bullets.Dequeue();
                int currLock = locks.Peek();

                intelligenceValue -= bulletPrice;

                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (bullets.Count <= 0)
                {
                    if (allBullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        Reloading(bullets, allBullets, gunBarrelSize);
                    }
                }
            }


            if (locks.Count <= 0)
            {
                Console.WriteLine($"{allBullets.Count+bullets.Count} bullets left. Earned ${intelligenceValue}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }

        public static void Reloading(Queue<int> bullets, Stack<int> allBullets, int gunBarrelSize)
        {
            for (int i = 0; i < gunBarrelSize; i++)
            {
                if (allBullets.Count > 0)
                {
                    bullets.Enqueue(allBullets.Pop());
                }
                else
                {
                    break;
                }
            }
        }
    }
}
