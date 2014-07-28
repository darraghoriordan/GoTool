namespace GoTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GoLinkViewModels", "Description", c => c.String());
            AlterColumn("dbo.GoLinkViewModels", "LinkName", c => c.String(nullable: false));
            AlterColumn("dbo.GoLinkViewModels", "GoUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GoLinkViewModels", "GoUrl", c => c.String());
            AlterColumn("dbo.GoLinkViewModels", "LinkName", c => c.String());
            DropColumn("dbo.GoLinkViewModels", "Description");
        }
    }
}
