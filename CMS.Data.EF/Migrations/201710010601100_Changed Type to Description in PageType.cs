namespace CMS.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTypetoDescriptioninPageType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageTypes", "Description", c => c.String());
            DropColumn("dbo.PageTypes", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PageTypes", "Type", c => c.String());
            DropColumn("dbo.PageTypes", "Description");
        }
    }
}
