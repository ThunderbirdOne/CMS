using CMS.Data.EF.Entities;
using System;
using System.Data.Entity;

namespace CMS.Data.EF
{
    public class CMSContext : DbContext
    {
        public DbSet<Alias> Aliases {get; set;}
        public DbSet<Block> Blocks {get; set;}
        public DbSet<BlockType> BlockTypes { get; set; }
        public DbSet<BootstrapBlock> BootstrapBlocks {get; set; }
        public DbSet<ContentBlock> ContentBlocks { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PagePreset> PagePresets { get; set; }
        public DbSet<PageTypePreset> PageTypePresets { get; set; }
        public DbSet<PageType> PageTypes { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));

            #region Schema change

            modelBuilder.Entity<Alias>().ToTable("Aliases", "CMS");
            modelBuilder.Entity<Block>().ToTable("Blocks", "CMS");
            modelBuilder.Entity<BlockType>().ToTable("BlockTypes", "CMS");
            modelBuilder.Entity<BootstrapBlock>().ToTable("BootstrapBlocks", "CMS");
            modelBuilder.Entity<ContentBlock>().ToTable("ContentBlocks", "CMS");
            modelBuilder.Entity<Media>().ToTable("Media", "CMS");
            modelBuilder.Entity<Page>().ToTable("Pages", "CMS");
            modelBuilder.Entity<PagePreset>().ToTable("PagePresets", "CMS");
            modelBuilder.Entity<PageTypePreset>().ToTable("PageTypePresets", "CMS");
            modelBuilder.Entity<PageType>().ToTable("PageTypes", "CMS");
            modelBuilder.Entity<Property>().ToTable("Properties", "CMS");
            modelBuilder.Entity<PropertyValue>().ToTable("PropertyValues", "CMS");

            #endregion
        }
    }
}
