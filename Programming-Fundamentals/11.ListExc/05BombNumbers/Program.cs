using System;
using System.Collections.Generic;
using System.Linq;

namespace _05BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] numWithPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            bool isThereBombNum = true;
            while (isThereBombNum)
            {
                int power = numWithPower[1];

                int index = list.IndexOf(numWithPower[0]);
                list = RemoveLeft(list, power, index);

                index = list.IndexOf(numWithPower[0]);
                list = RemoveRight(list, power, index);

                list.RemoveAt(index);

                isThereBombNum = false;

                foreach (var item in list)
                {
                    if(numWithPower[0] == item)
                    {
                        isThereBombNum = true;
                    }
                }
            }
            Console.WriteLine(list.Sum());
        }

        private static List<int> RemoveRight(List<int> list, int power, int index)
        {
            for (int i = 1; i <= power; i++)
            {
                if (index + i >= 0 && index + i < list.Count)
                {
                    list[index + i] = 0;
                }
                else
                {
                    break;
                }
            }

            return list;
        }

        static List<int> RemoveLeft(List<int> list,int power, int index)
        {
            for (int i = 1; i <= power; i++)
            {
                if(index-i>=0 && index - i < list.Count)
                {
                    list[index - i] = 0;
                }
                else
                {
                    break;
                }
            }

            return list;
        }
    }
}
