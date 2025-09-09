using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BookWarms.Models;
using BookWarms.Services;

namespace BookWarms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        // create
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var addedBook = await _bookService.AddBookAsync(book);
            return Ok(addedBook);
        }

        // read (all)
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        // read (by id)
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return book is null ? NotFound() : Ok(book);
        }

        // search + sort + paginate
        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? q,
            [FromQuery] string? sortBy = "Title",
            [FromQuery] bool desc = false,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await _bookService.SearchAsync(q, sortBy, desc, page, pageSize);
            return Ok(result);
        }

        // update
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest("Book ID mismatch.");

            var updated = await _bookService.UpdateBookAsync(book);
            return updated ? Ok(book) : NotFound();
        }

        // delete (soft)
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var deleted = await _bookService.DeleteBookAsync(id);
            return deleted ? Ok() : NotFound();
        }
    }
}
