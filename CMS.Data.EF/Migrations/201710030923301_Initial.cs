namespace CMS.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CMS.Aliases",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                        LanguageCode = c.String(nullable: false),
                        PageId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(nullable: false),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CMS.Pages", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "CMS.Pages",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentPageId = c.Guid(),
                        IsPublished = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(nullable: false),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                        Type_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CMS.Pages", t => t.ParentPageId)
                .ForeignKey("CMS.PageTypes", t => t.Type_Id, cascadeDelete: true)
                .Index(t => t.ParentPageId)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "CMS.Blocks",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        ParentBlockId = c.Guid(),
                        PageId = c.Guid(),
                        PagePresetId = c.Guid(),
                        BlockTypeId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(nullable: false),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CMS.Blocks", t => t.ParentBlockId)
                .ForeignKey("CMS.Pages", t => t.PageId)
                .ForeignKey("CMS.PagePresets", t => t.PagePresetId)
                .ForeignKey("CMS.BlockTypes", t => t.BlockTypeId, cascadeDelete: true)
                .Index(t => t.ParentBlockId)
                .Index(t => t.PageId)
                .Index(t => t.PagePresetId)
                .Index(t => t.BlockTypeId);
            
            CreateTable(
                "CMS.PagePresets",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(nullable: false),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "CMS.PageTypePresets",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PageTypeId = c.Guid(nullable: false),
                        PagePresetId = c.Guid(nullable: false),
                        IsCustomisable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CMS.PagePresets", t => t.PagePresetId, cascadeDelete: true)
                .ForeignKey("CMS.PageTypes", t => t.PageTypeId, cascadeDelete: true)
                .Index(t => t.PageTypeId)
                .Index(t => t.PagePresetId);
            
            CreateTable(
                "CMS.PageTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(nullable: false),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "CMS.BlockTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        AllowAtRoot = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(nullable: false),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AllowedBlockTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Parentype = c.Guid(nullable: false),
                        AllowedSubType = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(nullable: false),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                        Parent_Id = c.Guid(),
                        SubType_Id = c.Guid(),
                        BlockType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CMS.BlockTypes", t => t.Parent_Id)
                .ForeignKey("CMS.BlockTypes", t => t.SubType_Id)
                .ForeignKey("CMS.BlockTypes", t => t.BlockType_Id)
                .Index(t => t.Parent_Id)
                .Index(t => t.SubType_Id)
                .Index(t => t.BlockType_Id);
            
            CreateTable(
                "CMS.Properties",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        BlockId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(nullable: false),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CMS.ContentBlocks", t => t.BlockId)
                .Index(t => t.BlockId);
            
            CreateTable(
                "CMS.PropertyValues",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        LanguageCode = c.String(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(nullable: false),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CMS.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "CMS.Media",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Value = c.Binary(nullable: false),
                        Type = c.String(nullable: false),
                        ReferenceMediaId = c.Guid(),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(nullable: false),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CMS.Media", t => t.ReferenceMediaId)
                .Index(t => t.ReferenceMediaId);
            
            CreateTable(
                "CMS.BootstrapBlocks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Width = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CMS.Blocks", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "CMS.ContentBlocks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartialViewPath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CMS.Blocks", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CMS.ContentBlocks", "Id", "CMS.Blocks");
            DropForeignKey("CMS.BootstrapBlocks", "Id", "CMS.Blocks");
            DropForeignKey("CMS.Media", "ReferenceMediaId", "CMS.Media");
            DropForeignKey("CMS.Pages", "Type_Id", "CMS.PageTypes");
            DropForeignKey("CMS.Pages", "ParentPageId", "CMS.Pages");
            DropForeignKey("CMS.PropertyValues", "PropertyId", "CMS.Properties");
            DropForeignKey("CMS.Properties", "BlockId", "CMS.ContentBlocks");
            DropForeignKey("CMS.Blocks", "BlockTypeId", "CMS.BlockTypes");
            DropForeignKey("dbo.AllowedBlockTypes", "BlockType_Id", "CMS.BlockTypes");
            DropForeignKey("dbo.AllowedBlockTypes", "SubType_Id", "CMS.BlockTypes");
            DropForeignKey("dbo.AllowedBlockTypes", "Parent_Id", "CMS.BlockTypes");
            DropForeignKey("CMS.Blocks", "PagePresetId", "CMS.PagePresets");
            DropForeignKey("CMS.PageTypePresets", "PageTypeId", "CMS.PageTypes");
            DropForeignKey("CMS.PageTypePresets", "PagePresetId", "CMS.PagePresets");
            DropForeignKey("CMS.Blocks", "PageId", "CMS.Pages");
            DropForeignKey("CMS.Blocks", "ParentBlockId", "CMS.Blocks");
            DropForeignKey("CMS.Aliases", "PageId", "CMS.Pages");
            DropIndex("CMS.ContentBlocks", new[] { "Id" });
            DropIndex("CMS.BootstrapBlocks", new[] { "Id" });
            DropIndex("CMS.Media", new[] { "ReferenceMediaId" });
            DropIndex("CMS.PropertyValues", new[] { "PropertyId" });
            DropIndex("CMS.Properties", new[] { "BlockId" });
            DropIndex("dbo.AllowedBlockTypes", new[] { "BlockType_Id" });
            DropIndex("dbo.AllowedBlockTypes", new[] { "SubType_Id" });
            DropIndex("dbo.AllowedBlockTypes", new[] { "Parent_Id" });
            DropIndex("CMS.PageTypePresets", new[] { "PagePresetId" });
            DropIndex("CMS.PageTypePresets", new[] { "PageTypeId" });
            DropIndex("CMS.Blocks", new[] { "BlockTypeId" });
            DropIndex("CMS.Blocks", new[] { "PagePresetId" });
            DropIndex("CMS.Blocks", new[] { "PageId" });
            DropIndex("CMS.Blocks", new[] { "ParentBlockId" });
            DropIndex("CMS.Pages", new[] { "Type_Id" });
            DropIndex("CMS.Pages", new[] { "ParentPageId" });
            DropIndex("CMS.Aliases", new[] { "PageId" });
            DropTable("CMS.ContentBlocks");
            DropTable("CMS.BootstrapBlocks");
            DropTable("CMS.Media");
            DropTable("CMS.PropertyValues");
            DropTable("CMS.Properties");
            DropTable("dbo.AllowedBlockTypes");
            DropTable("CMS.BlockTypes");
            DropTable("CMS.PageTypes");
            DropTable("CMS.PageTypePresets");
            DropTable("CMS.PagePresets");
            DropTable("CMS.Blocks");
            DropTable("CMS.Pages");
            DropTable("CMS.Aliases");
        }
    }
}
