using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("create")]
    [Authorize]
    public async Task<IActionResult> CreateUser(User user)
    {
        var createdUser = await _usersService.CreateUserAsync(user);

        return Created("create", createdUser);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _usersService.GetUsersAsync();

        return Ok(users);
    }

    [HttpPost("login")]
    public IActionResult Login(User user)
    {
        return Ok(_usersService.Login(user));
    }
}