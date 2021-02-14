using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList<string> linkedList = new CustomDoublyLinkedList<string>();
            //adding items
            linkedList.AddLast("two");
            linkedList.AddLast("three");
            linkedList.AddLast("four");
            linkedList.AddLast("five");

            linkedList.AddFirst("one");

            //removing items
            Console.WriteLine($"removed first: {linkedList.RemoveFirst()}");
            Console.WriteLine($"removed last: {linkedList.RemoveLast()}");

            //printing items with foreach
            linkedList.ForEach(item =>
            {
                Console.WriteLine(item);
            });

            //linkedlist items to array
            string[] arr = linkedList.ToArray();
            Console.WriteLine("LinkedListToarray:");
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
