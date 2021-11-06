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
    public class ExceptionLogConfig : IEntityTypeConfiguration<ExceptionLog>
    {
        public void Configure(EntityTypeBuilder<ExceptionLog> builder)
        {
            builder.ToTable("exception_log");

            builder.Property(m => m.ExceptionLogId)
                   .HasColumnName("exception_log_id");

            builder.Property(m => m.ErrorDate)
                    .HasColumnName("error_date")
                    .HasColumnType("timestamp");

            builder.Property(m => m.Message)                    
                    .HasColumnName("message");

            builder.Property(m => m.InnerException)
                .HasColumnName("inner_exception");

            builder.Property(m => m.StackTracker)
                .HasColumnName("stack_trace");
        }
    }
}
