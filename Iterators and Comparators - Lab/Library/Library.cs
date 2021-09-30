using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public IList<Book> Books { get; set; }

        public Library(params Book[] books)
        {
            Books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var item in Books)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
