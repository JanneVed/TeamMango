using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketShop.Models;

namespace TicketShop.Data
{
    public class TicketShopDbContext : DbContext
    {
        public TicketShopDbContext(DbContextOptions<TicketShopDbContext> options) : base(options)
        {

        }

        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<PurchaseModel> Purchases { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieModel>().HasData(new MovieModel
            {
                MovieId = 1,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
                MovieTitle = "The Avengers",
                MovieSynopsis = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki " +
                "and his alien army from enslaving humanity.",
                MovieLength = "2h 23m",
                MovieGenre = "Action, Adventure, Sci-Fi"
            });
            modelBuilder.Entity<MovieModel>().HasData(new MovieModel
            {
                MovieId = 2,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/ff/Avengers_Age_of_Ultron_poster.jpg",
                MovieTitle = "Avengers: Age of Ultron",
                MovieSynopsis = "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly " +
                "wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.",
                MovieLength = "2h 21m",
                MovieGenre = "Action, Adventure, Sci-Fi"
            });
            modelBuilder.Entity<MovieModel>().HasData(new MovieModel
            {
                MovieId = 3,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/4d/Avengers_Infinity_War_poster.jpg",
                MovieTitle = "Avengers: Infinity War",
                MovieSynopsis = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his " +
                "blitz of devastation and ruin puts an end to the universe.",
                MovieLength = "2h 29m",
                MovieGenre = "Action, Adventure, Sci-Fi"
            });
            modelBuilder.Entity<MovieModel>().HasData(new MovieModel
            {
                MovieId = 4,
                MovieImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg",
                MovieTitle = "Avengers: Endgame",
                MovieSynopsis = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining " +
                "allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
                MovieLength = "3h 1m",
                MovieGenre = "Action, Adventure, Sci-Fi"
            });

            // Seeding Tickets

            modelBuilder.Entity<TicketModel>().HasData(new TicketModel
            {
                TicketId = 1,
                TicketPrice = 12.99m,
                TicketStock = 50,
                TicketIsInStock = true,
                MovieId = 1
            });
            modelBuilder.Entity<TicketModel>().HasData(new TicketModel
            {
                TicketId = 2,
                TicketPrice = 14.99m,
                TicketStock = 43,
                TicketIsInStock = true,
                MovieId = 2
            });
            modelBuilder.Entity<TicketModel>().HasData(new TicketModel
            {
                TicketId = 3,
                TicketPrice = 15.99m,
                TicketStock = 20,
                TicketIsInStock = true,
                MovieId = 3
            });
            modelBuilder.Entity<TicketModel>().HasData(new TicketModel
            {
                TicketId = 4,
                TicketPrice = 15.99m,
                TicketStock = 33,
                TicketIsInStock = true,
                MovieId = 4
            });

            // Seeding Accounts table
            modelBuilder.Entity<AccountModel>().HasData(new AccountModel
            {
                AccountId = 1,
                UserName = "TeamMango",
                Password = "wasd1234",
                IsAdmin = true
            });
            modelBuilder.Entity<AccountModel>().HasData(new AccountModel
            {
                AccountId = 2,
                UserName = "karl",
                Password = "user1",
                IsAdmin = false
            });
        }
    }
}
