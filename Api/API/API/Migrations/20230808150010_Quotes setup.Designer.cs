﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230808150010_Quotes setup")]
    partial class Quotessetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Author = "Uknown",
                            Date = new DateTime(1800, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Wars"
                        },
                        new
                        {
                            Id = 11,
                            Author = "Mankind",
                            Date = new DateTime(1700, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Peacetimes"
                        },
                        new
                        {
                            Id = 12,
                            Author = "Arthur C. Clarke",
                            Date = new DateTime(1968, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "2001: A Space Odyssey"
                        },
                        new
                        {
                            Id = 13,
                            Author = "Uknown",
                            Date = new DateTime(2014, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Book nr 4"
                        });
                });

            modelBuilder.Entity("API.Models.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("API.Models.Quote", b =>
                {
                    b.HasOne("API.Models.Book", null)
                        .WithMany("Quotes")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.Book", b =>
                {
                    b.Navigation("Quotes");
                });
#pragma warning restore 612, 618
        }
    }
}