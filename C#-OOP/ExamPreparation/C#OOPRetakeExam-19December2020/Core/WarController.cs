using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characters;
        private List<Item> items;
        public WarController()
        {
            characters = new List<Character>();
            items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];
            Character character = null;
            if (characterType == nameof(Priest))
            {
                character = new Priest(name);
            }
            else if (characterType == nameof(Warrior))
            {
                character = new Warrior(name);
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{ characterType }\"!");
            }

            characters.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = null;
            if (itemName == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else if (itemName == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{ itemName }\"!");
            }

            items.Add(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = characters.FirstOrDefault(ch => ch.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if(items.Any() == false)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            Item item = items[items.Count - 1];
            character.Bag.AddItem(item);
            items.Remove(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = characters.FirstOrDefault(ch => ch.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Item item = character.Bag.GetItem(itemName);
            item.AffectCharacter(character);
            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var character in characters.OrderByDescending(c=>c.IsAlive).ThenByDescending(c=>c.Health))
            {
                string status = character.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            Character attacker = characters.FirstOrDefault(ch => ch.Name == attackerName);
            Character receiver = characters.FirstOrDefault(ch => ch.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (attacker.GetType().Name != nameof(Warrior))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            IAttacker castedAttacker = (IAttacker)attacker;
            castedAttacker.Attack(receiver);
           

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (receiver.Health <= 0)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            Character healer = characters.FirstOrDefault(ch => ch.Name == healerName);
            Character receiver = characters.FirstOrDefault(ch => ch.Name == healingReceiverName);

            if(healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (receiver == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (healer.GetType().Name != nameof(Priest))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            IHealer castedHealer = (IHealer)healer;
            castedHealer.Heal(receiver);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

            return sb.ToString().Trim();
        }
    }
}
