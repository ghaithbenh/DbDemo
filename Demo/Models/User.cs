using System.ComponentModel.DataAnnotations;

namespace Demo.Models;
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    [MinLength(6)]
    public required string Password { get; set; }
}
