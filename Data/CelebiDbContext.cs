using CelebiWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CelebiWebApi.Data
{
    public class CelebiDbContext : DbContext
    {
        public CelebiDbContext(DbContextOptions<CelebiDbContext> options) : base(options)
        {
        }

        public DbSet<Uye> Uye { get; set; }
        public DbSet<Brans> Brans { get; set; }
        public DbSet<AltBrans> AltBrans { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<UyePaket> UyePaket { get; set; }
        public DbSet<UyeAidat> UyeAidat { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().ToTable("_Personel");
        }
    }
}
