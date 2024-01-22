using Demo.Data;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services;

public class UsersService : IUsersService
{
    private readonly UserDbContext _userDbContext;
    private readonly IJwtService _jwtService;

    public UsersService(UserDbContext userDbContext, IJwtService jwtService)
    {
        _userDbContext = userDbContext;
        _jwtService = jwtService;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        var hashedPasswordUser = new User
        {
            Email = user.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
        };

        await _userDbContext.Users.AddAsync(hashedPasswordUser);
        await _userDbContext.SaveChangesAsync();

        return hashedPasswordUser;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _userDbContext.Users.ToListAsync();
    }


    public string Login(User user)
    {
        var token = _jwtService.GenerateToken(user);
        return token;
    }
}