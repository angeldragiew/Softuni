using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
            if (firstBook.Title != secondBook.Title)
            {
                return firstBook.Title.CompareTo(secondBook.Title);
            }
            return secondBook.Year.CompareTo(firstBook.Year);
        }
    }
}
