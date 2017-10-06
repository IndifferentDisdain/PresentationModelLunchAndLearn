using F23.PresentationModelLnL.Domain.CaseSheets;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseSheetDetails>().ToTable("VCaseSheetDetails");
        }
    }
}
