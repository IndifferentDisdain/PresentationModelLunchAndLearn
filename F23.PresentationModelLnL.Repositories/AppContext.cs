using System;
using System.Collections.Generic;
using System.Text;
using F23.PresentationModelLnL.Domain.CaseSheets;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace F23.PresentationModelLnL.Repositories
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CaseSheetDetails> CaseSheetDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseSheetDetails>().ToTable("VCaseSheetDetails");
        }
    }
}
