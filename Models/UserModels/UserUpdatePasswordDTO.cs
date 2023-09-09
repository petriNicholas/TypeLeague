using System.ComponentModel.DataAnnotations;

namespace TypeLeague.Models.UserModels
{
    public class UserUpdatePasswordDTO
    {
        [Required]
        public string NewPassword { get; set; } = null!;
        [Required(ErrorMessage = "You must provide your password to make changes to your account.")]
        public string Password { get; set; } = null!;
    }
}
