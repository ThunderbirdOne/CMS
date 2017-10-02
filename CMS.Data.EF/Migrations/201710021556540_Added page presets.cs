namespace CMS.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedpagepresets : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("CMS.Blocks", "PagePresetId", c => c.Guid());
            CreateIndex("CMS.Blocks", "PagePresetId");
            AddForeignKey("CMS.Blocks", "PagePresetId", "CMS.PagePresets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("CMS.Blocks", "PagePresetId", "CMS.PagePresets");
            DropForeignKey("CMS.PageTypePresets", "PageTypeId", "CMS.PageTypes");
            DropForeignKey("CMS.PageTypePresets", "PagePresetId", "CMS.PagePresets");
            DropIndex("CMS.PageTypePresets", new[] { "PagePresetId" });
            DropIndex("CMS.PageTypePresets", new[] { "PageTypeId" });
            DropIndex("CMS.Blocks", new[] { "PagePresetId" });
            DropColumn("CMS.Blocks", "PagePresetId");
            DropTable("CMS.PageTypePresets");
            DropTable("CMS.PagePresets");
        }
    }
}
