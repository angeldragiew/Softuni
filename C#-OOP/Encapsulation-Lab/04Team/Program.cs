using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Team team = new Team("A");

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();

                decimal salary = decimal.Parse(personInfo[3]);
                Person person = new Person(personInfo[0], personInfo[1], int.Parse(personInfo[2]), salary);
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

           
        }
    }
}
