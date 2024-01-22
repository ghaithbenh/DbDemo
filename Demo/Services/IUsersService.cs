using Demo.Models;

namespace Demo.Services;

public interface IUsersService
{

    public Task<User> CreateUserAsync(User user);
    public Task<List<User>> GetUsersAsync();
    public string Login(User user);
}