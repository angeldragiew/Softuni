using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public class Bag
    {
        private readonly List<Item> items;
        protected Bag(int capacity)
        {
            items = new List<Item>();
            Capacity = capacity;
        }

        public int Capacity { get; private set; } = 100;
        public int Load
        {
            get
            {
                return items.Sum(i => i.Weight);
            }
        }
        public IReadOnlyCollection<Item> Items => items;

        public void AddItem(Item item)
        {
            if (item.Weight + Load > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Any() == false)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = items.FirstOrDefault(i => i.GetType().Name == name);

            if(item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            items.Remove(item);
            return item;
        }
    }
}
