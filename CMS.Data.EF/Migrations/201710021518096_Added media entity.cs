namespace CMS.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedmediaentity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BootstrapBlock", newName: "BootstrapBlocks");
            RenameTable(name: "dbo.ContentBlock", newName: "ContentBlocks");
            MoveTable(name: "dbo.Aliases", newSchema: "CMS");
            MoveTable(name: "dbo.Pages", newSchema: "CMS");
            MoveTable(name: "dbo.Blocks", newSchema: "CMS");
            MoveTable(name: "dbo.BootstrapBlocks", newSchema: "CMS");
            MoveTable(name: "dbo.ContentBlocks", newSchema: "CMS");
            MoveTable(name: "dbo.Properties", newSchema: "CMS");
            MoveTable(name: "dbo.PropertyValues", newSchema: "CMS");
            MoveTable(name: "dbo.PageTypes", newSchema: "CMS");
            CreateTable(
                "CMS.Media",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Binary(),
                        Type = c.String(),
                        ReferenceMediaId = c.Guid(),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(),
                        LastUpdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CMS.Media", t => t.ReferenceMediaId)
                .Index(t => t.ReferenceMediaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CMS.Media", "ReferenceMediaId", "CMS.Media");
            DropIndex("CMS.Media", new[] { "ReferenceMediaId" });
            DropTable("CMS.Media");
            MoveTable(name: "CMS.PageTypes", newSchema: "dbo");
            MoveTable(name: "CMS.PropertyValues", newSchema: "dbo");
            MoveTable(name: "CMS.Properties", newSchema: "dbo");
            MoveTable(name: "CMS.ContentBlocks", newSchema: "dbo");
            MoveTable(name: "CMS.BootstrapBlocks", newSchema: "dbo");
            MoveTable(name: "CMS.Blocks", newSchema: "dbo");
            MoveTable(name: "CMS.Pages", newSchema: "dbo");
            MoveTable(name: "CMS.Aliases", newSchema: "dbo");
            RenameTable(name: "dbo.ContentBlocks", newName: "ContentBlock");
            RenameTable(name: "dbo.BootstrapBlocks", newName: "BootstrapBlock");
        }
    }
}
