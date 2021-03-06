// <auto-generated />
using System;
using DemoAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DemoAPI.DAL.Migrations
{
    [DbContext(typeof(DemoAPIContext))]
    [Migration("20211106190342_ex_log")]
    partial class ex_log
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DemoAPI.DAL.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("category_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.HasKey("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("category");
                });

            modelBuilder.Entity("DemoAPI.DAL.Models.ExceptionLog", b =>
                {
                    b.Property<int>("ExceptionLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("exception_log_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("ErrorDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("error_date");

                    b.Property<string>("InnerException")
                        .HasColumnType("text")
                        .HasColumnName("inner_exception");

                    b.Property<string>("Message")
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<string>("StackTracker")
                        .HasColumnType("text")
                        .HasColumnName("stack_trace");

                    b.HasKey("ExceptionLogId");

                    b.ToTable("exception_log");
                });
#pragma warning restore 612, 618
        }
    }
}
