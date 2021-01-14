using System;
using System.Collections.Generic;
using System.Linq;

namespace _08CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            bool isIdExist = false;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string company = cmdArgs[0];
                string employeeId = cmdArgs[1];

                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new List<string>());
                }

                if (!companies[company].Contains(employeeId))
                {
                    companies[company].Add(employeeId);
                }
            }

            foreach (var item in companies.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);

                foreach (var emp in item.Value)
                {
                    Console.WriteLine($"-- {emp}");
                }
            }
        }
    }
}
