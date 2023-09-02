using Microsoft.EntityFrameworkCore;

namespace TypeLeague.Models
{
    public class TypeLeagueContext : DbContext
    {
        public TypeLeagueContext(DbContextOptions<TypeLeagueContext> options) 
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; } = null!;
    }
}
