using System;
using System.Collections.Generic;
using System.Linq;

namespace _10PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] cmdArgs = input.Split();
                string command = cmdArgs[0];
                string firstCriteria = cmdArgs[1];
                string secondCriteria = cmdArgs[2];
                Predicate<string> criteria = GetCriteria(firstCriteria, secondCriteria);

                if (command == "Double")
                {
                    people = Double(people, criteria);
                }
                else if (command == "Remove")
                {
                    people.RemoveAll(criteria);
                }
            }

            if (people.Any())
            {
                Console.Write(string.Join(", ", people));
                Console.WriteLine(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static List<string> Double(List<string> people, Predicate<string> criteria)
        {
            List<string> newList = people.ToList();
            for (int i = 0; i < people.Count; i++)
            {
                string currName = people[i];
                if (criteria(currName))
                {
                    newList.Insert(i + 1, currName);
                }
            }

            return newList;
        }

        static Predicate<string> GetCriteria(string firstCriteria, string secondCriteria)
        {
            if (firstCriteria == "StartsWith")
            {
                return word => word.StartsWith(secondCriteria);
            }
            else if (firstCriteria == "EndsWith")
            {
                return word => word.EndsWith(secondCriteria);
            }
            else
            {
                int length = int.Parse(secondCriteria);
                return word => word.Length == length;
            }
        }
    }
}
