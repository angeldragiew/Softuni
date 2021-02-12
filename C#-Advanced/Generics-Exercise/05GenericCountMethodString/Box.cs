using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodString
{
    public class Box<T>
        where T : IComparable
    {
        private T item;
        public Box(T item)
        {
            this.item = item;
        }

        public int Compare(T element)
        {
            return this.item.CompareTo(element);
        }

        public override string ToString()
        {
            return $"{this.item.GetType().FullName}: {item}";
        }
    }
}
