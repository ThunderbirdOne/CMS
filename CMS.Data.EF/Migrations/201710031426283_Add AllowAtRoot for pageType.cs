namespace CMS.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllowAtRootforpageType : DbMigration
    {
        public override void Up()
        {
            AddColumn("CMS.PageTypes", "AllowAtRoot", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("CMS.PageTypes", "AllowAtRoot");
        }
    }
}
