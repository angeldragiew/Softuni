using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            players = new List<Player>();
            Name = name;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public int Rating => GetTeamRating();
        private int GetTeamRating()
        {
            if (players.Any() == false)
            {
                return 0;
            }
            return (int)Math.Round(players.Average(p => p.SkillLevel));
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!this.players.Any(p => p.Name == playerName))
            {
                throw new InvalidOperationException($"Player {playerName} is not in {Name} team.");
            }
            else
            {
                Player player = players.FirstOrDefault(p => p.Name == playerName);
                players.Remove(player);
            }
        }
    }
}
