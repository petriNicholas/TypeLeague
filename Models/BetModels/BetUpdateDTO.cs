namespace TypeLeague.Models.BetModels
{
    public class BetUpdateDTO
    {
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}
