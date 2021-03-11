using System;
using System.Collections.Generic;
using System.Text;

namespace _08CollectionHierarchy
{
    public interface IAddCollection
    {
        int Add(string item);
        IReadOnlyCollection<string> Collection { get; }
    }
}
