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

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
            => Ok(await _userService.AddUserAsync(user));

        [HttpGet]
        public async Task<IActionResult> GetUsers()
            => Ok(await _userService.GetAllUsersAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpGet("{id:int}/library")]
        public async Task<IActionResult> GetUserLibrary(int id)
            => Ok(await _libraryService.GetUserLibraryAsync(id));

        public record AddLibraryItemRequest(int BookId, ShelfType ShelfType);
        [HttpPost("{id:int}/library")]
        public async Task<IActionResult> AddToLibrary(int id, [FromBody] AddLibraryItemRequest req)
        {
            var added = await _libraryService.AddBookAsync(id, req.BookId, req.ShelfType);
            return added is null ? Conflict("Book already in library or invalid.") : Ok(added);
        }

        public record UpdateShelfRequest(ShelfType ShelfType);
        [HttpPut("{id:int}/library/{libraryId:int}/shelf")]
        public async Task<IActionResult> UpdateShelf(int id, int libraryId, [FromBody] UpdateShelfRequest req)
        {
            var updated = await _libraryService.UpdateShelfAsync(libraryId, req.ShelfType);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id:int}/library/{libraryId:int}")]
        public async Task<IActionResult> DeleteLibraryItem(int id, int libraryId)
            => (await _libraryService.DeleteAsync(libraryId)) ? NoContent() : NotFound();

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id) return BadRequest("User ID mismatch.");
            var existing = await _userService.GetUserByIdAsync(id);
            if (existing == null) return NotFound();
            return (await _userService.UpdateUserAsync(user)) ? Ok(user) : StatusCode(500);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
            => (await _userService.DeleteUserAsync(id)) ? NoContent() : NotFound();

        [HttpPost("{id:int}/restore")]
        public async Task<IActionResult> RestoreUser(int id)
            => (await _userService.RestoreUserAsync(id)) ? Ok() : NotFound();

        [HttpGet("{id:int}/reviews")]
        public async Task<IActionResult> GetUserReviews(int id)
            => Ok(await _reviewService.GetUserReviewsAsync(id));

        [HttpGet("{id:int}/stats")]
        public async Task<IActionResult> GetUserStats(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null) return NotFound();
            return Ok(await _reviewService.GetUserReadingStatsAsync(id));
        }
    }
}