﻿using System.ComponentModel.DataAnnotations;

namespace TypeLeague.Models
{
    public class BetModel
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int UserId { get; set; }
    }
}
