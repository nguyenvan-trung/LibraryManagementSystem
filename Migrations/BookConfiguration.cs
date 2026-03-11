using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            ToTable("Books");

            HasKey(x => x.Id);

            Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            Property(x => x.Author)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Description)
                .HasMaxLength(500);

            Property(x => x.Quantity)
                .IsRequired();
        }
    }
}