namespace CMS.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedlinkbetweenblocksandpages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blocks", "PageId", c => c.Guid());
            CreateIndex("dbo.Blocks", "PageId");
            AddForeignKey("dbo.Blocks", "PageId", "dbo.Pages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blocks", "PageId", "dbo.Pages");
            DropIndex("dbo.Blocks", new[] { "PageId" });
            DropColumn("dbo.Blocks", "PageId");
        }
    }
}
