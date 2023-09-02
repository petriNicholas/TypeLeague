using System.ComponentModel.DataAnnotations;

namespace TypeLeague.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Points { get; set; }
        
        //navigation property specifies that one user can have many bets
        //public ICollection<Bet> Bets { get; set; } = null!;
    }
}
