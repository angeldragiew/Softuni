﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        private T item;
        public Box(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            return $"{this.item.GetType().FullName}: {item}";
        }
    }
}
