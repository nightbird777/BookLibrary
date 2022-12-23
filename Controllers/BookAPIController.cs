using BookLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        [HttpGet]
        public async Task <ActionResult<List<Book>>> Get()//Get list of book
        {
            BookDB bookDb = new BookDB();
            List<Book> books = bookDb.getAllBooks();
            return books;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)//Get book by ID
        {
            BookDB bookDb = new BookDB();
            var book = bookDb.GetBookById(id);
            return book;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)//To update the book
        {
            BookDB bookDb = new BookDB();
            bookDb.BookEditSave(book);
        }

        [HttpPost]
        public void AddBooks([FromBody] Book book)//To create new book
        {
            BookDB bookDb = new BookDB();
            bookDb.BookEditSave(book);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)//To delete book
        {
            BookDB bookDb = new BookDB();
            bookDb.DeleteBook(id);
        }
    }
}
