using BookWarms.Models;
using BookWarms.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookWarms.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _service;
        public ReviewController(ReviewService service) => _service = service;

        public record CreateReviewRequest(int LibraryId, int Rating, string ReviewText);
        public record BookReviewItemDto(int Id, int Rating, string ReviewText, DateTime Date, string Username);
        public record BookReviewsDto(double AverageRating, List<BookReviewItemDto> Reviews);

        [HttpGet("by-book/{bookId:int}")]
        public async Task<IActionResult> GetByBook(int bookId)
        {
            var items = await _service.GetBookReviewsAsync(bookId);
            var reviews = items.Select(r => new BookReviewItemDto(
                r.Id, r.Rating, r.ReviewText, r.Date, r.Library.User.Username)).ToList();
            var avg = reviews.Count == 0 ? 0.0 : Math.Round(reviews.Average(x => x.Rating), 1);
            return Ok(new BookReviewsDto(avg, reviews));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReviewRequest req)
        {
            if (req is null) return BadRequest("Invalid payload.");
            if (req.Rating < 1 || req.Rating > 5) return BadRequest("Rating must be between 1 and 5.");

            var review = new Review
            {
                LibraryId = req.LibraryId,
                Rating = req.Rating,
                ReviewText = req.ReviewText ?? string.Empty,
                Date = DateTime.UtcNow
            };
            var created = await _service.AddReviewAsync(review);
            return created is null
                ? BadRequest("Library item not found or not marked as Read.")
                : Ok(created);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
            => (await _service.DeleteReviewAsync(id)) ? NoContent() : NotFound();

        [HttpPost("{id:int}/restore")]
        public async Task<IActionResult> Restore(int id)
            => (await _service.RestoreReviewAsync(id)) ? Ok() : NotFound();
    }
}