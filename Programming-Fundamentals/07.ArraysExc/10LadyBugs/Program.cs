using System;
using System.Linq;

namespace _10LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] indexesOfLadybugs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] initialFieldSize = new int[fieldSize];
            for (int i = 0; i < initialFieldSize.Length; i++)
            {
                for (int z = 0; z < indexesOfLadybugs.Length; z++)
                {
                    if (indexesOfLadybugs[z] == i)
                    {
                        initialFieldSize[i] = 1;
                    }
                }
                
            }

            string input;

                while ((input = Console.ReadLine()) != "end")
                {
                string[] positionChanges = input.Split(" ").ToArray();

                int indexOfLadyBug = int.Parse(positionChanges[0]);
                string direction = positionChanges[1];
                int flightLength = int.Parse(positionChanges[2]);
             
                    if (indexOfLadyBug < initialFieldSize.Length && indexOfLadyBug >= 0 && initialFieldSize[indexOfLadyBug] == 1 && flightLength != 0)
                    {
                        initialFieldSize[indexOfLadyBug] = 0;
                        bool isLanded = false;
                        if (direction == "right")
                        {
                            while (isLanded != true &&
                            indexOfLadyBug + flightLength >= 0 &&
                            indexOfLadyBug + flightLength < initialFieldSize.Length)
                        {
                                if (initialFieldSize[indexOfLadyBug + flightLength] != 1)
                                {
                                    initialFieldSize[indexOfLadyBug + flightLength] = 1;
                                    isLanded = true;
                                }
                                flightLength += flightLength;
                            }
                        }
                        else
                        {
                            while (isLanded != true &&
                            indexOfLadyBug - flightLength >= 0 &&
                            indexOfLadyBug - flightLength < initialFieldSize.Length)
                            {
                                if (initialFieldSize[indexOfLadyBug - flightLength] != 1)
                                {
                                    initialFieldSize[indexOfLadyBug - flightLength] = 1;
                                    isLanded = true;
                                }
                                flightLength += flightLength;
                            }
                        }
                    }
                }
            for (int u = 0; u < initialFieldSize.Length; u++)
            {
                if (initialFieldSize[u] != 1)
                {
                    initialFieldSize[u] = 0;
                }
            }
            Console.WriteLine(string.Join(" ", initialFieldSize));
        }
        }
    }

