using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArgs = input.Split(";",StringSplitOptions.RemoveEmptyEntries);
                    string command = cmdArgs[0];

                    if (command == "Team")
                    {
                        string teamName = cmdArgs[1];
                        Team currTeam = new Team(teamName);
                        teams.Add(currTeam);
                    }
                    else if (command == "Add")
                    {
                        string teamName = cmdArgs[1];
                        if (teams.Any(t => t.Name == teamName) == false)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        string playerName = cmdArgs[2];
                        int endurance = int.Parse(cmdArgs[3]);
                        int sprint = int.Parse(cmdArgs[4]);
                        int dribble = int.Parse(cmdArgs[5]);
                        int passing = int.Parse(cmdArgs[6]);
                        int shooting = int.Parse(cmdArgs[7]);
                        Player currPlayer = new Player(playerName,endurance, sprint, dribble, passing, shooting);

                        Team team = teams.First(t => t.Name == teamName);
                        team.AddPlayer(currPlayer);
                    }
                    else if (command == "Remove")
                    {
                        string teamName = cmdArgs[1];
                        string playerName = cmdArgs[2];
                        Team team = teams.First(t => t.Name == teamName);
                        team.RemovePlayer(playerName);
                    }
                    else if (command == "Rating")
                    {
                        string teamName = cmdArgs[1];
                        
                        if (teams.Any(t => t.Name == teamName) == false)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        Team team = teams.First(t => t.Name == teamName);
                        Console.WriteLine($"{teamName} - {team.Rating}");
                    }
                }
                catch (Exception ex)
                when(ex is ArgumentException || ex is InvalidOperationException)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


    }
}
