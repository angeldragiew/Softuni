using System;

namespace ImplementingList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();

            list.Add(399);
            list.Add(200);
            list.Add(200);
            list.Add(200);
            list.Insert(4, 13);
            Console.WriteLine("removing " + list.RemoveAt(3));
            Console.WriteLine("removing " + list.RemoveAt(2));
            Console.WriteLine("removing " + list.RemoveAt(1));
            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            Console.WriteLine(list.Contains(13));

            list.Swap(0, 1);
            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
        }
    }
}
