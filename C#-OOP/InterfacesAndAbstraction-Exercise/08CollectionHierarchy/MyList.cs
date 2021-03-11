using System;
using System.Collections.Generic;
using System.Text;

namespace _08CollectionHierarchy
{

    public class MyList : IMyList
    {
        private Stack<string> collection;
        public MyList()
        {
            collection = new Stack<string>();
        }
        public int Used => collection.Count;

        public IReadOnlyCollection<string> Collection => collection;

        public int Add(string item)
        {
            collection.Push(item);
            return 0;
        }

        public string Remove()
        {
            return collection.Pop();
        }
    }
}
