using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameZone.Migrations
{
    /// <inheritdoc />
    public partial class sec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Item",
                table: "Devices",
                newName: "Icon");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sports" },
                    { 2, "Action" },
                    { 3, "Adventure" },
                    { 4, "Racing" },
                    { 5, "Fighting" },
                    { 6, "Film" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "bi bi-playstation", "PlayStation" },
                    { 2, "bi bi-xbox", "xbox" },
                    { 3, "bi bi-nintendo-switch", "Nintendo Switch" },
                    { 4, "bi bi-pc-display", "PC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Devices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Devices",
                newName: "Item");
        }
    }
}
