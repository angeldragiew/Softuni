using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace _03AngryPet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> priceRatings = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int entryPoint = int.Parse(Console.ReadLine());

            string typeOfItems = Console.ReadLine();
            string typeOfPriceRatings = Console.ReadLine();

            int leftBrokenItems = 0;
            int rightBrokenItems = 0;

            if (typeOfItems == "cheap")
            {
                int entryPointPrice = priceRatings[entryPoint];
                if (typeOfPriceRatings == "positive")
                {
                    for (int i = entryPoint - 1; i >= 0; i--)
                    {
                        if (priceRatings[i] < entryPointPrice && priceRatings[i] > 0)
                        {
                            leftBrokenItems += priceRatings[i];
                        }
                    }

                    for (int i = entryPoint + 1; i < priceRatings.Count; i++)
                    {
                        if (priceRatings[i] < entryPointPrice && priceRatings[i] > 0)
                        {
                            rightBrokenItems += priceRatings[i];
                        }
                    }
                }
                else if (typeOfPriceRatings == "negative")
                {
                    for (int i = entryPoint - 1; i >= 0; i--)
                    {
                        if (priceRatings[i] < entryPointPrice && priceRatings[i] < 0)
                        {
                            leftBrokenItems += priceRatings[i];
                        }
                    }

                    for (int i = entryPoint + 1; i < priceRatings.Count; i++)
                    {
                        if (priceRatings[i] < entryPointPrice && priceRatings[i] < 0)
                        {
                            rightBrokenItems += priceRatings[i];
                        }
                    }
                }
                else if (typeOfPriceRatings == "all")
                {
                    for (int i = entryPoint - 1; i >= 0; i--)
                    {
                        if (priceRatings[i] < entryPointPrice)
                        {
                            leftBrokenItems += priceRatings[i];
                        }
                    }

                    for (int i = entryPoint + 1; i < priceRatings.Count; i++)
                    {
                        if (priceRatings[i] < entryPointPrice)
                        {
                            rightBrokenItems += priceRatings[i];
                        }
                    }
                }
            }else if(typeOfItems== "expensive")
            {
                int entryPointPrice = priceRatings[entryPoint];
                if (typeOfPriceRatings == "positive")
                {
                    for (int i = entryPoint - 1; i >= 0; i--)
                    {
                        if (priceRatings[i] >= entryPointPrice && priceRatings[i] > 0)
                        {
                            leftBrokenItems += priceRatings[i];
                        }
                    }

                    for (int i = entryPoint + 1; i < priceRatings.Count; i++)
                    {
                        if (priceRatings[i] >= entryPointPrice && priceRatings[i] > 0)
                        {
                            rightBrokenItems += priceRatings[i];
                        }
                    }
                }
                else if (typeOfPriceRatings == "negative")
                {
                    for (int i = entryPoint - 1; i >= 0; i--)
                    {
                        if (priceRatings[i] >= entryPointPrice && priceRatings[i] < 0)
                        {
                            leftBrokenItems += priceRatings[i];
                        }
                    }

                    for (int i = entryPoint + 1; i < priceRatings.Count; i++)
                    {
                        if (priceRatings[i] >= entryPointPrice && priceRatings[i] < 0)
                        {
                            rightBrokenItems += priceRatings[i];
                        }
                    }
                }
                else if (typeOfPriceRatings == "all")
                {
                    for (int i = entryPoint - 1; i >= 0; i--)
                    {
                        if (priceRatings[i] >= entryPointPrice)
                        {
                            leftBrokenItems += priceRatings[i];
                        }
                    }

                    for (int i = entryPoint + 1; i < priceRatings.Count; i++)
                    {
                        if (priceRatings[i] >= entryPointPrice)
                        {
                            rightBrokenItems += priceRatings[i];
                        }
                    }
                }
            }

            if (leftBrokenItems >= rightBrokenItems)
            {
                Console.WriteLine($"Left - {leftBrokenItems}");
            }
            else
            {
                Console.WriteLine($"Right - {rightBrokenItems}");
            }
        }
    }
}
