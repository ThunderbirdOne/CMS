using CMS.Data.EF.Entities;
using System;
using System.Data.Entity;

namespace CMS.Data.EF
{
    public class CMSContext : DbContext
    {
        public DbSet<Alias> Aliases {get; set;}
        public DbSet<Block> Blocks {get; set;}
        public DbSet<BootstrapBlock> BootstrapBlocks {get; set; }
        public DbSet<ContentBlock> ContentBlocks { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageType> PageTypes { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
