using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WomenClothingStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSizesReviewsAndInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Size",
                table: "Size");

            migrationBuilder.RenameTable(
                name: "Size",
                newName: "Sizes");

            migrationBuilder.AddColumn<string>(
                name: "Emoji",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Sizes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    SizeId = table.Column<int>(type: "INTEGER", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => new { x.ProductId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_ProductSizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorName = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Emoji",
                value: "👕");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Emoji",
                value: "👗");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Emoji", "Name" },
                values: new object[,]
                {
                    { 3, "Платья для любого повода — от casual до вечерних", "👘", "Платья" },
                    { 4, "Лёгкие блузки и рубашки на каждый день", "👚", "Блузки" },
                    { 5, "Удобные и модные брюки и джинсы", "👖", "Брюки" }
                });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: "https://images.pexels.com/photos/4690501/pexels-photo-4690501.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: "https://images.pexels.com/photos/23947043/pexels-photo-23947043.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "Url",
                value: "https://images.pexels.com/photos/5217676/pexels-photo-5217676.jpeg?auto=compress&cs=tinysrgb&w=600");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Классическая хлопковая футболка прямого кроя. Идеальная база любого гардероба.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Трендовая свободная футболка из плотного трикотажа с авторским принтом.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Укороченная модель для активного отдыха и тренировок. Влагоотводящий материал.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Лёгкая плиссированная юбка нежного пастельного оттенка.");

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AuthorName", "Comment", "CreatedAt", "ProductId", "Rating" },
                values: new object[,]
                {
                    { 1, "Анна К.", "Отличное качество! Ткань мягкая, не садится после стирки. Беру уже третью.", new DateTime(2025, 3, 10, 10, 0, 0, 0, DateTimeKind.Utc), 1, 5 },
                    { 2, "Мария Д.", "Хорошая футболка, но размер немного большемерит. Советую брать на размер меньше.", new DateTime(2025, 3, 15, 14, 30, 0, 0, DateTimeKind.Utc), 1, 4 },
                    { 3, "Екатерина", "Просто в восторге! Принт очень чёткий, оверсайз посадка как на картинке.", new DateTime(2025, 4, 1, 9, 0, 0, 0, DateTimeKind.Utc), 2, 5 },
                    { 4, "Ольга С.", "Юбка великолепная! Ткань не мнётся, цвет нежный. Получила море комплиментов.", new DateTime(2025, 4, 5, 16, 0, 0, 0, DateTimeKind.Utc), 4, 5 },
                    { 5, "Светлана", "Юбка красивая, но пришла с небольшой затяжкой. Магазин решил вопрос быстро.", new DateTime(2025, 4, 12, 11, 0, 0, 0, DateTimeKind.Utc), 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Label", "SortOrder" },
                values: new object[,]
                {
                    { 1, "XS", 1 },
                    { 2, "S", 2 },
                    { 3, "M", 3 },
                    { 4, "L", 4 },
                    { 5, "XL", 5 }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "ProductId", "SizeId", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 1, 2, 8 },
                    { 1, 3, 12 },
                    { 1, 4, 5 },
                    { 1, 5, 0 },
                    { 2, 2, 4 },
                    { 2, 3, 7 },
                    { 2, 4, 6 },
                    { 2, 5, 2 },
                    { 3, 1, 5 },
                    { 3, 2, 9 },
                    { 3, 3, 0 },
                    { 3, 4, 3 },
                    { 4, 1, 2 },
                    { 4, 2, 5 },
                    { 4, 3, 8 },
                    { 4, 4, 4 },
                    { 4, 5, 1 },
                    { 5, 2, 3 },
                    { 5, 3, 6 },
                    { 5, 4, 0 },
                    { 5, 5, 4 },
                    { 6, 1, 0 },
                    { 6, 2, 4 },
                    { 6, 3, 7 },
                    { 6, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 7, 3, "Воздушное платье из натурального хлопка с цветочным принтом.", "Летнее платье в цветочек", 5200m },
                    { 8, 3, "Изысканное платье-футляр из бархата для особых случаев.", "Вечернее чёрное платье", 8900m },
                    { 9, 3, "Универсальное платье свободного кроя в классическую клетку.", "Платье-рубашка в клетку", 4600m },
                    { 10, 4, "Нежная блузка из искусственного шёлка с V-образным вырезом.", "Шёлковая блузка молочная", 3800m },
                    { 11, 4, "Лёгкая льняная рубашка — идеальный выбор для жаркого лета.", "Льняная рубашка оверсайз", 3200m },
                    { 12, 4, "Романтичная блузка с пышными рукавами-буфами из шифона.", "Блузка с объёмными рукавами", 4100m },
                    { 13, 5, "Классические мом-джинсы с высокой посадкой из плотного денима.", "Прямые джинсы Mom-fit", 5500m },
                    { 14, 5, "Широкие брюки из льна — лёгкость и стиль в одном образе.", "Льняные брюки палаццо", 4700m },
                    { 15, 5, "Прямые брюки со стрелками из костюмной ткани. Офис и вечер.", "Чёрные классические брюки", 5100m }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMain", "ProductId", "Url" },
                values: new object[,]
                {
                    { 7, true, 7, "https://images.pexels.com/photos/972995/pexels-photo-972995.jpeg?auto=compress&cs=tinysrgb&w=600" },
                    { 8, true, 8, "https://images.pexels.com/photos/1755428/pexels-photo-1755428.jpeg?auto=compress&cs=tinysrgb&w=600" },
                    { 9, true, 9, "https://images.pexels.com/photos/2466756/pexels-photo-2466756.jpeg?auto=compress&cs=tinysrgb&w=600" },
                    { 10, true, 10, "https://images.pexels.com/photos/3184183/pexels-photo-3184183.jpeg?auto=compress&cs=tinysrgb&w=600" },
                    { 11, true, 11, "https://images.pexels.com/photos/1536619/pexels-photo-1536619.jpeg?auto=compress&cs=tinysrgb&w=600" },
                    { 12, true, 12, "https://images.pexels.com/photos/2220316/pexels-photo-2220316.jpeg?auto=compress&cs=tinysrgb&w=600" },
                    { 13, true, 13, "https://images.pexels.com/photos/1598507/pexels-photo-1598507.jpeg?auto=compress&cs=tinysrgb&w=600" },
                    { 14, true, 14, "https://images.pexels.com/photos/7691168/pexels-photo-7691168.jpeg?auto=compress&cs=tinysrgb&w=600" },
                    { 15, true, 15, "https://images.pexels.com/photos/5710082/pexels-photo-5710082.jpeg?auto=compress&cs=tinysrgb&w=600" }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "ProductId", "SizeId", "StockQuantity" },
                values: new object[,]
                {
                    { 7, 1, 6 },
                    { 7, 2, 10 },
                    { 7, 3, 8 },
                    { 7, 4, 4 },
                    { 7, 5, 0 },
                    { 8, 1, 1 },
                    { 8, 2, 3 },
                    { 8, 3, 5 },
                    { 8, 4, 2 },
                    { 9, 2, 5 },
                    { 9, 3, 9 },
                    { 9, 4, 6 },
                    { 9, 5, 3 },
                    { 10, 1, 4 },
                    { 10, 2, 7 },
                    { 10, 3, 0 },
                    { 10, 4, 5 },
                    { 11, 2, 8 },
                    { 11, 3, 10 },
                    { 11, 4, 7 },
                    { 11, 5, 3 },
                    { 12, 1, 2 },
                    { 12, 2, 5 },
                    { 12, 3, 8 },
                    { 12, 4, 0 },
                    { 13, 2, 6 },
                    { 13, 3, 9 },
                    { 13, 4, 5 },
                    { 13, 5, 2 },
                    { 14, 1, 3 },
                    { 14, 2, 6 },
                    { 14, 3, 7 },
                    { 14, 4, 4 },
                    { 14, 5, 0 },
                    { 15, 2, 4 },
                    { 15, 3, 8 },
                    { 15, 4, 6 },
                    { 15, 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AuthorName", "Comment", "CreatedAt", "ProductId", "Rating" },
                values: new object[,]
                {
                    { 6, "Наталья Р.", "Лучшее летнее платье! Лёгкое, не просвечивает. Уже заказала подруге в подарок.", new DateTime(2025, 5, 1, 8, 0, 0, 0, DateTimeKind.Utc), 7, 5 },
                    { 7, "Виктория", "Платье роскошное! Единственное — нужна правильная бижутерия, сама по себе выглядит просто.", new DateTime(2025, 5, 10, 20, 0, 0, 0, DateTimeKind.Utc), 8, 4 },
                    { 8, "Ирина П.", "Джинсы мечты! Высокая посадка скрывает всё что нужно, ткань плотная и не тянется.", new DateTime(2025, 5, 15, 13, 0, 0, 0, DateTimeKind.Utc), 13, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_SizeId",
                table: "ProductSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Emoji",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Sizes");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "Size");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Size",
                table: "Size",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SizesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize", x => new { x.ProductsId, x.SizesId });
                    table.ForeignKey(
                        name: "FK_ProductSize_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSize_Size_SizesId",
                        column: x => x.SizesId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: "https://images.unsplash.com/photo-1515886657613-9f3515b0c78f?auto=format&fit=crop&w=600&q=80");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Url",
                value: "https://images.unsplash.com/photo-1544441893-675973e31985?auto=format&fit=crop&w=600&q=80");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "Url",
                value: "https://images.unsplash.com/photo-1509319117193-57bab727e09d?auto=format&fit=crop&w=600&q=80");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Классическая хлопковая футболка прямого кроя.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Трендовая свободная футболка из плотного трикотажа.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Укороченная модель для активного отдыха и тренировок.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Легкая плиссированная юбка нежного пастельного оттенка.");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_SizesId",
                table: "ProductSize",
                column: "SizesId");
        }
    }
}
