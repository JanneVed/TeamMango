﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketShop.Data;

namespace TicketShop.Migrations
{
    [DbContext(typeof(TicketShopDbContext))]
    [Migration("20220714130807_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicketShop.Models.AccountModel", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            IsAdmin = true,
                            Password = "wasd1234",
                            UserName = "TeamMango"
                        },
                        new
                        {
                            AccountId = 2,
                            IsAdmin = false,
                            Password = "user1",
                            UserName = "karl"
                        });
                });

            modelBuilder.Entity("TicketShop.Models.MovieModel", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MovieGenre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLength")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieSynopsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            MovieGenre = "Action, Adventure, Sci-Fi",
                            MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
                            MovieLength = "2h 23m",
                            MovieSynopsis = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.",
                            MovieTitle = "The Avengers"
                        },
                        new
                        {
                            MovieId = 2,
                            MovieGenre = "Action, Adventure, Sci-Fi",
                            MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/ff/Avengers_Age_of_Ultron_poster.jpg",
                            MovieLength = "2h 21m",
                            MovieSynopsis = "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.",
                            MovieTitle = "Avengers: Age of Ultron"
                        },
                        new
                        {
                            MovieId = 3,
                            MovieGenre = "Action, Adventure, Sci-Fi",
                            MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/4d/Avengers_Infinity_War_poster.jpg",
                            MovieLength = "2h 29m",
                            MovieSynopsis = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.",
                            MovieTitle = "Avengers: Infinity War"
                        },
                        new
                        {
                            MovieId = 4,
                            MovieGenre = "Action, Adventure, Sci-Fi",
                            MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg",
                            MovieLength = "3h 1m",
                            MovieSynopsis = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
                            MovieTitle = "Avengers: Endgame"
                        });
                });

            modelBuilder.Entity("TicketShop.Models.PurchaseModel", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Buyer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfPurchase")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("PurchaseId");

                    b.HasIndex("MovieId");

                    b.HasIndex("TicketId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("TicketShop.Models.TicketModel", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<decimal>("TicketDiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("TicketIsInStock")
                        .HasColumnType("bit");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TicketStock")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("MovieId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            TicketId = 1,
                            MovieId = 1,
                            TicketDiscountPrice = 0m,
                            TicketIsInStock = true,
                            TicketPrice = 12.99m,
                            TicketStock = 50
                        },
                        new
                        {
                            TicketId = 2,
                            MovieId = 2,
                            TicketDiscountPrice = 0m,
                            TicketIsInStock = true,
                            TicketPrice = 14.99m,
                            TicketStock = 43
                        },
                        new
                        {
                            TicketId = 3,
                            MovieId = 3,
                            TicketDiscountPrice = 0m,
                            TicketIsInStock = true,
                            TicketPrice = 15.99m,
                            TicketStock = 20
                        },
                        new
                        {
                            TicketId = 4,
                            MovieId = 4,
                            TicketDiscountPrice = 0m,
                            TicketIsInStock = true,
                            TicketPrice = 15.99m,
                            TicketStock = 33
                        });
                });

            modelBuilder.Entity("TicketShop.Models.PurchaseModel", b =>
                {
                    b.HasOne("TicketShop.Models.MovieModel", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketShop.Models.TicketModel", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("TicketShop.Models.TicketModel", b =>
                {
                    b.HasOne("TicketShop.Models.MovieModel", "Movie")
                        .WithMany("Tickets")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("TicketShop.Models.MovieModel", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
