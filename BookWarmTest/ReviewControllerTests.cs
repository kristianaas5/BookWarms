using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookWarms.Controllers;
using BookWarms.Services;
using BookWarms.Data;
using BookWarms.Models;
using System;

public class ReviewControllerTests
{
    private static (ReviewController controller, AppDbContext ctx, int libraryId, int bookId) CreateControllerSetup()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase($"ReviewControllerTestsDb_{Guid.NewGuid()}")
            .Options;

        var ctx = new AppDbContext(options);

        var user = new User { Username = "U", Email = "u@example.com" };
        var book = new Book { Title = "T", Author = "A", Genre = "G", Description = "D", PageCount = 100 };
        ctx.Users.Add(user);
        ctx.Books.Add(book);
        ctx.SaveChanges();

        var lib = new Library
        {
            UserId = user.Id,
            BookId = book.Id,
            ShelfType = ShelfType.Read
        };
        ctx.Libraries.Add(lib);
        ctx.SaveChanges();

        var controller = new ReviewController(new ReviewService(ctx));
        return (controller, ctx, lib.Id, book.Id);
    }

    [Fact]
    public async Task CreateReview_Success_ReturnsOk()
    {
        var (controller, _, libraryId, _) = CreateControllerSetup();

        var req = new ReviewController.CreateReviewRequest(libraryId, 5, "Great");
        var result = await controller.Create(req);

        var ok = Assert.IsType<OkObjectResult>(result);
        var review = Assert.IsType<Review>(ok.Value);
        Assert.Equal(5, review.Rating);
        Assert.Equal("Great", review.ReviewText);
        Assert.False(review.IsDeleted);
    }

    [Fact]
    public async Task GetByBook_ReturnsReviewsWithAverage()
    {
        var (controller, _, libraryId, bookId) = CreateControllerSetup();

        await controller.Create(new ReviewController.CreateReviewRequest(libraryId, 4, "Nice"));
        await controller.Create(new ReviewController.CreateReviewRequest(libraryId, 2, "Ok"));

        var result = await controller.GetByBook(bookId);
        var ok = Assert.IsType<OkObjectResult>(result);
        var dto = Assert.IsType<ReviewController.BookReviewsDto>(ok.Value);

        Assert.Equal(2, dto.Reviews.Count);
        Assert.InRange(dto.AverageRating, 2.9, 3.1); // 3.0 average
    }

    [Fact]
    public async Task Delete_And_Restore_Works()
    {
        var (controller, _, libraryId, bookId) = CreateControllerSetup();

        var create = await controller.Create(new ReviewController.CreateReviewRequest(libraryId, 5, "Temp"));
        var review = (Review)((OkObjectResult)create).Value!;

        var del = await controller.Delete(review.Id);
        Assert.IsType<NoContentResult>(del);

        // After delete it should disappear from list
        var afterDelete = await controller.GetByBook(bookId);
        var okAfterDelete = Assert.IsType<OkObjectResult>(afterDelete);
        var dtoAfterDelete = Assert.IsType<ReviewController.BookReviewsDto>(okAfterDelete.Value);
        Assert.DoesNotContain(dtoAfterDelete.Reviews, r => r.Id == review.Id);

        var restore = await controller.Restore(review.Id);
        Assert.IsType<OkResult>(restore);

        var afterRestore = await controller.GetByBook(bookId);
        var okAfterRestore = Assert.IsType<OkObjectResult>(afterRestore);
        var dtoAfterRestore = Assert.IsType<ReviewController.BookReviewsDto>(okAfterRestore.Value);
        Assert.Contains(dtoAfterRestore.Reviews, r => r.Id == review.Id);
    }

    [Fact]
    public async Task CreateReview_InvalidRating_ReturnsBadRequest()
    {
        var (controller, _, libraryId, _) = CreateControllerSetup();

        var result = await controller.Create(new ReviewController.CreateReviewRequest(libraryId, 0, "Bad"));
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task CreateReview_InvalidLibrary_ReturnsBadRequest()
    {
        var (controller, _, _, _) = CreateControllerSetup();

        var result = await controller.Create(new ReviewController.CreateReviewRequest(99999, 5, "Ghost"));
        Assert.IsType<BadRequestObjectResult>(result);
    }
}
