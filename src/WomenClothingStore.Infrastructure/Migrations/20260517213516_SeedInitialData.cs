using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WomenClothingStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Product",
                table: "ProductSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Size",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "ProductSize",
                newName: "SizesId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductSize",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_SizeId",
                table: "ProductSize",
                newName: "IX_ProductSize_SizesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Size",
                table: "Size",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "", "Платья" },
                    { 2, "", "Блузки" },
                    { 3, "", "Брюки" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Прекрасное вечернее платье для любого случая.", "Элегантное синее платье", 4500m },
                    { 2, 2, "Модная блузка из легкого материала.", "Стильная розовая блузка", 2800m },
                    { 3, 3, "Подойдут как для офиса, так и для повседневной носки.", "Удобные классические брюки", 3900m }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMain", "ProductId", "Url" },
                values: new object[,]
                {
                    { 1, true, 1, "https://images.unsplash.com/photo-1595777457583-95e059d581b8?w=500" },
                    { 2, true, 2, "https://images.unsplash.com/photo-1548624149-f7b2e6ce5835?w=500" },
                    { 3, true, 3, "https://images.unsplash.com/photo-1594633312681-425c7b97ccd1?w=500" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Products_ProductsId",
                table: "ProductSize",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Size_SizesId",
                table: "ProductSize",
                column: "SizesId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Products_ProductsId",
                table: "ProductSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Size_SizesId",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Size",
                table: "Size");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "Size",
                newName: "Sizes");

            migrationBuilder.RenameColumn(
                name: "SizesId",
                table: "ProductSize",
                newName: "SizeId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ProductSize",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_SizesId",
                table: "ProductSize",
                newName: "IX_ProductSize_SizeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Product",
                table: "ProductSize",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Size",
                table: "ProductSize",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
