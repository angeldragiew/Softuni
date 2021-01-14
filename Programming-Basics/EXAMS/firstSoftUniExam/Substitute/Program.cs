using System;

namespace Substitute
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int k = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int substitute = 0;

            bool end = false;


            for (int firstNum = k; firstNum <= 8; firstNum++)
            {
                for (int secondNum = 9; secondNum >= l; secondNum--)
                {
                    for (int thirdNum = m; thirdNum <= 8; thirdNum++)
                    {
                        for (int fourthNum = 9; fourthNum >= n; fourthNum--)
                        {
                            if (firstNum % 2 == 0 && secondNum % 2 != 0 && thirdNum % 2 == 0 && fourthNum % 2 != 0)
                            {
                                if (firstNum == thirdNum && secondNum == fourthNum)
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                }
                                else
                                {
                                    Console.WriteLine($"{firstNum}{secondNum} - {thirdNum}{fourthNum}");
                                    substitute++;
                                    if (substitute >= 6)
                                    {
                                        end = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (end)
                        {
                            break;
                        }
                    }
                    if (end)
                    {
                        break;
                    }
                }
                if (end)
                {
                    break;
                }

            }

            
            
            
        }
    }
}
