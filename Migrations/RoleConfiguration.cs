using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("Roles");
            HasKey(x => x.Id);
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}