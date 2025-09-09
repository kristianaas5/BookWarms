using Microsoft.AspNetCore.Mvc;
using BookWarms.Models;
using BookWarms.Services;

namespace BookWarms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly LibraryService _libraryService;
        private readonly ReviewService _reviewService;

        public UserController(UserService userService, LibraryService libraryService, ReviewService reviewService)
        {
            _userService = userService;
            _libraryService = libraryService;
            _reviewService = reviewService;
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var addedUser = await _userService.AddUserAsync(user);
            return Ok(addedUser);
        }

        // Read all
        [HttpGet]
        public async Task<IActionResult> GetUsers() => Ok(await _userService.GetAllUsersAsync());

        // Read by id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        // ----- Library endpoints -----
        [HttpGet("{id:int}/library")]
        public async Task<IActionResult> GetUserLibrary(int id)
            => Ok(await _libraryService.GetUserLibraryAsync(id));

        public record AddLibraryItemRequest(int BookId, ShelfType ShelfType);
        [HttpPost("{id:int}/library")]
        public async Task<IActionResult> AddToLibrary(int id, [FromBody] AddLibraryItemRequest req)
        {
            var added = await _libraryService.AddBookAsync(id, req.BookId, req.ShelfType);
            if (added is null) return Conflict("Book already in library or invalid.");
            return Ok(added);
        }

        public record UpdateShelfRequest(ShelfType ShelfType);
        [HttpPut("{id:int}/library/{libraryId:int}/shelf")]
        public async Task<IActionResult> UpdateShelf(int id, int libraryId, [FromBody] UpdateShelfRequest req)
        {
            var updated = await _libraryService.UpdateShelfAsync(libraryId, req.ShelfType);
            if (updated is null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:int}/library/{libraryId:int}")]
        public async Task<IActionResult> DeleteLibraryItem(int id, int libraryId)
        {
            var ok = await _libraryService.DeleteAsync(libraryId);
            return ok ? NoContent() : NotFound();
        }
        // -----------------------------

        // Update
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id) return BadRequest("User ID mismatch.");

            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null) return NotFound();

            var updated = await _userService.UpdateUserAsync(user);
            return updated ? Ok(user) : StatusCode(500);
        }

        // Delete (soft)
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteUserAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // Reviews
        [HttpGet("{id:int}/reviews")]
        public async Task<IActionResult> GetUserReviews(int id)
            => Ok(await _reviewService.GetUserReviewsAsync(id));
    }
}