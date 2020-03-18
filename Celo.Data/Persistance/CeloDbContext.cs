using Microsoft.EntityFrameworkCore;
using Celo.Data.Interfaces;
using Celo.Data.Models;

namespace Celo.Data.Persistance
{
    public class CeloDbContext : DbContext, IDbContext
    {
        public CeloDbContext(DbContextOptions<CeloDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        //public DbSet<User> Users { get; set; }
        //public DbSet<ProfileImage> ProfileImages { get; set; }
    }
}
