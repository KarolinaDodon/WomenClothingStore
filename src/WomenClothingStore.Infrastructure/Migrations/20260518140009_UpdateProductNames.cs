using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WomenClothingStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Элегантное платье");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Стильная блузка");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Элегантное синее платье");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Стильная розовая блузка");
        }
    }
}
