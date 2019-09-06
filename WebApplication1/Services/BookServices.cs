using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.BookData;

namespace WebApplication1.Services
{

    public class BookServices
    {
        private BookStore _bookData = new BookStore();
        private Validation _validity = new Validation();
        private Response response = new Response();

        public Response GetBooks()
        {
            response.Data = _bookData.GetBookList();
            response.Message = "Success";
            response.StatusCode = 200;
            response.ErrorList = null;
            return response;
        }

        public Response GetBookByID(int id)
        {
            if (_validity.IdIsValid(id))
            {
                foreach (var book in _bookData.GetBookList())
                {
                    if (book.Id == id)
                    {
                        response.Data = book;
                        response.StatusCode = 200;
                        response.Message = "Success";
                        response.ErrorList = null;
                        return response;
                    }
                }
                response.Data = null;
                response.StatusCode = 404;
                response.Message = "Book Not Found";
                response.ErrorList.Add("The ID entered was not found in the BookStore");
                return response;
            }
            response.Data = null;
            response.StatusCode = 406;
            response.Message = "Invalid ID, ID cannot be negative";
            response.ErrorList.Add("Invalid ID, ID cannot be negative");
            return response;
        }

        public Response AddBook(Book book)
        {
            if (_validity.isValidBook(book))
            {
                _bookData.Add(book);
                response.Data = _bookData.GetBookList();
                response.ErrorList = null;
                response.Message = "Success";
                response.StatusCode = 200;
                return response;

            }
            else
            {
                response.Data = null;
                response.StatusCode = 406;
                response.Message = "Invalid Data Entered, Check Error List for Details";
                response.ErrorList= _validity.ErrList;
                return response;
            }

        }
        public Response ModifyBookList(int id, Book newBook)
        {
            if (_validity.isValidBook(newBook))
            {
                foreach (var book in _bookData.GetBookList())
                {
                    if (book.Id == id)
                    {
                        book.Name = newBook.Name;
                        book.Id = newBook.Id;
                        book.Author = newBook.Author;
                        book.Price = newBook.Price;


                        response.Data = _bookData.GetBookList();
                        response.ErrorList = null;
                        response.Message = "Success";
                        response.StatusCode = 200;
                        return response;
                    }
                }

                response.Data = null;
                response.StatusCode = 404;
                response.Message = "Book Not Found";
                response.ErrorList.Add("The ID entered was not found in the BookStore");
                return response;
            }

            response.Data = null;
            response.StatusCode = 406;
            response.Message = "Invalid Data Entered, Check Error List for Details";
            response.ErrorList = _validity.ErrList;
            return response;
        }
    }
}
