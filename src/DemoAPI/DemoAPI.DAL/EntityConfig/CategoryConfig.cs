using DemoAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.DAL.EntityConfig
{
    public class CategoryConfig:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");

            builder.Property(m => m.CategoryId)
                   .HasColumnName("category_id");

            builder.Property(m => m.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");

            builder.HasIndex(m => m.Name)
                    .IsUnique();
        }

        
    }
}
