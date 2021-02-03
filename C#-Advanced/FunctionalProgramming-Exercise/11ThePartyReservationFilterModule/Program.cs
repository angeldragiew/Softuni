using System;
using System.Collections.Generic;
using System.Linq;

namespace _11ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            Dictionary<string, string> filters = new Dictionary<string, string>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] cmdArgs = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                string filterValue = cmdArgs[1];
                string filterKey = cmdArgs[2];


                if (command == "Add filter")
                {
                    filters.Add(filterKey, filterValue);
                }
                else if (command == "Remove filter")
                {
                    filters.Remove(filterKey);
                }
            }

            foreach (var filter in filters)
            {
                Func<string, bool> currFilter = GetFilter(filter.Key, filter.Value);
                people = people.Where(currFilter).ToList();
            }
            Console.WriteLine(string.Join(" ", people));
        }

        static Func<string, bool> GetFilter(string criteriaValue, string criteria)
        {
            if (criteria == "Starts with")
            {
                return name => !name.StartsWith(criteriaValue);
            }
            else if (criteria == "Ends with")
            {
                return name => !name.EndsWith(criteriaValue);
            }
            else if (criteria == "Length")
            {
                int length = int.Parse(criteriaValue);
                return name => name.Length != length;
            }
            else if (criteria == "Contains")
            {
                return name => !name.Contains(criteriaValue);
            }
            return null;
        }
    }
}
