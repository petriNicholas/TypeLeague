using System.ComponentModel.DataAnnotations;

namespace TypeLeague.Models.UserModels
{
    public class UserPatchDTO
    {
        [EmailAddress]
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
