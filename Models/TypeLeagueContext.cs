using Microsoft.EntityFrameworkCore;
using TypeLeague.Models;

namespace TypeLeague.Models
{
    public class TypeLeagueContext : DbContext
    {
        public TypeLeagueContext(DbContextOptions<TypeLeagueContext> options) 
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; } = null!;

        public DbSet<TypeLeague.Models.MatchModel> MatchModel { get; set; } = default!;
    }
}
