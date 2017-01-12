

namespace DataLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DataLayer.Model;

    public partial class DbTestContext : DbContext
    {
        public DbTestContext()
            : base("name=DbTestContext")
        {
        }

        public virtual DbSet<DevTest> DevTests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DevTest>()
                .Property(e => e.AffiliateName)
                .IsUnicode(false);
        }
    }
}
