using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.BookData
{
    public class BookStore
    {
        private List<Book> _bookList = new List<Book>();
        public BookStore()
        {
            _bookList.Add(new Book { Id = 1, Name = "Angels and Demons", Author = "Xing Ho", Price = 4500.65 });
            _bookList.Add(new Book { Id = 2, Name = "The matrix", Author = "Xing Ho", Price = 4500.65 });
            _bookList.Add(new Book { Id = 3, Name = "FairyTail", Author = "Xing Ho", Price = 4500.65 });

        }
        public List<Book> GetBookList()
        {
            return _bookList;
        }

        public void Add(Book book)
        {
            _bookList.Add(book);

        }

        public void RemoveAt(int i)
        {
            _bookList.RemoveAt(i);
        }
    }
}
