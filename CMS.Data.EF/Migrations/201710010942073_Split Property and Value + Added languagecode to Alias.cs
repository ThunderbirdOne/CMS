namespace CMS.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SplitPropertyandValueAddedlanguagecodetoAlias : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PropertyValues", "BlockId", "dbo.ContentBlock");
            DropIndex("dbo.PropertyValues", new[] { "BlockId" });
            AddColumn("dbo.Aliases", "LanguageCode", c => c.String());
            DropColumn("dbo.PropertyValues", "BlockId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PropertyValues", "BlockId", c => c.Guid(nullable: false));
            DropColumn("dbo.Aliases", "LanguageCode");
            CreateIndex("dbo.PropertyValues", "BlockId");
            AddForeignKey("dbo.PropertyValues", "BlockId", "dbo.ContentBlock", "Id");
        }
    }
}
