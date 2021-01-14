using System;

namespace _10RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());

            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int brokenHeadset = 0;
            int brokenMouse = 0;
            int brokenKeyboard = 0;
            int brokenDisplay = 0;

            int count = 0;
            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    brokenHeadset++;
                }

                if (i % 3 == 0)
                {
                    brokenMouse++;
                }

                if(i % 3 == 0 && i % 2 == 0)
                {
                    brokenKeyboard++;
                    count++;
                }

                if (count % 2 == 0 && count>1)
                {
                    brokenDisplay++;
                    count = 0;
                }
            }

            double totalExpenses = brokenDisplay * displayPrice + brokenHeadset * headsetPrice + brokenKeyboard * keyboardPrice + brokenMouse * mousePrice;

            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}
