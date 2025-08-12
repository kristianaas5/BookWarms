using Xunit;
//using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookWarms.Controllers;
using BookWarms.Models;
using BookWarms.Services;
using BookWarms.Data;
using Microsoft.EntityFrameworkCore;

public class BooksControllerTests
{
    private readonly BooksController _controller;
    private readonly AppDbContext _context;

    public BooksControllerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "BookTestDb")
            .Options;

        _context = new AppDbContext(options);

        // Изчиствам тука базата, ако има останали данни от предишни тестове
        _context.Books.RemoveRange(_context.Books);
        _context.SaveChanges();

        var bookService = new BookService(_context);
        _controller = new BooksController(bookService);
    }

    [Fact]
    public async Task AddBookTest()
    {
        var book = new Book { Id = 1, Title = "Test Book", Author = "Author", Genre = "Genre", Description = "Desc", PageCount = 123 };
        var result = await _controller.AddBook(book);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedBook = Assert.IsType<Book>(okResult.Value);
        Assert.Equal(book.Title, returnedBook.Title);
    }

    [Fact]
    public async Task GetBooks_ReturnsListOfBooks()
    {
        // Arrange
        _context.Books.Add(new Book { Id = 2, Title = "Existing Book", Author = "Author", Genre = "Genre", Description = "Desc", PageCount = 100 });
        _context.SaveChanges();

        // Act
        var result = await _controller.GetBooks();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var books = Assert.IsType<List<Book>>(okResult.Value);
        Assert.True(books.Count >= 1);
    }

    [Fact]
    public async Task UpdateBook_ReturnsBadRequest_WhenIdMismatch()
    {
        var book = new Book { Id = 2, Title = "Mismatch Book", Author = "A", Genre = "G", Description = "D", PageCount = 111 };

        var result = await _controller.UpdateBook(1, book);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateBook_ReturnsNotFound_WhenBookDoesNotExist()
    {
        var book = new Book { Id = 999, Title = "Not Found", Author = "A", Genre = "G", Description = "D", PageCount = 200 };

        var result = await _controller.UpdateBook(999, book);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteBook_ReturnsOk_WhenBookExists()
    {
        var book = new Book { Id = 3, Title = "Delete Me", Author = "Author", Genre = "Genre", Description = "Desc", PageCount = 90 };
        _context.Books.Add(book);
        _context.SaveChanges();

        var result = await _controller.DeleteBook(book.Id);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteBook_ReturnsNotFound_WhenBookDoesNotExist()
    {
        var result = await _controller.DeleteBook(9999);

        Assert.IsType<NotFoundResult>(result);
    }
}