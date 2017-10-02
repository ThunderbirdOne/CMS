namespace CMS.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedisPublishedflagtoPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "IsPublished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "IsPublished");
        }
    }
}
