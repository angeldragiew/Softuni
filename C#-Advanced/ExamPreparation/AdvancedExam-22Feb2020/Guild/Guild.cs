using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player playerToRemove = roster.FirstOrDefault(p => p.Name == name);
            if (playerToRemove == null)
            {
                return false;
            }
            roster.Remove(playerToRemove);
            return true;
        }

        public void PromotePlayer(string name)
        {
            Player playerToPromote = roster.First(p => p.Name == name);
            if (playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player playerToDemote = roster.First(p => p.Name == name);
            if(playerToDemote.Rank!= "Trial")
            {
                playerToDemote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            Player[] removedPlayers = roster.Where(p => p.Class == playerClass).ToArray();
            roster.RemoveAll(p => p.Class == playerClass);
            return removedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
