namespace CMS.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GottaMigrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyValues", "Property_Id", c => c.Guid());
            CreateIndex("dbo.PropertyValues", "Property_Id");
            AddForeignKey("dbo.PropertyValues", "Property_Id", "dbo.Properties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyValues", "Property_Id", "dbo.Properties");
            DropIndex("dbo.PropertyValues", new[] { "Property_Id" });
            DropColumn("dbo.PropertyValues", "Property_Id");
        }
    }
}
