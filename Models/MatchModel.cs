using System.ComponentModel.DataAnnotations;

namespace TypeLeague.Models
{
    public class MatchModel
    {
        public int Id { get; set; }
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public int HomeScore { get; set; } = 0;
        public int AwayScore { get; set;} = 0;
    }
}
