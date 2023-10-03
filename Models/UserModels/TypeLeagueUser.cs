using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TypeLeague.Models.UserModels
{
    public class TypeLeagueUser : IdentityUser
    {

        public int Points { get; set; }

        //navigation property specifies that one user can have many bets
        public virtual ICollection<BetModel> Bets { get; set; }
    }
}
