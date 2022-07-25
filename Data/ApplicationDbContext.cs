using ChallengeAlkemy.Models.Domain;
using ChallengeAlkemy.Models.ModelsMTM;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAlkemy.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<CharacterSerie> CharacterSerie { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSerie>().HasKey(sc => new { sc.CharacterId, sc.SerieId });
        }

    }
}
