using F23.PresentationModelLnL.Domain;
using F23.PresentationModelLnL.Domain.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace F23.PresentationModelLnL.Repositories
{
    /// <summary>
    /// Our EF context. Note this  is only public b/c I need to access is via the dependency manager,
    /// which is the only project that has a reference to this project.
    /// </summary>
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CaseSheetDetails> CaseSheetDetails { get; set; }

        public DbSet<CaseSheetProduct> CaseSheetProducts { get; set; }

        public DbSet<CaseSheet> CaseSheets { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<ProductDetails> ProductDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseSheetDetails>().ToTable("CaseSheetDetails");
            modelBuilder.Entity<ProductDetails>().ToTable("ProductDetails");
        }
    }
}
