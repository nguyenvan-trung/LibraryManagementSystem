namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Password");
        }
    }
}
