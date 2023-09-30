using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TypeLeague.Models.BetModels;
using TypeLeague.Models.MatchModels;
using TypeLeague.Models.UserModels;

namespace TypeLeague.Models
{
    public class TypeLeagueContext : IdentityDbContext<TypeLeagueUser>
    {
        public TypeLeagueContext(DbContextOptions<TypeLeagueContext> options) 
            : base(options)
        {
        }

        public DbSet<BetModel> BetModel { get; set; } = default!;
        public DbSet<MatchModel> MatchModel { get; set; } = default!;
    }
}
