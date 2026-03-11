namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.Models.LibraryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            // vai trò 
            context.Roles.AddOrUpdate(
                r => r.Name,
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            );

            // sách 
            context.Books.AddOrUpdate(
                b => b.Id,
                new Book { Id = 1, Title = "Clean Code", Author = "Robert Martin", Quantity = 5 },
                new Book { Id = 2, Title = "Design Patterns", Author = "GoF", Quantity = 3 },
                new Book { Id = 3, Title = "Refactoring", Author = "Martin Fowler", Quantity = 4 },
                new Book { Id = 4, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Quantity = 6 },
                new Book { Id = 5, Title = "Code Complete", Author = "Steve McConnell", Quantity = 5 },
                new Book { Id = 6, Title = "Domain Driven Design", Author = "Eric Evans", Quantity = 2 },
                new Book { Id = 7, Title = "C# in Depth", Author = "Jon Skeet", Quantity = 3 },
                new Book { Id = 8, Title = "ASP.NET MVC", Author = "Microsoft", Quantity = 7 },
                new Book { Id = 9, Title = "Algorithms", Author = "Robert Sedgewick", Quantity = 4 },
                new Book { Id = 10, Title = "Introduction to Algorithms", Author = "CLRS", Quantity = 2 }
            );

            // học sinh 
            context.Students.AddOrUpdate(
                s => s.Id,
                new Student { Id = 1, Name = "Trung", Email = "trung@gmail.com", RoleId = 1 },
                new Student { Id = 2, Name = "An", Email = "an@gmail.com", RoleId = 2 },
                new Student { Id = 3, Name = "Binh", Email = "binh@gmail.com", RoleId = 2 },
                new Student { Id = 4, Name = "Cuong", Email = "cuong@gmail.com", RoleId = 2 },
                new Student { Id = 5, Name = "Dung", Email = "dung@gmail.com", RoleId = 2 },
                new Student { Id = 6, Name = "Huy", Email = "huy@gmail.com", RoleId = 2 },
                new Student { Id = 7, Name = "Long", Email = "long@gmail.com", RoleId = 2 },
                new Student { Id = 8, Name = "Minh", Email = "minh@gmail.com", RoleId = 2 }
            );

            // mượn sách 

            context.Borrows.AddOrUpdate(
                b => b.Id,
                new Borrow
                {
                    Id = 1,
                    StudentId = 1,
                    BookId = 2,
                    BorrowDate = DateTime.Now.AddDays(-3),
                    ReturnDate = DateTime.Now.AddDays(7),
                    Status = "Borrowing"
                },
                new Borrow
                {
                    Id = 2,
                    StudentId = 2,
                    BookId = 5,
                    BorrowDate = DateTime.Now.AddDays(-2),
                    ReturnDate = DateTime.Now.AddDays(10),
                    Status = "Borrowing"
                },
                new Borrow
                {
                    Id = 3,
                    StudentId = 3,
                    BookId = 1,
                    BorrowDate = DateTime.Now.AddDays(-5),
                    ReturnDate = DateTime.Now.AddDays(5),
                    Status = "Borrowing"
                },
                new Borrow
                {
                    Id = 4,
                    StudentId = 4,
                    BookId = 7,
                    BorrowDate = DateTime.Now.AddDays(-1),
                    ReturnDate = DateTime.Now.AddDays(14),
                    Status = "Borrowing"
                }
            );
        }
    }
}
