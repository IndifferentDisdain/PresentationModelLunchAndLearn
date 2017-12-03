using F23.PresentationModelLnL.Domain.CaseSheets;
using F23.PresentationModelLnL.Domain.Locations;
using F23.PresentationModelLnL.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace F23.PresentationModelLnL.Repositories
{
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
            modelBuilder.Entity<CaseSheetDetails>().ToTable("VCaseSheetDetails");
            modelBuilder.Entity<ProductDetails>().ToTable("VProductDetails");
        }
    }
}
