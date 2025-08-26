using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookWarms.Controllers;
using BookWarms.Models;
using BookWarms.Services;
using BookWarms.Data;

public class ReviewControllerTests
{
    private readonly ReviewController _controller;
    private readonly AppDbContext _context;

    public ReviewControllerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "ReviewTestDb")
            .Options;

        _context = new AppDbContext(options);

        // Изчистваме DB при стартиране на теста
        _context.Reviews.RemoveRange(_context.Reviews);
        _context.Libraries.RemoveRange(_context.Libraries);
        _context.Books.RemoveRange(_context.Books);
        _context.Users.RemoveRange(_context.Users);
        _context.SaveChanges();

        // Създаваме тестов User и Book
        var user = new User { Id = 1, Username = "TestUser" };
        var book = new Book { Id = 1, Title = "Test Book", Author = "Author", Genre = "Genre", Description = "Desc", PageCount = 123 };

        _context.Users.Add(user);
        _context.Books.Add(book);
        _context.Libraries.Add(new Library
        {
            Id = 1,
            UserId = 1,
            BookId = 1,
            ShelfType = ShelfType.Read // важно: само от Read рафт може да има Review
        });
        _context.SaveChanges();

        var reviewService = new ReviewService(_context);
        _controller = new ReviewController(reviewService);
    }

    [Fact]
    public async Task AddReview_Success_WhenBookIsRead()
    {
        var review = new Review { Id = 1, LibraryId = 1, ReviewText = "Great book!", Rating = 5 };

        var result = await _controller.Create(review);

        var createdAt = Assert.IsType<CreatedAtActionResult>(result);
        var returnedReview = Assert.IsType<Review>(createdAt.Value);

        Assert.Equal(review.ReviewText, returnedReview.ReviewText);
        Assert.Equal(5, returnedReview.Rating);
    }

    [Fact]
    public async Task GetReviews_ReturnsListOfReviews()
    {
        _context.Reviews.Add(new Review { Id = 2, LibraryId = 1, ReviewText = "Nice!", Rating = 4 });
        _context.SaveChanges();

        var result = await _controller.GetAll();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var reviews = Assert.IsType<List<Review>>(okResult.Value);

        Assert.True(reviews.Count >= 1);
    }

    [Fact]
    public async Task UpdateReview_ReturnsBadRequest_WhenIdMismatch()
    {
        var review = new Review { Id = 2, LibraryId = 1, ReviewText = "Mismatch", Rating = 3 };

        var result = await _controller.Update(1, review);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateReview_ReturnsNotFound_WhenReviewDoesNotExist()
    {
        var review = new Review { Id = 999, LibraryId = 1, ReviewText = "Not Found", Rating = 2 };

        var result = await _controller.Update(999, review);

        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("Review not found", notFoundResult.Value);
    }

    [Fact]
    public async Task DeleteReview_ReturnsNoContent_WhenReviewExists()
    {
        var review = new Review { Id = 3, LibraryId = 1, ReviewText = "To be deleted", Rating = 4 };
        _context.Reviews.Add(review);
        _context.SaveChanges();

        var result = await _controller.Delete(review.Id);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteReview_ReturnsNotFound_WhenReviewDoesNotExist()
    {
        var result = await _controller.Delete(9999);

        Assert.IsType<NotFoundResult>(result);
    }
}
