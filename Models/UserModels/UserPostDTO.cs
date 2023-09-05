using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TypeLeague.Models.UserModels
{
    [Index(nameof(Email), IsUnique = true)] // Ensure Email is unique
    public class UserPostDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
