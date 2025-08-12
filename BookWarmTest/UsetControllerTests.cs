using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookWarms.Controllers;
using BookWarms.Models;
using BookWarms.Services;
using BookWarms.Data;
using Microsoft.EntityFrameworkCore;

public class UserControllerTests 
{
    private readonly UserController _controller;
    private readonly AppDbContext _context;

    public UserControllerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
          .UseInMemoryDatabase(databaseName: "BookTestDb")
          .Options;

        _context = new AppDbContext(options);

        _context.Users.RemoveRange(_context.Users);
        _context.SaveChanges();

        var userService = new UserService(_context);
        _controller = new UserController(userService);
    }

    [Fact]
    public async Task AddUser_ReturnsOk_WithAddedUser()
    {
        var user = new User { Username = "Test", Email = "test@example.com" };
        var result = await _controller.AddUser(user);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedUser = Assert.IsType<User>(okResult.Value);
        Assert.Equal("Test", returnedUser.Username);
        Assert.Equal("test@example.com", returnedUser.Email);
    }

    [Fact]
    public async Task GetUsers_ReturnsOk_WithUsersList()
    {
        await _controller.AddUser(new User { Username = "Test", Email = "test@example.com" });
        var result = await _controller.GetUsers();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var users = Assert.IsType<List<User>>(okResult.Value);
        Assert.Single(users);
        Assert.Equal("Test", users[0].Username);
    }

    [Fact]
    public async Task GetUser_UserExists_ReturnsOk()
    {
        var addResult = await _controller.AddUser(new User { Username = "Test", Email = "test@example.com" });
        var addedUser = (User)((OkObjectResult)addResult).Value;

        var result = await _controller.GetUser(addedUser.Id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedUser = Assert.IsType<User>(okResult.Value);
        Assert.Equal(addedUser.Id, returnedUser.Id);
    }

    [Fact]
    public async Task GetUser_UserNotFound_ReturnsNotFound()
    {
        var result = await _controller.GetUser(999);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateUser_IdMismatch_ReturnsBadRequest()
    {
        var user = new User { Id = 2, Username = "Test", Email = "test@example.com" };
        var result = await _controller.UpdateUser(1, user);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task UpdateUser_UserNotFound_ReturnsNotFound()
    {
        var user = new User { Id = 999, Username = "Test", Email = "test@example.com" };
        var result = await _controller.UpdateUser(999, user);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateUser_Success_ReturnsOk()
    {
        var addResult = await _controller.AddUser(new User { Username = "Test", Email = "test@example.com" });
        var addedUser = (User)((OkObjectResult)addResult).Value;
        addedUser.Username = "Updated";

        var result = await _controller.UpdateUser(addedUser.Id, addedUser);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedUser = Assert.IsType<User>(okResult.Value);
        Assert.Equal("Updated", returnedUser.Username);
    }

    [Fact]
    public async Task DeleteUser_Success_ReturnsOk()
    {
        var addResult = await _controller.AddUser(new User { Username = "Test", Email = "test@example.com" });
        var addedUser = (User)((OkObjectResult)addResult).Value;

        var result = await _controller.DeleteUser(addedUser.Id);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteUser_NotFound_ReturnsNotFound()
    {
        var result = await _controller.DeleteUser(999);

        Assert.IsType<NotFoundResult>(result);
    }
}