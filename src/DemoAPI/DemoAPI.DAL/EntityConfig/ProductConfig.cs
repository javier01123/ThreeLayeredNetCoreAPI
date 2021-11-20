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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.Property(m => m.ProductId)
                   .HasColumnName("product_id");

            builder.Property(m => m.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

            builder.Property(m => m.Price)
                    .HasPrecision(18, 2)
                    .HasColumnName("price");

            builder.HasMany(m => m.Categories)
                    .WithMany(m => m.Products)
                    .UsingEntity<Dictionary<string, object>>("product_category",
                    j => j.HasOne<Category>()
                        .WithMany()
                        .HasForeignKey("category_id"),
                    j => j.HasOne<Product>()
                         .WithMany()
                         .HasForeignKey("product_id"),
                    j => j.ToTable("product_category")
                    );

        }


    }
}
