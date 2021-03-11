using System;

namespace _08CollectionHierarchy
{
   public  class Program
    {
        public static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            AddToCollection(addCollection, words);
            AddToCollection(addRemoveCollection, words);
            AddToCollection(myList, words);

            int n = int.Parse(Console.ReadLine());
            RemoveFromColection(addRemoveCollection, n);
            RemoveFromColection(myList, n);
        }

        public static void AddToCollection(IAddCollection collection, string[] words)
        {
            foreach (var word in words)
            {
                Console.Write($"{collection.Add(word)} ");
            }
            Console.WriteLine();
        }

        public static void RemoveFromColection(IAddRemoveCollection collection, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{collection.Remove()} ");
            }
            Console.WriteLine();
        }
    }
}
