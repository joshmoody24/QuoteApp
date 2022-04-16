﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuoteApp.Models;

namespace QuoteApp.Migrations
{
    [DbContext(typeof(QuoteDbContext))]
    partial class QuoteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24");

            modelBuilder.Entity("QuoteApp.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            FirstName = "Spencer",
                            LastName = "Hilton"
                        },
                        new
                        {
                            AuthorId = 2,
                            FirstName = "Albert",
                            LastName = "Einstein"
                        },
                        new
                        {
                            AuthorId = 3,
                            FirstName = "J.K.",
                            LastName = "Rowling"
                        },
                        new
                        {
                            AuthorId = 4,
                            FirstName = "Russel",
                            LastName = "Nelson"
                        },
                        new
                        {
                            AuthorId = 5,
                            FirstName = "Elon",
                            LastName = "Musk"
                        },
                        new
                        {
                            AuthorId = 6,
                            FirstName = "Randall",
                            LastName = "Munroe"
                        },
                        new
                        {
                            AuthorId = 7,
                            FirstName = "Amulek"
                        });
                });

            modelBuilder.Entity("QuoteApp.Models.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Citation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("QuoteText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("QuoteId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            QuoteId = 1,
                            AuthorId = 1,
                            Citation = "Heard it in 403 last semester",
                            Date = new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QuoteText = "CREATE TABLE Yeet",
                            SubjectId = 2
                        },
                        new
                        {
                            QuoteId = 2,
                            AuthorId = 6,
                            Citation = "https://xkcd.com/1942/",
                            Date = new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QuoteText = "I disagree strongly with whatever work this quote is attached to"
                        },
                        new
                        {
                            QuoteId = 3,
                            AuthorId = 7,
                            Citation = "Alma 11:33",
                            QuoteText = "Yea"
                        });
                });

            modelBuilder.Entity("QuoteApp.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectId = 1,
                            SubjectName = "Joy"
                        },
                        new
                        {
                            SubjectId = 2,
                            SubjectName = "Funny"
                        },
                        new
                        {
                            SubjectId = 3,
                            SubjectName = "Coding"
                        },
                        new
                        {
                            SubjectId = 4,
                            SubjectName = "Despicable"
                        },
                        new
                        {
                            SubjectId = 5,
                            SubjectName = "Political"
                        });
                });

            modelBuilder.Entity("QuoteApp.Models.Quote", b =>
                {
                    b.HasOne("QuoteApp.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuoteApp.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");
                });
#pragma warning restore 612, 618
        }
    }
}
