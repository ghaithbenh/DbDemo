using Demo.Models;

namespace Demo.Services;

public interface IJwtService
{
    public string GenerateToken(User user);
}