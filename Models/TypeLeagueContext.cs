using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TypeLeague.Models.UserModels;

namespace TypeLeague.Models
{
    public class TypeLeagueContext : DbContext
    {
        public TypeLeagueContext(DbContextOptions<TypeLeagueContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

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
