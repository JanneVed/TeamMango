using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketShop.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieSynopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieGenre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TicketDiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TicketIsInStock = table.Column<bool>(type: "bit", nullable: false),
                    TicketStock = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buyer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPurchase = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Purchases_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "IsAdmin", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, true, "wasd1234", "TeamMango" },
                    { 2, false, "user1", "karl" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "MovieGenre", "MovieImageUrl", "MovieLength", "MovieSynopsis", "MovieTitle" },
                values: new object[,]
                {
                    { 1, "Action, Adventure, Sci-Fi", "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg", "2h 23m", "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.", "The Avengers" },
                    { 2, "Action, Adventure, Sci-Fi", "https://upload.wikimedia.org/wikipedia/en/f/ff/Avengers_Age_of_Ultron_poster.jpg", "2h 21m", "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.", "Avengers: Age of Ultron" },
                    { 3, "Action, Adventure, Sci-Fi", "https://upload.wikimedia.org/wikipedia/en/4/4d/Avengers_Infinity_War_poster.jpg", "2h 29m", "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.", "Avengers: Infinity War" },
                    { 4, "Action, Adventure, Sci-Fi", "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg", "3h 1m", "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.", "Avengers: Endgame" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "MovieId", "TicketDiscountPrice", "TicketIsInStock", "TicketPrice", "TicketStock" },
                values: new object[,]
                {
                    { 1, 1, 0m, true, 12.99m, 50 },
                    { 2, 2, 0m, true, 14.99m, 43 },
                    { 3, 3, 0m, true, 15.99m, 20 },
                    { 4, 4, 0m, true, 15.99m, 33 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_MovieId",
                table: "Purchases",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_TicketId",
                table: "Purchases",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MovieId",
                table: "Tickets",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
