using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookWarms.Controllers;
using BookWarms.Models;
using BookWarms.Services;
using BookWarms.Data;

public class UserControllerTests
{
    private readonly AppDbContext _context;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("UserControllerTestsDb")
            .Options;

        _context = new AppDbContext(options);

        // Ensure a clean database for each test class instance
        _context.Users.RemoveRange(_context.Users);
        _context.Books.RemoveRange(_context.Books);
        _context.Reviews.RemoveRange(_context.Reviews);
        _context.Libraries.RemoveRange(_context.Libraries);
        _context.SaveChanges();

        var userService = new UserService(_context);
        var libraryService = new LibraryService(_context);
        var reviewService = new ReviewService(_context);

        _controller = new UserController(userService, libraryService, reviewService);
    }

    [Fact]
    public async Task AddUser_ReturnsOk_WithAddedUser()
    {
        var user = new User { Username = "Test", Email = "test@example.com" };
        var result = await _controller.AddUser(user);

        var ok = Assert.IsType<OkObjectResult>(result);
        var returned = Assert.IsType<User>(ok.Value);
        Assert.Equal("Test", returned.Username);
        Assert.Equal("test@example.com", returned.Email);
    }

    [Fact]
    public async Task GetUsers_ReturnsOk_WithUsersList()
    {
        await _controller.AddUser(new User { Username = "Test", Email = "test@example.com" });

        var result = await _controller.GetUsers();

        var ok = Assert.IsType<OkObjectResult>(result);
        var users = Assert.IsType<List<User>>(ok.Value);
        Assert.Single(users);
        Assert.Equal("Test", users[0].Username);
    }

    [Fact]
    public async Task GetUser_UserExists_ReturnsOk()
    {
        var addResult = await _controller.AddUser(new User { Username = "U1", Email = "u1@example.com" });
        var added = (User)((OkObjectResult)addResult).Value!;

        var result = await _controller.GetUser(added.Id);

        var ok = Assert.IsType<OkObjectResult>(result);
        var returned = Assert.IsType<User>(ok.Value);
        Assert.Equal(added.Id, returned.Id);
    }

    [Fact]
    public async Task GetUser_UserNotFound_ReturnsNotFound()
    {
        var result = await _controller.GetUser(9999);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateUser_IdMismatch_ReturnsBadRequest()
    {
        var user = new User { Id = 2, Username = "X", Email = "x@example.com" };
        var result = await _controller.UpdateUser(1, user);
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateUser_UserNotFound_ReturnsNotFound()
    {
        var user = new User { Id = 999, Username = "X", Email = "x@example.com" };
        var result = await _controller.UpdateUser(999, user);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateUser_Success_ReturnsOk()
    {
        var addResult = await _controller.AddUser(new User { Username = "Orig", Email = "o@example.com" });
        var added = (User)((OkObjectResult)addResult).Value!;
        added.Username = "Updated";

        var result = await _controller.UpdateUser(added.Id, added);

        var ok = Assert.IsType<OkObjectResult>(result);
        var returned = Assert.IsType<User>(ok.Value);
        Assert.Equal("Updated", returned.Username);
    }

    [Fact]
    public async Task DeleteUser_Success_ReturnsNoContent()
    {
        var addResult = await _controller.AddUser(new User { Username = "ToDelete", Email = "d@example.com" });
        var added = (User)((OkObjectResult)addResult).Value!;

        var result = await _controller.DeleteUser(added.Id);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteUser_NotFound_ReturnsNotFound()
    {
        var result = await _controller.DeleteUser(12345);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task RestoreUser_SoftDeleted_Succeeds()
    {
        var addResult = await _controller.AddUser(new User { Username = "Soft", Email = "soft@example.com" });
        var added = (User)((OkObjectResult)addResult).Value!;

        var del = await _controller.DeleteUser(added.Id);
        Assert.IsType<NoContentResult>(del);

        var restore = await _controller.RestoreUser(added.Id);
        Assert.IsType<OkResult>(restore);

        var get = await _controller.GetUser(added.Id);
        Assert.IsType<OkObjectResult>(get);
    }
}