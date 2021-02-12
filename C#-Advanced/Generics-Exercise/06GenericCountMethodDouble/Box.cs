using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDouble
{
    public class Box<T>
        where T : IComparable
    {
        private T value;
        public Box(T item)
        {
            this.value = item;
        }

        public T Value
        {
            get { return value; }
        }

        public int Compare(Box<T> element)
        {
            return this.value.CompareTo(element.value);
        }

        public override string ToString()
        {
            return $"{this.value.GetType().FullName}: {value}";
        }
    }
}
