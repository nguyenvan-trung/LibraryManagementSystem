using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    public class StudentConfiguration: EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            ToTable("Students");

            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.RoleId)
                .IsRequired();

            Property(x => x.Description)
                .HasMaxLength(500);

            HasRequired(x => x.Role)
                .WithMany(r => r.Students)
                .HasForeignKey(x => x.RoleId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Borrows)
                .WithRequired(b => b.Student)
                .HasForeignKey(b => b.StudentId)
                .WillCascadeOnDelete(false);

        }
    }
}