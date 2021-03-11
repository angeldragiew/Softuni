using System;
using System.Collections.Generic;
using System.Text;

namespace _08CollectionHierarchy
{
    public interface IMyList : IAddRemoveCollection
    {
        public int Used { get; }
    }
}
