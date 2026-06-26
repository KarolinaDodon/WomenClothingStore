using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WomenClothingStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductImages2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://images.pexels.com/photos/6311392/pexels-photo-6311392.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "Url",
                value: "https://images.pexels.com/photos/7691334/pexels-photo-7691334.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "Url",
                value: "https://images.pexels.com/photos/9558912/pexels-photo-9558912.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "Url",
                value: "https://images.pexels.com/photos/9594428/pexels-photo-9594428.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "Url",
                value: "https://images.pexels.com/photos/9558706/pexels-photo-9558706.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "Url",
                value: "https://images.pexels.com/photos/3766210/pexels-photo-3766210.jpeg?auto=compress&cs=tinysrgb&w=600");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://images.pexels.com/photos/3534523/pexels-photo-3534523.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "Url",
                value: "https://images.pexels.com/photos/3184183/pexels-photo-3184183.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "Url",
                value: "https://images.pexels.com/photos/1536619/pexels-photo-1536619.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "Url",
                value: "https://images.pexels.com/photos/2220316/pexels-photo-2220316.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "Url",
                value: "https://images.pexels.com/photos/7691168/pexels-photo-7691168.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "Url",
                value: "https://images.pexels.com/photos/5710082/pexels-photo-5710082.jpeg?auto=compress&cs=tinysrgb&w=600");
        }
    }
}
