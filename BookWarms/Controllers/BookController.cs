using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookWarms.Models;
using BookWarms.Data;
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
        //create
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var addedBook = await _bookService.AddBookAsync(book);
            return Ok(addedBook);
        }
        //read
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }
        //update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest("Book ID mismatch.");

            var existingBook = await _bookService.GetBookByIdAsync(id);
            if (existingBook == null)
                return NotFound();

            var updated = await _bookService.UpdateBookAsync(book);
            return updated ? Ok(book) : StatusCode(500);
        }
        //delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var deleted = await _bookService.DeleteBookAsync(id);
            if (deleted)
            {
                return Ok();
            }
            else return NotFound();
        }

    }
}
