using System;
using System.Collections.Generic;

namespace _07SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string firstInput;

            while ((firstInput = Console.ReadLine()) != "PARTY")
            {
                string guest = firstInput;
                char firstChar = guest[0];
                if (Char.IsDigit(firstChar))
                {
                    vip.Add(guest);
                }
                else
                {
                    regular.Add(guest);
                }
            }

            string secondInput;

            while ((secondInput = Console.ReadLine()) != "END")
            {
                string guest = secondInput;

                if (vip.Contains(guest))
                {
                    vip.Remove(guest);
                }
                if (regular.Contains(guest))
                {
                    regular.Remove(guest);
                }
            }

            Console.WriteLine(vip.Count + regular.Count);
            foreach (var guest in vip)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regular)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
