﻿// <auto-generated />
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
    [Migration("20211120144724_productCategoryM2M")]
    partial class productCategoryM2M
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

            modelBuilder.Entity("DemoAPI.DAL.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("product_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("price");

                    b.HasKey("ProductId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("DemoAPI.DAL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("password");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_type");

                    b.Property<string>("Username")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("username");

                    b.HasKey("UserId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("product_category", b =>
                {
                    b.Property<int>("category_id")
                        .HasColumnType("integer");

                    b.Property<int>("product_id")
                        .HasColumnType("integer");

                    b.HasKey("category_id", "product_id");

                    b.HasIndex("product_id");

                    b.ToTable("product_category");
                });

            modelBuilder.Entity("product_category", b =>
                {
                    b.HasOne("DemoAPI.DAL.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoAPI.DAL.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}