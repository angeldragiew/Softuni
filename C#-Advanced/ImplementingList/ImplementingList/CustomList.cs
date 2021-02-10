using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingList
{
    class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] array;

        public CustomList()
        {
            array = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return array[index];
            }
            set
            {
                ValidateIndex(index);
                array[index] = value;
            }
        }

        public void Add(int n)
        {
            if (Count == array.Length)
            {
                Resize();
            }
            array[Count] = n;
            Count++;
        }

        public int RemoveAt(int index)
        {
            ValidateIndex(index);
            int itemToRemove = array[index];
            array[index] = default;
            Shift(index);
            Count--;

            if (array.Length / 4 == Count)
            {
                Shrink();
            }

            return itemToRemove;
        }
        public void Insert(int index, int item)
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            if (Count == array.Length)
            {
                Resize();
            }
            ShiftRight(index);
            array[index] = item;
            Count++;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);

            int firstIndexValue = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = firstIndexValue;
        }

        private void Resize()
        {
            int[] resizedArray = new int[array.Length * 2];
            Array.Copy(array, resizedArray, Count);
            array = resizedArray;
        }

        private void Shrink()
        {
            int[] shrinkedArray = new int[array.Length / 2];
            Array.Copy(array, shrinkedArray, Count);
            array = shrinkedArray;
        }

        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[Count - 1] = default;
        }

        private void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        private void ValidateIndex(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
        }
    }
}
