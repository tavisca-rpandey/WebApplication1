using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.BookData;

namespace WebApplication1.Services
{
    public class Validation
    {
        private bool _valid = true;
        public List<string> ErrList = new List<string>();
        public bool isValidBook(Book book)
        {
            IdIsValid(book.Id);
            NameIsValid(book.Name);
            PriceIsValid(book.Price);
            AuthorIsValid(book.Author);
            return _valid;
          
        }

        private void AuthorIsValid(string author)
        {
            var ans = author.All(Char.IsLetter);
            if (!ans)
            {
                _valid = false;
                ErrList.Add("The Name of Authors is Invalid, Only Alphabets are allowed");
            }
        }

        private void PriceIsValid(double price)
        {
            if (price < 0)
            {
                _valid = false;
                ErrList.Add("The Price is Invalid, Only +VE Numbers are allowed");
            }
            

        }

        private void NameIsValid(string name)
        {
            var ans = name.All(Char.IsLetter);
            if (!ans)
            {
                _valid = false;
                ErrList.Add("The Name of Book is Invalid, Only Alphabets are allowed");
            }
        }

        public bool IdIsValid(int id)
        {
            if (id > 0)
                return true;
            else
            {
                
               _valid = false;
               ErrList.Add("The ID is Invalid, Only +VE values are allowed");
               return false;
            }
        }
    }
}
