using System;
using WebApplication1.BookData;
using WebApplication1.Services;
using Xunit;

namespace BookApiXTests
{
    public class ApiServicesTestFixtures
    {
        [Fact]
        public void AllTheBooksAreReturned()
        {
            BookServices Service = new BookServices();
            Response response = Service.GetBooks();
            Assert.Equal(200,response.StatusCode);
            
        }

        [Fact]
        public void BookIsReturned()
        {
            BookServices Service = new BookServices();
            Response response = Service.GetBookByID(1);
            Assert.Equal(200, response.StatusCode);

        }

        [Fact]
        public void NegativeIdReturnsErrorCode406()
        {
            BookServices Service = new BookServices();
            Response response = Service.GetBookByID(-1);
            Assert.Equal(406, response.StatusCode);

        }

        [Fact]
        public void WrongIdReturnsErrorCode404()
        {
            BookServices Service = new BookServices();
            Response response = Service.GetBookByID(45);
            Assert.Equal(404, response.StatusCode);

        }
        [Fact]
        public void BookIsRemoved()
        {
            BookServices Service = new BookServices();
            Response response = Service.RemoveBookById(1);
            Assert.Equal(200, response.StatusCode);

        }

        [Fact]
        public void NegativeRemoveIdReturnsErrorCode406()
        {
            BookServices Service = new BookServices();
            Response response = Service.RemoveBookById(-1);
            Assert.Equal(406, response.StatusCode);

        }

        [Fact]
        public void WrongRemoveIdReturnsErrorCode404()
        {
            BookServices Service = new BookServices();
            Response response = Service.RemoveBookById(45);
            Assert.Equal(404, response.StatusCode);

        }

        [Fact]
        public void AddingBookWorks()
        {
            Book book = new Book { Id = 1, Name = "AngelsandDemons", Author = "XinHo", Price = 4500.65 };
            BookServices Service = new BookServices();
            Response response = Service.AddBook(book);
            Assert.Equal(200,response.StatusCode);
        }

        [Fact]
        public void AddingInvalidBookReturns406()
        {
            Book book = new Book { Id = 1, Name = "Angels and Demons", Author = "Xing Ho", Price = 4500.65 };
            BookServices Service = new BookServices();
            Response response = Service.AddBook(book);
            Assert.Equal(406, response.StatusCode);
        }

        [Fact]
        public void AddingInvalidIDReturnsErrorList()
        {
            Book book = new Book { Id = -11, Name = "AngelsandDemons", Author = "XinHo", Price = 4500.65 };
            BookServices Service = new BookServices();
            Response response = Service.AddBook(book);
            Assert.Equal("The ID is Invalid, Only +VE values are allowed", response.ErrorList[0]);
        }

        [Fact]
        public void ModifiedBookReturns200ForValidBookModificaton()
        {
            Book book = new Book{ Id = 1, Name = "AngelsandDemons", Author = "XinHo", Price = 4500.65 };

            BookServices Service = new BookServices();
            Response response = Service.ModifyBookList(1,book);
            Assert.Equal(200, response.StatusCode);

        }

        [Fact]
        public void ModifiedBookReturns406ForInValidBookModificaton()
        {
            BookServices Service = new BookServices();
            Book book = new Book { Id = 1, Name = "Angels and Demons", Author = "XinHo", Price = 4500.65 };
            Response response = Service.ModifyBookList(1,book);
            Assert.Equal(406, response.StatusCode);

        }

        [Fact]
        public void ModifiedBookReturns404ForInValidID()
        {
            BookServices Service = new BookServices();
            Book book = new Book { Id = 1, Name = "AngelsandDemons", Author = "XinHo", Price = 4500.65 };

            Response response = Service.ModifyBookList(45,book);
            Assert.Equal(404, response.StatusCode);

        }

    }
}
