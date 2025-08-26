using Microsoft.AspNetCore.Mvc;
using BookWarms.Models;
using BookWarms.Services;

namespace BookWarms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;
        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/review
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        // GET: api/review/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null) return NotFound("Review not found");

            return Ok(review);
        }

        // POST: api/review
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Review review)
        {
            var created = await _reviewService.AddReviewAsync(review);

            if (created == null)
                return BadRequest("Review can only be added if the book is marked as 'Read'.");

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/review/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Review review)
        {
            if (id != review.Id)
                return BadRequest("Id mismatch");

            var updated = await _reviewService.UpdateReviewAsync(review);
            if (!updated) return NotFound("Review not found");

            return Ok(review);
        }

        // DELETE: api/review/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _reviewService.DeleteReviewAsync(id);
            if (!deleted) return NotFound();

            return NoContent(); 
        }
    }
}
