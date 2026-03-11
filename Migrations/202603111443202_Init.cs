namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Author = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Borrows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        BorrowDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        Email = c.String(nullable: false, maxLength: 100),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrows", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Borrows", "BookId", "dbo.Books");
            DropIndex("dbo.Students", new[] { "RoleId" });
            DropIndex("dbo.Borrows", new[] { "BookId" });
            DropIndex("dbo.Borrows", new[] { "StudentId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Students");
            DropTable("dbo.Borrows");
            DropTable("dbo.Books");
        }
    }
}
