namespace GoTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinggourlmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoLinkViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LinkName = c.String(),
                        GoUrl = c.String(),
                        Owner = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GoLinkViewModels");
        }
    }
}
