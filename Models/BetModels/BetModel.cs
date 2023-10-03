using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TypeLeague.Models.BetModels
{
    public class BetModel
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int UserId { get; set; }
        public DateTime LastModified { get; set; } = DateTime.Now;

        // navigation properties
        public virtual UserModels.TypeLeagueUser User { get; set; }
        public virtual MatchModel Match { get; set; }
    }
}
