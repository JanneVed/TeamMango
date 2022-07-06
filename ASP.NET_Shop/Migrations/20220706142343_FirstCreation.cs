using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Shop.Migrations
{
    public partial class FirstCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieImageUrl = table.Column<string>(nullable: true),
                    MovieTitle = table.Column<string>(nullable: true),
                    MovieDescription = table.Column<string>(nullable: true),
                    MovieLength = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    IsInStock = table.Column<bool>(nullable: false),
                    IsOnSale = table.Column<bool>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
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
                name: "Orders",
                columns: table => new
                {
                    BuyerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buyer = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: true),
                    TicketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.BuyerId);
                    table.ForeignKey(
                        name: "FK_Orders_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Genre", "MovieDescription", "MovieImageUrl", "MovieLength", "MovieTitle" },
                values: new object[,]
                {
                    { 1, "Action, Adventure, Sci-Fi", "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.", "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg", "2h 23m", "The Avengers" },
                    { 2, "Action, Adventure, Sci-Fi", "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.", "https://upload.wikimedia.org/wikipedia/en/f/ff/Avengers_Age_of_Ultron_poster.jpg", "2h 21m", "Avengers: Age of Ultron" },
                    { 3, "Action, Adventure, Sci-Fi", "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.", "https://upload.wikimedia.org/wikipedia/en/4/4d/Avengers_Infinity_War_poster.jpg", "2h 29m", "Avengers: Infinity War" },
                    { 4, "Action, Adventure, Sci-Fi", "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.", "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg", "3h 1m", "Avengers: Endgame" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "IsInStock", "IsOnSale", "MovieId", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, true, false, 1, 12.99, 50 },
                    { 2, true, false, 2, 14.99, 43 },
                    { 3, true, false, 3, 15.99, 20 },
                    { 4, true, false, 4, 15.99, 33 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MovieId",
                table: "Orders",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TicketId",
                table: "Orders",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MovieId",
                table: "Tickets",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
