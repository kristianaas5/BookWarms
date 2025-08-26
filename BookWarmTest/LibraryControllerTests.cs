using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookWarms.Controllers;
using BookWarms.Models;
using BookWarms.Services;
using BookWarms.Data;
using Microsoft.EntityFrameworkCore;

public class LibraryControllerTests
{
    private readonly LibraryController _controller;
    private readonly AppDbContext _context;

    public LibraryControllerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "LibraryTestDb")
            .Options;

        _context = new AppDbContext(options);

        // Изчистваме базата преди всеки тест
        _context.Libraries.RemoveRange(_context.Libraries);
        _context.Books.RemoveRange(_context.Books);
        _context.Users.RemoveRange(_context.Users);
        _context.SaveChanges();

        var service = new LibraryService(_context);
        _controller = new LibraryController(service);
    }

    [Fact]
    public async Task AddBook_AddsToLibrary_WhenValid()
    {
        var user = new User { Id = 1, Username = "TestUser", Email = "test@test.com" };
        var book = new Book { Id = 1, Title = "Book", Author = "Author", Genre = "Genre", Description = "Desc", PageCount = 100 };
        _context.Users.Add(user);
        _context.Books.Add(book);
        _context.SaveChanges();

        var library = new Library { UserId = user.Id, BookId = book.Id, ShelfType = ShelfType.WantToRead };

        var result = await _controller.AddBook(library);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returned = Assert.IsType<Library>(createdResult.Value);
        Assert.Equal(user.Id, returned.UserId);
        Assert.Equal(book.Id, returned.BookId);
    }

    [Fact]
    public async Task AddBook_ReturnsBadRequest_WhenAlreadyExists()
    {
        var user = new User { Id = 2, Username = "User2", Email = "u2@test.com" };
        var book = new Book { Id = 2, Title = "Book2", Author = "Auth", Genre = "Genre", Description = "D", PageCount = 150 };
        _context.Users.Add(user);
        _context.Books.Add(book);
        _context.Libraries.Add(new Library { UserId = user.Id, BookId = book.Id, ShelfType = ShelfType.WantToRead });
        _context.SaveChanges();

        var duplicate = new Library { UserId = user.Id, BookId = book.Id, ShelfType = ShelfType.CurrentlyReading };

        var result = await _controller.AddBook(duplicate);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task GetUserLibrary_ReturnsBooks()
    {
        var user = new User { Id = 3, Username = "User3", Email = "u3@test.com" };
        var book = new Book { Id = 3, Title = "Book3", Author = "Auth", Genre = "Genre", Description = "D", PageCount = 180 };
        _context.Users.Add(user);
        _context.Books.Add(book);
        _context.Libraries.Add(new Library { UserId = user.Id, BookId = book.Id, ShelfType = ShelfType.CurrentlyReading });
        _context.SaveChanges();

        var result = await _controller.GetUserLibrary(user.Id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var libraries = Assert.IsType<List<Library>>(okResult.Value);
        Assert.Single(libraries);
    }

    [Fact]
    public async Task GetUserLibrary_ReturnsEmpty_WhenNoBooks()
    {
        var user = new User { Id = 4, Username = "User4", Email = "u4@test.com" };
        _context.Users.Add(user);
        _context.SaveChanges();

        var result = await _controller.GetUserLibrary(user.Id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var libraries = Assert.IsType<List<Library>>(okResult.Value);
        Assert.Empty(libraries);
    }

    [Fact]
    public async Task UpdateShelf_ChangesShelfType_WhenValid()
    {
        var user = new User { Id = 5, Username = "User5", Email = "u5@test.com" };
        var book = new Book { Id = 5, Title = "Book5", Author = "Auth", Genre = "Genre", Description = "D", PageCount = 220 };
        var library = new Library { Id = 10, UserId = user.Id, BookId = book.Id, ShelfType = ShelfType.WantToRead };

        _context.Users.Add(user);
        _context.Books.Add(book);
        _context.Libraries.Add(library);
        _context.SaveChanges();

        var result = await _controller.UpdateShelf(library.Id, ShelfType.Read);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var updated = Assert.IsType<Library>(okResult.Value);
        Assert.Equal(ShelfType.Read, updated.ShelfType);
    }

    [Fact]
    public async Task UpdateShelf_ReturnsNotFound_WhenInvalidId()
    {
        var result = await _controller.UpdateShelf(999, ShelfType.Read);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Delete_RemovesLibraryEntry_WhenExists()
    {
        var user = new User { Id = 6, Username = "User6", Email = "u6@test.com" };
        var book = new Book { Id = 6, Title = "Book6", Author = "Auth", Genre = "Genre", Description = "D", PageCount = 300 };
        var library = new Library { Id = 20, UserId = user.Id, BookId = book.Id, ShelfType = ShelfType.WantToRead };

        _context.Users.Add(user);
        _context.Books.Add(book);
        _context.Libraries.Add(library);
        _context.SaveChanges();

        var result = await _controller.Delete(library.Id);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNotFound_WhenDoesNotExist()
    {
        var result = await _controller.Delete(9999);

        Assert.IsType<NotFoundResult>(result);
    }
}
