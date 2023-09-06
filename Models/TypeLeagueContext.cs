using Microsoft.EntityFrameworkCore;
using TypeLeague.Models;
using TypeLeague.Models.UserModels;

namespace TypeLeague.Models
{
    public class TypeLeagueContext : DbContext
    {
        public TypeLeagueContext(DbContextOptions<TypeLeagueContext> options) 
            : base(options)
        {
        }

        public DbSet<TypeLeague.Models.BetModel> BetModel { get; set; } = default!;
        public DbSet<TypeLeague.Models.MatchModel> MatchModel { get; set; } = default!;
        public DbSet<User> Users { get; set; } = null!;

        //Set default values for certain columns in User table (they must be nullable).
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Role)
                .HasDefaultValue("user");
            modelBuilder.Entity<User>()
                .Property(x => x.Points)
                .HasDefaultValue(0);
        }
    }
}
