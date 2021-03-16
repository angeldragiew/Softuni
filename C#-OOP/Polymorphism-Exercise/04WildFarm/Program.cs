using System;
using System.Collections.Generic;

namespace _04WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input;
            int line = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                if (line % 2 == 0)
                {
                    Animal animal = CreateAnima(input);
                    animals.Add(animal);
                }
                else
                {
                    Food food = CreateFood(input);
                    try
                    {
                        Console.WriteLine(animals[animals.Count-1].ProduceSound());
                        animals[animals.Count - 1].Eat(food);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                line++;
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string input)
        {
            string[] data = input.Split();
            string type = data[0];
            int quantity = int.Parse(data[1]);

            Food food = null;
            if (type == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (type == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }
            else if (type == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (type == nameof(Meat))
            {
                food = new Meat(quantity);
            }

            return food;
        }

        private static Animal CreateAnima(string input)
        {
            Animal animal = null;
            string[] data = input.Split();
            string type = data[0];
            string name = data[1];
            double weight = double.Parse(data[2]);

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(data[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(data[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = data[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = data[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = data[3];
                string breed = data[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = data[3];
                string breed = data[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }

            return animal;
        }
    }
}
