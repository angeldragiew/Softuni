﻿using System;

namespace GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int item = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(item);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
