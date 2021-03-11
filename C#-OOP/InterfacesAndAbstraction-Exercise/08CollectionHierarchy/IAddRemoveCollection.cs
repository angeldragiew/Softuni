using System;
using System.Collections.Generic;
using System.Text;

namespace _08CollectionHierarchy
{
    public interface IAddRemoveCollection : IAddCollection
    {
        string Remove();
    }
}
