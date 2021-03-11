using System;
using System.Collections.Generic;
using System.Text;

namespace _08CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private Queue<string> collection;
        public AddRemoveCollection()
        {
            collection = new Queue<string>();
        }
        public IReadOnlyCollection<string> Collection => collection;

        public int Add(string item)
        {
            collection.Enqueue(item);
            return 0;
        }

        public string Remove()
        {
            return collection.Dequeue();
        }
    }
}
