using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList<T>
    {
        private int count = 0;
        private ListNode<T> head { get; set; }
        private ListNode<T> tail { get; set; }

        public void AddFirst(T value)
        {
            ListNode<T> node = new ListNode<T>(value);
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

        public void AddLast(T value)
        {
            ListNode<T> node = new ListNode<T>(value);
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

        public T RemoveFirst()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            count--;
            T valueToRemove = head.Value;
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

        public T RemoveLast()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            count--;
            T valueToRemove = tail.Value;
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

        public void ForEach(Action<T> action)
        {
            ListNode<T> currNode = head;
            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.Next;
            }
        }

        public T[] ToArray()
        {
            T[] arr = new T[count];

            ListNode<T> currNode = head;
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
