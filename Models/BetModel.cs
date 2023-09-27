using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TypeLeague.Models
{
    public class BetModel
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int UserId { get; set; }

        // navigation properties
        public virtual UserModels.User User { get; set; }
        public virtual MatchModel Match { get; set; }
    }
}
