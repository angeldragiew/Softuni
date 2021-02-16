using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> list;

        public CustomStack()
        {
            list = new List<T>();
        }

        public void Push(T element)
        {
            list.Add(element);
        }

        public T Pop()
        {
            if (list.Count <= 0)
            {
                throw new InvalidOperationException("No elements");
            }
            T elementToPop = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return elementToPop;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
