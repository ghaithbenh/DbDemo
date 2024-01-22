using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data;

public class UserDbContext : DbContext
{

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }


    public DbSet<User> Users { get; set; }
}