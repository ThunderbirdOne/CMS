namespace CMS.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedrequiredattributetolotsofproperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("CMS.Pages", "Type_Id", "CMS.PageTypes");
            DropForeignKey("CMS.PropertyValues", "Property_Id", "CMS.Properties");
            DropIndex("CMS.Pages", new[] { "Type_Id" });
            DropIndex("CMS.PropertyValues", new[] { "Property_Id" });
            RenameColumn(table: "CMS.PropertyValues", name: "Property_Id", newName: "PropertyId");
            AddColumn("CMS.PageTypes", "Name", c => c.String(nullable: false));
            AlterColumn("CMS.Aliases", "Url", c => c.String(nullable: false));
            AlterColumn("CMS.Aliases", "LanguageCode", c => c.String(nullable: false));
            AlterColumn("CMS.Aliases", "CreateUser", c => c.String(nullable: false));
            AlterColumn("CMS.Pages", "Name", c => c.String(nullable: false));
            AlterColumn("CMS.Pages", "CreateUser", c => c.String(nullable: false));
            AlterColumn("CMS.Pages", "Type_Id", c => c.Guid(nullable: false));
            AlterColumn("CMS.Blocks", "CreateUser", c => c.String(nullable: false));
            AlterColumn("CMS.ContentBlocks", "PartialViewPath", c => c.String(nullable: false));
            AlterColumn("CMS.Properties", "Name", c => c.String(nullable: false));
            AlterColumn("CMS.Properties", "Type", c => c.String(nullable: false));
            AlterColumn("CMS.Properties", "CreateUser", c => c.String(nullable: false));
            AlterColumn("CMS.PropertyValues", "Value", c => c.String(nullable: false));
            AlterColumn("CMS.PropertyValues", "LanguageCode", c => c.String(nullable: false));
            AlterColumn("CMS.PropertyValues", "CreateUser", c => c.String(nullable: false));
            AlterColumn("CMS.PropertyValues", "PropertyId", c => c.Guid(nullable: false));
            AlterColumn("CMS.PageTypes", "CreateUser", c => c.String(nullable: false));
            AlterColumn("CMS.Media", "Name", c => c.String(nullable: false));
            AlterColumn("CMS.Media", "Value", c => c.Binary(nullable: false));
            AlterColumn("CMS.Media", "Type", c => c.String(nullable: false));
            AlterColumn("CMS.Media", "CreateUser", c => c.String(nullable: false));
            CreateIndex("CMS.Pages", "Type_Id");
            CreateIndex("CMS.PropertyValues", "PropertyId");
            AddForeignKey("CMS.Pages", "Type_Id", "CMS.PageTypes", "Id", cascadeDelete: true);
            AddForeignKey("CMS.PropertyValues", "PropertyId", "CMS.Properties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("CMS.PropertyValues", "PropertyId", "CMS.Properties");
            DropForeignKey("CMS.Pages", "Type_Id", "CMS.PageTypes");
            DropIndex("CMS.PropertyValues", new[] { "PropertyId" });
            DropIndex("CMS.Pages", new[] { "Type_Id" });
            AlterColumn("CMS.Media", "CreateUser", c => c.String());
            AlterColumn("CMS.Media", "Type", c => c.String());
            AlterColumn("CMS.Media", "Value", c => c.Binary());
            AlterColumn("CMS.Media", "Name", c => c.String());
            AlterColumn("CMS.PageTypes", "CreateUser", c => c.String());
            AlterColumn("CMS.PropertyValues", "PropertyId", c => c.Guid());
            AlterColumn("CMS.PropertyValues", "CreateUser", c => c.String());
            AlterColumn("CMS.PropertyValues", "LanguageCode", c => c.String());
            AlterColumn("CMS.PropertyValues", "Value", c => c.String());
            AlterColumn("CMS.Properties", "CreateUser", c => c.String());
            AlterColumn("CMS.Properties", "Type", c => c.String());
            AlterColumn("CMS.Properties", "Name", c => c.String());
            AlterColumn("CMS.ContentBlocks", "PartialViewPath", c => c.String());
            AlterColumn("CMS.Blocks", "CreateUser", c => c.String());
            AlterColumn("CMS.Pages", "Type_Id", c => c.Guid());
            AlterColumn("CMS.Pages", "CreateUser", c => c.String());
            AlterColumn("CMS.Pages", "Name", c => c.String());
            AlterColumn("CMS.Aliases", "CreateUser", c => c.String());
            AlterColumn("CMS.Aliases", "LanguageCode", c => c.String());
            AlterColumn("CMS.Aliases", "Url", c => c.String());
            DropColumn("CMS.PageTypes", "Name");
            RenameColumn(table: "CMS.PropertyValues", name: "PropertyId", newName: "Property_Id");
            CreateIndex("CMS.PropertyValues", "Property_Id");
            CreateIndex("CMS.Pages", "Type_Id");
            AddForeignKey("CMS.PropertyValues", "Property_Id", "CMS.Properties", "Id");
            AddForeignKey("CMS.Pages", "Type_Id", "CMS.PageTypes", "Id");
        }
    }
}
