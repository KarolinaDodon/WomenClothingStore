using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WomenClothingStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixProductImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Элегантные платья");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Стильные блузки");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Удобные брюки");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "https://images.pexels.com/photos/2065195/pexels-photo-2065195.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "https://images.pexels.com/photos/1485031/pexels-photo-1485031.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://images.pexels.com/photos/1598507/pexels-photo-1598507.jpeg?auto=compress&cs=tinysrgb&w=600");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "https://images.unsplash.com/photo-1595777457583-95e059d581b8?w=500");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "https://images.unsplash.com/photo-1548624149-f7b2e6ce5835?w=500");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://images.unsplash.com/photo-1594633312681-425c7b97ccd1?w=500");
        }
    }
}
