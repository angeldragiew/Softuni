using System;
using System.Collections.Generic;
using System.Text;

namespace _05FootballTeamGenerator
{
    public class Player
    {
        private const int minStat = 0;
        private const int maxStat = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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

        public int Shooting
        {
            get { return shooting; }
            private set
            {
                ThrowIfInvalidStat(nameof(Shooting), value);
                shooting = value;
            }
        }

        public int Passing
        {
            get { return passing; }
            private set
            {
                ThrowIfInvalidStat(nameof(Passing), value);
                passing = value;
            }
        }
        public int Dribble
        {
            get { return dribble; }
            private set
            {
                ThrowIfInvalidStat(nameof(Dribble), value);
                dribble = value;
            }
        }

        public int Sprint
        {
            get { return sprint; }
            private set
            {
                ThrowIfInvalidStat(nameof(Sprint), value);
                sprint = value;
            }
        }

        public int Endurance
        {
            get { return endurance; }
            private set
            {
                ThrowIfInvalidStat(nameof(Endurance), value);
                endurance = value;
            }
        }
        public int SkillLevel => GetSkillLevel();
        private int GetSkillLevel()
        {
            double skillLevel = (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
            return (int)Math.Round(skillLevel);
        }

        public void ThrowIfInvalidStat(string statName, double stat)
        {
            if (stat < minStat || stat > maxStat)
            {
                throw new ArgumentException($"{statName} should be between {minStat} and {maxStat}.");
            }
        }

    }
}
