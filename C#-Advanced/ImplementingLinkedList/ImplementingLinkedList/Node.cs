using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingLinkedList
{
    class Node
    {
        public Node(int n)
        {
            Value = n;
        }
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
}
