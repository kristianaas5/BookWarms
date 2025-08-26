using BookWarms.Models;
using BookWarms.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookWarms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryService _libraryService;

        public LibraryController(LibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        // GET: api/Library/user/1
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserLibrary(int userId)
        {
            var library = await _libraryService.GetUserLibraryAsync(userId);
            return Ok(library);
        }

        // POST: api/Library
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Library library)
        {
            var created = await _libraryService.AddBookAsync(library.UserId, library.BookId, library.ShelfType);
            if (created == null) return BadRequest("Книгата вече е в библиотеката.");

            return CreatedAtAction(nameof(GetUserLibrary), new { userId = created.UserId }, created);
        }

        // PUT: api/Library/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShelf(int id, [FromBody] ShelfType newShelf)
        {
            var updated = await _libraryService.UpdateShelfAsync(id, newShelf);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        // DELETE: api/Library/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _libraryService.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
