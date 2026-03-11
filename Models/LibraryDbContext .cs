using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Migrations;

namespace WebApplication1.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new BorrowConfiguration());
            base.OnModelCreating(modelBuilder);
            // Configure many-to-many relationship between Student and Book

        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Borrow> Borrows { get; set; }
    }
}