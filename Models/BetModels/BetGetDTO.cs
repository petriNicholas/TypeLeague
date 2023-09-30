namespace TypeLeague.Models.BetModels
{
    public class BetGetDTO
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
