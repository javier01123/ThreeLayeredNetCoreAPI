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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(m => m.UserId)
                .HasColumnName("user_id");

            builder.Property(m => m.UserType)
                .HasColumnName("user_type")
                .HasConversion<string>();

            builder.Property(m => m.Username)
                .HasColumnName("username")
                .HasMaxLength(20);

            builder.Property(m => m.Password)
                   .HasColumnName("password")
                   .HasMaxLength(200);

            builder.HasIndex(m => m.Username).IsUnique();
        }
    }
}
