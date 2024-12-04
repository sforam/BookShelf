using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShelf.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCompanyRecordss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 4, "New York City", "Global Synergyy", "10001", "New York", "789 Enterprise Lane" },
                    { 5, "San Francisco", "Innovatech Corpp", "94103", "California", "123 Innovation Way" },
                    { 6, "Austin", "Future Dynamicss", "73301", "Texas", "456 Vision Drive" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "New York City", "Global Synergyy", "10001", "New York", "789 Enterprise Lane" },
                    { 2, "San Francisco", "Innovatech Corpp", "94103", "California", "123 Innovation Way" },
                    { 3, "Austin", "Future Dynamicss", "73301", "Texas", "456 Vision Drive" }
                });
        }
    }
}
