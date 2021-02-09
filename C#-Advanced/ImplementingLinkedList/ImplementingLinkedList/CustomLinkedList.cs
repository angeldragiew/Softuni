using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingLinkedList
{
    class CustomLinkedList
    {
        private int count = 0;
        private Node head { get; set; }
        private Node tail { get; set; }

        public void AddFirst(int value)
        {
            Node node = new Node(value);
            count++;
            if (head == null)
            {
                head = node;
                tail = node;
                return;
            }

            node.Next = head;
            head.Previous = node;
            head = node;
        }

        public void AddLast(int value)
        {
            Node node = new Node(value);
            count++;
            if (tail == null)
            {
                tail = node;
                head = node;
                return;
            }

            tail.Next = node;
            node.Previous = tail;
            tail = node;
        }

        public int RemoveFirst()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            count--;
            int valueToRemove = head.Value;
            head = head.Next;
            if (head != null)
            {
                head.Previous = null;
            }
            else
            {
                tail = null;
            }

            return valueToRemove;
        }

        public int RemoveLast()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            count--;
            int valueToRemove = tail.Value;
            tail = tail.Previous;
            if (tail != null)
            {
                tail.Next = null;
            }
            else
            {
                head = null;
            }

            return valueToRemove;
        }

        public void ForEach(Action<int> action)
        {
            Node currNode = head;
            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.Next;
            }
        }

        public int[] ToArray()
        {
            int[] arr = new int[count];

            Node currNode = head;
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
