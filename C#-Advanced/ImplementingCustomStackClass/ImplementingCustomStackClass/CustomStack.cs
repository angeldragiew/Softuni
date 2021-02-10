using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingCustomStackClass
{
    class CustomStack
    {
        private const int initialCapacity = 4;
        int[] array;
        int count;
        public CustomStack()
        {
            count = 0;
            array = new int[initialCapacity];
        }
        public int Count
        {
            get { return this.count; }
        }

        public void Push(int element)
        {
            if (count == array.Length)
            {
                Resize();
            }

            array[count] = element;
            count++;
        }
        //[1, 2, 3], 0, 0, 0, 0
        public int Pop()
        {
            ValidateCustomStack();
            int elementToRemove = array[count - 1];
            array[count - 1] = default;
            count--;
            return elementToRemove;
        }

        public int Peek()
        {
            ValidateCustomStack();

            int elementToPeek = array[count - 1];
            return elementToPeek;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(array[i]);
            }
        }

        private void Resize()
        {
            int[] resizedArray = new int[array.Length * 2];
            for (int i = 0; i < count; i++)
            {
                resizedArray[i] = array[i];
            }
            array = resizedArray;
        }

        private void ValidateCustomStack()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("The CustomStack is empty");
            }
        }
    }
}
