using System;

namespace _04PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInfo = Console.ReadLine().Split();
            string pizzaName;
            if (pizzaInfo.Length == 1)
            {
                pizzaName = string.Empty;
            }
            else
            {
                pizzaName = pizzaInfo[1];
            }

            string[] doughInfo = Console.ReadLine().Split();
            string flourType = doughInfo[1];
            string bakingType = doughInfo[2];
            double doughGrams = double.Parse(doughInfo[3]);
            try
            {
                Pizza pizza = new Pizza(pizzaName);
                Dough dough = new Dough(flourType, bakingType, doughGrams);
                pizza = new Pizza(pizzaName);
                pizza.Dough = dough;
                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = input.Split();
                    string type = toppingInfo[1];
                    double toppingGrams = double.Parse(toppingInfo[2]);
                    Topping topping = new Topping(type, toppingGrams);
                    pizza.AddTopping(topping);

                }
                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
