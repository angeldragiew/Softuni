using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingLinkedList
{
    class CustomLinkedList
    {
        private int count = 0;
        private Node Head { get; set; }
        private Node Tail { get; set; }

        public void AddFirst(int value)
        {
            Node node = new Node(value);
            count++;
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Next = Head;
            Head.Previous = node;
            Head = node;
        }

        public void AddLast(int value)
        {
            Node node = new Node(value);
            count++;
            if (Tail == null)
            {
                Tail = node;
                Head = node;
                return;
            }

            Tail.Next = node;
            node.Previous = Tail;
            Tail = node;
        }

        public int RemoveFirst()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }
            int removedNode = Head.Value;
            count--;
            if (count == 1)
            {
                Head = null;
                Tail = null;
                return removedNode;
            }
            Head = Head.Next;
            Head.Previous = null;

            return removedNode;
        }

        public int RemoveLast()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }
            count--;
            int removedNode = Tail.Value;
            if (count == 1)
            {
                Head = null;
                Tail = null;
                return removedNode;
            }
            Tail = Tail.Previous;
            Tail.Next = null;

            return removedNode;
        }

        public void ForEach(Action<int> action)
        {
            Node currNode = Head;
            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.Next;
            }
        }

        public int[] ToArray()
        {
            int[] arr = new int[count];

            Node currNode = Head;
            int index = 0;
            while (currNode != null)
            {
                arr[index] = currNode.Value;
                index++;
                currNode = currNode.Next;
            }
            return arr;
        }
    }
}
