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
        public DbSet<Uye> Brans { get; set; }
        public DbSet<Uye> AltBrans { get; set; }
        public DbSet<Uye> Personel { get; set; }
        public DbSet<Uye> UyePaket { get; set; }
    }
}
