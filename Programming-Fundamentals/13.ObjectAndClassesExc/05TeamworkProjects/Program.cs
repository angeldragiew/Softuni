using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _05TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
               

                string[] userAndTeam = Console.ReadLine().Split("-").ToArray();


                string user = userAndTeam[0];
                string teamName = userAndTeam[1];

                bool isUserExist = teams.Select(x =>x.Creator).Contains(user);
                bool isTeamNameExist = teams.Select(x => x.TeamName).Contains(teamName); ;

                if (isTeamNameExist)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (isUserExist)
                {
                    Console.WriteLine($"{user} cannot create another team!");
                } 
                else
                {
                    Team team = new Team(teamName, user);
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {user}!");
                }
            }  //Creating Teams

            string input;

            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] memberAndTeam = input.Split("->").ToArray();

                string member = memberAndTeam[0];
                string teamName = memberAndTeam[1];

                bool doesTeamExist = teams.Select(x => x.TeamName).Contains(teamName);

                bool isCreatorExist = teams.Select(x=>x.Creator).Contains(member);
                bool isMemberExist = teams.Select(x => x.Members).Any(x => x.Contains(member));



                if (doesTeamExist == false)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (isMemberExist == true || isCreatorExist==true)
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                }
                else if (doesTeamExist==true && isMemberExist == false && isCreatorExist == false)
                {
                    int ind = teams.FindIndex(x => x.TeamName == teamName);
                    teams[ind].Members.Add(member);
                }

            } //Adding Members

            List<Team> disbandTeams = new List<Team>();

            for (int t = 0; t < teams.Count; t++)
            {
                if(teams[t].Members.Count == 0)
                {
                    disbandTeams.Add(teams[t]);
                    teams.Remove(teams[t]);
                    t=-1;
                }
            }

            disbandTeams = disbandTeams.OrderBy(a => a.TeamName).ToList();
            teams = teams.OrderByDescending(b => b.Members.Count).ThenBy(c => c.TeamName).ToList();

            int index = 0;
            foreach (var validTeam in teams)
            {
                validTeam.Members.Sort();
                Console.WriteLine(validTeam.TeamName);
                Console.WriteLine($"- {validTeam.Creator}");
                foreach (var member in teams[index].Members)
                {
                    Console.WriteLine($"-- {member}");
                }
                index++;
            }
            Console.WriteLine("Teams to disband:");
            foreach (var disbandTeam in disbandTeams)
            {
                Console.WriteLine(disbandTeam.TeamName);
            }
        }

        class Team
        {
            public Team(string name, string creator)
            {
                TeamName = name;
                Creator = creator;
                Members = new List<string>();
            }
            public string TeamName { get; set; }
            public string Creator { get; set; }
            public List<string> Members { get; set; }

        }
    }
}
