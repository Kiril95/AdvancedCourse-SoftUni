using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = new List<string>(authors);
        }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public IEnumerable<string> Authors { get; private set; }

        public int CompareTo(Book other)
        {
            if (this.Year.CompareTo(other.Year) != 0)
            {
                return this.Year.CompareTo(other.Year);
            }

            return this.Title.CompareTo(other.Title);
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
