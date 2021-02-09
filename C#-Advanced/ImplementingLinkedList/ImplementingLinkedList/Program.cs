using System;

namespace ImplementingLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList linkedList = new CustomLinkedList();
            //adding items
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddFirst(5);

            //removing items
            Console.WriteLine($"removed first: {linkedList.RemoveFirst()}");
            Console.WriteLine($"removed last: {linkedList.RemoveLast()}");

            //printing items with foreach
            linkedList.ForEach(item =>
            {
                Console.WriteLine(item);
            });

            //linkedlist items to array
            int[] arr = linkedList.ToArray();
            Console.WriteLine("LinkedListToarray:");
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
