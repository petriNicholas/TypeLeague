using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TypeLeague.Models.UserModels
{
    public class LoginPostDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
