﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniProject001.DAL.Database;

namespace MiniProject001.DAL.Migrations
{
    [DbContext(typeof(AbContext))]
    [Migration("20220520054547_book")]
    partial class book
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MiniProject001.DAL.Database.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<bool>("isAlive")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("MiniProject001.DAL.Database.Models.Book", b =>
                {
                    b.Property<int>("bookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("authorId")
                        .HasColumnType("int");

                    b.Property<bool>("binding")
                        .HasColumnType("bit");

                    b.Property<int>("pages")
                        .HasColumnType("int");

                    b.Property<DateTime>("releaseYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("wordCount")
                        .HasColumnType("float");

                    b.HasKey("bookId");

                    b.HasIndex("authorId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("MiniProject001.DAL.Database.Models.Book", b =>
                {
                    b.HasOne("MiniProject001.DAL.Database.Models.Author", "author")
                        .WithMany("Book")
                        .HasForeignKey("authorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");
                });

            modelBuilder.Entity("MiniProject001.DAL.Database.Models.Author", b =>
                {
                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}