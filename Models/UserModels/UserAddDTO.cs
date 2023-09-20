using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TypeLeague.Models.UserModels
{
    [Index(nameof(Email), IsUnique = true)] // Ensure Email is unique
    public class UserAddDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
