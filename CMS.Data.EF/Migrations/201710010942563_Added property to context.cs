namespace CMS.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedpropertytocontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        BlockId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContentBlock", t => t.BlockId)
                .Index(t => t.BlockId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Properties", "BlockId", "dbo.ContentBlock");
            DropIndex("dbo.Properties", new[] { "BlockId" });
            DropTable("dbo.Properties");
        }
    }
}
