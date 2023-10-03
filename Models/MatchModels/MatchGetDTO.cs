namespace TypeLeague.Models.MatchModels
{
    public class MatchGetDTO
    {
        public int Id { get; set; }
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set;}
    }
}
