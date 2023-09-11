using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TypeLeague.Models.UserModels
{
    public class User
    {
        public int UserId { get; set; }
        public string? Role { get; set; }

        public string Email { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int Points { get; set; }

        //navigation property specifies that one user can have many bets
        public ICollection<BetModel> Bets { get; set; } = null!;
    }
}
