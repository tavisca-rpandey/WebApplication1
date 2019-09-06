using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.BookData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        BookServices Services = new BookServices();
        // GET: api/values
        [HttpGet]
        public ActionResult Get()
        {
            var response = Services.GetBooks();

            return StatusCode(response.StatusCode,response);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var response = Services.GetBookByID(id);
            return StatusCode(response.StatusCode, response);

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]Book book)
        {
            var response = Services.AddBook(book);
            return StatusCode(response.StatusCode,response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Book book)
        {
            var response = Services.ModifyBookList(id, book);
            return StatusCode(response.StatusCode, response);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var response = Services.RemoveBookById(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
