using ASP.NET_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Shop.Data
{
    public class TeamMangoDbContext:DbContext
    {
        public TeamMangoDbContext(DbContextOptions<TeamMangoDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Purchase> Orders { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=test;Trusted_Connection=True");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Purchase>()
                .HasKey(p => p.BuyerId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Movie)
                .WithMany(m => m.Tickets)
                .HasForeignKey(t => t.MovieId);

            // seeding Movies

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 1,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
                MovieTitle = "The Avengers",
                MovieDescription = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki " +
                "and his alien army from enslaving humanity.",
                MovieLength = "2h 23m",
                Genre = "Action, Adventure, Sci-Fi"
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 2,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/ff/Avengers_Age_of_Ultron_poster.jpg",
                MovieTitle = "Avengers: Age of Ultron",
                MovieDescription = "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly " +
                "wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.",
                MovieLength = "2h 21m",
                Genre = "Action, Adventure, Sci-Fi"
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 3,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/4d/Avengers_Infinity_War_poster.jpg",
                MovieTitle = "Avengers: Infinity War",
                MovieDescription = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his " +
                "blitz of devastation and ruin puts an end to the universe.",
                MovieLength = "2h 29m",
                Genre = "Action, Adventure, Sci-Fi"
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 4,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg",
                MovieTitle = "Avengers: Endgame",
                MovieDescription = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining " +
                "allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
                MovieLength = "3h 1m",
                Genre = "Action, Adventure, Sci-Fi"
            });

            // Seeding Tickets

            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                TicketId = 1,
                Price = 12.99,
                Stock = 50,
                IsInStock = true,
                IsOnSale = false,
                MovieId = 1
            });
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                TicketId = 2,
                Price = 14.99,
                Stock = 43,
                IsInStock = true,
                IsOnSale = false,
                MovieId = 2
            });
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                TicketId = 3,
                Price = 15.99,
                Stock = 20,
                IsInStock = true,
                IsOnSale = false,
                MovieId = 3
            });
            modelBuilder.Entity<Ticket>().HasData(new Ticket
            {
                TicketId = 4,
                Price = 15.99,
                Stock = 33,
                IsInStock = true,
                IsOnSale = false,
                MovieId = 4
            });
        }
    }
}
