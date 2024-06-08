using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShelf.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsToDbAndSeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Mark Twain", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.", "ETO9999001", 150.0, 140.0, 120.0, 130.0, "Echoes of Eternity" },
                    { 2, "Alice Walker", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.", "MBM777777701", 45.0, 40.0, 30.0, 35.0, "Mystery of the Blue Moon" },
                    { 3, "Emily Bronte", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.", "WTF5555501", 60.0, 55.0, 45.0, 50.0, "Whispers of the Forest" },
                    { 4, "George Orwell", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.", "SON3333333301", 80.0, 75.0, 65.0, 70.0, "Shadows of the Night" },
                    { 5, "H.G. Wells", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.", "JTT1111111101", 35.0, 30.0, 25.0, 28.0, "Journey Through Time" },
                    { 6, "Jules Verne", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.", "SOT000000001", 50.0, 45.0, 40.0, 42.0, "Secrets of the Ocean" },
                    { 7, "Leo Tolstoy", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.", "GOH000000002", 55.0, 50.0, 40.0, 45.0, "Glimmer of Hope" },
                    { 8, "Virginia Woolf", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.", "WOC000000003", 65.0, 60.0, 50.0, 55.0, "Winds of Change" },
                    { 9, "Charlotte Bronte", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.", "FOP000000004", 70.0, 65.0, 55.0, 60.0, "Flames of Passion" },
                    { 10, "Jane Austen", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam.\r\n\r\nNunc feugiat mi a tellus consequat imperdiet.", "EOP000000005", 75.0, 70.0, 60.0, 65.0, "Echoes of the Past" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
