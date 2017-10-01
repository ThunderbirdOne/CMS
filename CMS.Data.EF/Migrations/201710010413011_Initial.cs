namespace CMS.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aliases",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Url = c.String(),
                        PageId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        ParentPageId = c.Guid(),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                        Type_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pages", t => t.ParentPageId)
                .ForeignKey("dbo.PageTypes", t => t.Type_Id)
                .Index(t => t.ParentPageId)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.PageTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.String(),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                        ParentBlockId = c.Guid(),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blocks", t => t.ParentBlockId)
                .Index(t => t.ParentBlockId);
            
            CreateTable(
                "dbo.PropertyValues",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Value = c.String(),
                        LanguageCode = c.String(),
                        BlockId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContentBlock", t => t.BlockId)
                .Index(t => t.BlockId);
            
            CreateTable(
                "dbo.BootstrapBlock",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Width = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blocks", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ContentBlock",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartialViewPath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blocks", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentBlock", "Id", "dbo.Blocks");
            DropForeignKey("dbo.BootstrapBlock", "Id", "dbo.Blocks");
            DropForeignKey("dbo.PropertyValues", "BlockId", "dbo.ContentBlock");
            DropForeignKey("dbo.Blocks", "ParentBlockId", "dbo.Blocks");
            DropForeignKey("dbo.Aliases", "PageId", "dbo.Pages");
            DropForeignKey("dbo.Pages", "Type_Id", "dbo.PageTypes");
            DropForeignKey("dbo.Pages", "ParentPageId", "dbo.Pages");
            DropIndex("dbo.ContentBlock", new[] { "Id" });
            DropIndex("dbo.BootstrapBlock", new[] { "Id" });
            DropIndex("dbo.PropertyValues", new[] { "BlockId" });
            DropIndex("dbo.Blocks", new[] { "ParentBlockId" });
            DropIndex("dbo.Pages", new[] { "Type_Id" });
            DropIndex("dbo.Pages", new[] { "ParentPageId" });
            DropIndex("dbo.Aliases", new[] { "PageId" });
            DropTable("dbo.ContentBlock");
            DropTable("dbo.BootstrapBlock");
            DropTable("dbo.PropertyValues");
            DropTable("dbo.Blocks");
            DropTable("dbo.PageTypes");
            DropTable("dbo.Pages");
            DropTable("dbo.Aliases");
        }
    }
}
