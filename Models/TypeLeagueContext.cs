using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TypeLeague.Models;
using TypeLeague.Models.UserModels;

namespace TypeLeague.Models
{
    public class TypeLeagueContext : IdentityDbContext<TypeLeagueUser>
    {
        public TypeLeagueContext(DbContextOptions<TypeLeagueContext> options) 
            : base(options)
        {
        }

        public DbSet<TypeLeague.Models.BetModel> BetModel { get; set; } = default!;
        public DbSet<TypeLeague.Models.MatchModel> MatchModel { get; set; } = default!;
    }
}
