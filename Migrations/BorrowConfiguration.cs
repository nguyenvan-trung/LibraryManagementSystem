using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    public class BorrowConfiguration: EntityTypeConfiguration<Borrow>
    {
        public BorrowConfiguration()
        {
            ToTable("Borrows");
            HasKey(x => x.Id);
            Property(x => x.StudentId)
                .IsRequired();
            Property(x => x.BookId)
                .IsRequired();
            Property(x => x.BorrowDate)
                .IsRequired();
            Property(x => x.ReturnDate)
                .IsOptional();
            HasRequired(x => x.Student)
                .WithMany(s => s.Borrows)
                .HasForeignKey(x => x.StudentId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Book)
                .WithMany(b => b.Borrows)
                .HasForeignKey(x => x.BookId)
                .WillCascadeOnDelete(false);
        }
    }
}