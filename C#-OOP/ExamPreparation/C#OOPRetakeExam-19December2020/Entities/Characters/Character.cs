using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get { return health; }
            set
            {
                if (value > BaseHealth)
                {
                    health = BaseHealth;
                }
                else if (value >= 0)
                {
                    health = value;
                }
            }
        }

        public double BaseArmor { get; private set; }

        public bool IsAlive { get; set; } = true;

        public double Armor
        {
            get { return armor; }
            private set
            {
                if (value >= 0)
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }


        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            double currArmor = Armor;
            currArmor -= hitPoints;

            if (currArmor >= 0)
            {
                Armor = currArmor;
                return;
            }
            double hitPointsLeft = hitPoints - Armor;
            Armor = 0;

            if (Health - hitPointsLeft < 0)
            {
                Health = 0;
                IsAlive = false;
                return;
            }

            Health -= hitPointsLeft;
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}