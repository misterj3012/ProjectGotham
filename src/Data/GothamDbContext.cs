using Microsoft.EntityFrameworkCore;
using ProjectGotham.Models;

namespace ProjectGotham.Data
{
    public class GothamDbContext : DbContext
    {
        public GothamDbContext(DbContextOptions<GothamDbContext> options) : base(options) { }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<CharacterModel> Characters { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountModel>()
            .HasMany(a => a.Characters)
            .WithOne(c => c.Account)
            .HasForeignKey(c => c.AccountID);
        }
    }
}
