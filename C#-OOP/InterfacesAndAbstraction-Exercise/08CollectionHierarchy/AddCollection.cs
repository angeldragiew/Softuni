using System;
using System.Collections.Generic;
using System.Text;

namespace _08CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        private List<string> collection;
        public AddCollection()
        {
            collection = new List<string>();
        }
        public IReadOnlyCollection<string> Collection => collection;

        public int Add(string item)
        {
            collection.Add(item);
            return collection.Count - 1;
        }
    }
}
