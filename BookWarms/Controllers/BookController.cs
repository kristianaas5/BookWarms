using Microsoft.AspNetCore.Mvc;
using BookWarms.Models;
using BookWarms.Services;

namespace BookWarms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        public BooksController(BookService bookService) => _bookService = bookService;

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
            => Ok(await _bookService.AddBookAsync(book));

        [HttpGet]
        public async Task<IActionResult> GetBooks()
            => Ok(await _bookService.GetAllBooksAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return book is null ? NotFound() : Ok(book);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? q,
            [FromQuery] string? sortBy = "Title",
            [FromQuery] bool desc = false,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
            => Ok(await _bookService.SearchAsync(q, sortBy, desc, page, pageSize));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest("Book ID mismatch.");
            var updated = await _bookService.UpdateBookAsync(book);
            return updated ? Ok(book) : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
            => (await _bookService.DeleteBookAsync(id)) ? NoContent() : NotFound();

        [HttpPost("{id:int}/restore")]
        public async Task<IActionResult> RestoreBook(int id)
            => (await _bookService.RestoreBookAsync(id)) ? Ok() : NotFound();
    }
}
