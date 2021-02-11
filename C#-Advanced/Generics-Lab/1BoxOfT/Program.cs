using System;
using System.Collections;
using System.Collections.Generic;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);

            Console.WriteLine(box.Count);

            Console.WriteLine("Removing " + box.Remove());
            Console.WriteLine("Removing " + box.Remove());

            Console.WriteLine(box.Count);
        }
    }
}
