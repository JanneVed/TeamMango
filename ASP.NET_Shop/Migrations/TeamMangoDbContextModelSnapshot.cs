﻿// <auto-generated />
using System;
using ASP.NET_Shop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASP.NET_Shop.Migrations
{
    [DbContext(typeof(TeamMangoDbContext))]
    partial class TeamMangoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASP.NET_Shop.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieLength")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Genre = "Action, Adventure, Sci-Fi",
                            MovieDescription = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.",
                            MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
                            MovieLength = "2h 23m",
                            MovieTitle = "The Avengers"
                        },
                        new
                        {
                            MovieId = 2,
                            Genre = "Action, Adventure, Sci-Fi",
                            MovieDescription = "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.",
                            MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/ff/Avengers_Age_of_Ultron_poster.jpg",
                            MovieLength = "2h 21m",
                            MovieTitle = "Avengers: Age of Ultron"
                        },
                        new
                        {
                            MovieId = 3,
                            Genre = "Action, Adventure, Sci-Fi",
                            MovieDescription = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.",
                            MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/4d/Avengers_Infinity_War_poster.jpg",
                            MovieLength = "2h 29m",
                            MovieTitle = "Avengers: Infinity War"
                        },
                        new
                        {
                            MovieId = 4,
                            Genre = "Action, Adventure, Sci-Fi",
                            MovieDescription = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
                            MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg",
                            MovieLength = "3h 1m",
                            MovieTitle = "Avengers: Endgame"
                        });
                });

            modelBuilder.Entity("ASP.NET_Shop.Models.Purchase", b =>
                {
                    b.Property<int>("BuyerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Buyer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("BuyerId");

                    b.HasIndex("MovieId");

                    b.HasIndex("TicketId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ASP.NET_Shop.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsInStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnSale")
                        .HasColumnType("bit");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("MovieId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            TicketId = 1,
                            IsInStock = true,
                            IsOnSale = false,
                            MovieId = 1,
                            Price = 12.99,
                            Stock = 50
                        },
                        new
                        {
                            TicketId = 2,
                            IsInStock = true,
                            IsOnSale = false,
                            MovieId = 2,
                            Price = 14.99,
                            Stock = 43
                        },
                        new
                        {
                            TicketId = 3,
                            IsInStock = true,
                            IsOnSale = false,
                            MovieId = 3,
                            Price = 15.99,
                            Stock = 20
                        },
                        new
                        {
                            TicketId = 4,
                            IsInStock = true,
                            IsOnSale = false,
                            MovieId = 4,
                            Price = 15.99,
                            Stock = 33
                        });
                });

            modelBuilder.Entity("ASP.NET_Shop.Models.Purchase", b =>
                {
                    b.HasOne("ASP.NET_Shop.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("ASP.NET_Shop.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId");
                });

            modelBuilder.Entity("ASP.NET_Shop.Models.Ticket", b =>
                {
                    b.HasOne("ASP.NET_Shop.Models.Movie", "Movie")
                        .WithMany("Tickets")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
