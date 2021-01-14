using System;
using System.Collections.Generic;
using System.Linq;

namespace _07StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            List<Box> boxList = new List<Box>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] arr = input.Split().ToArray();

                string serialNumber = arr[0];
                string name = arr[1];
                int quantity = int.Parse(arr[2]);
                double itemPrice = double.Parse(arr[3]);

                double priceOfBox = quantity * itemPrice;

                Box box = new Box();
                box.Item = new Item();
                box.SerialNumber = serialNumber;
                box.Item.Name = name;
                box.Item.Price = itemPrice;
                box.ItemQuantity = quantity;
                box.PriceForBox = priceOfBox;

                boxList.Add(box);
            }
            for (int i = 0; i < boxList.Count-1; i++)
            {
                if (boxList[i].PriceForBox < boxList[i + 1].PriceForBox)
                {
                    Box firstBox = boxList[i];
                    boxList[i] = boxList[i + 1];
                    boxList[i + 1] = firstBox;
                    i = -1;
                }
            }

            foreach (var box in boxList)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f2}");
            }
        }

        class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
        class Box
        {
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int ItemQuantity { get; set; }
            public double PriceForBox { get; set; }
        }
    }
}
