using Microsoft.EntityFrameworkCore;

using WomenClothingStore.Domain.Entities;

namespace WomenClothingStore.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<ProductImage> ProductImages { get; set; } = null!;
    public DbSet<Size> Sizes { get; set; } = null!;
    public DbSet<ProductSize> ProductSizes { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // =============================================
        // КОНФИГУРАЦИЯ СВЯЗЕЙ (Fluent API)
        // =============================================

        // Product -> Category (N:1)
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        // ProductImage -> Product (N:1)
        modelBuilder.Entity<ProductImage>()
            .HasOne(pi => pi.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(pi => pi.ProductId);

        // Review -> Product (N:1)
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Cascade); // При удалении товара — удалить отзывы

        // =============================================
        // ПРОМЕЖУТОЧНАЯ ТАБЛИЦА ProductSize (N:N)
        // Составной первичный ключ: ProductId + SizeId
        // =============================================
        modelBuilder.Entity<ProductSize>()
            .HasKey(ps => new { ps.ProductId, ps.SizeId });

        modelBuilder.Entity<ProductSize>()
            .HasOne(ps => ps.Product)
            .WithMany(p => p.ProductSizes)
            .HasForeignKey(ps => ps.ProductId);

        modelBuilder.Entity<ProductSize>()
            .HasOne(ps => ps.Size)
            .WithMany(s => s.ProductSizes)
            .HasForeignKey(ps => ps.SizeId);

        // Order -> OrderItem (1:N)
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // OrderItem -> Product (N:1)
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // =============================================
        // SEED DATA — Начальные данные
        // =============================================

        // --- 1. Категории ---
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Футболки", Emoji = "👕", Description = "Стильные и базовые футболки на каждый день" },
            new Category { Id = 2, Name = "Юбки", Emoji = "👗", Description = "Элегантные и модные юбки для любого сезона" },
            new Category { Id = 3, Name = "Платья", Emoji = "👘", Description = "Платья для любого повода — от casual до вечерних" },
            new Category { Id = 4, Name = "Блузки", Emoji = "👚", Description = "Лёгкие блузки и рубашки на каждый день" },
            new Category { Id = 5, Name = "Брюки", Emoji = "👖", Description = "Удобные и модные брюки и джинсы" }
        );

        // --- 2. Размеры (SortOrder задаёт порядок отображения) ---
        modelBuilder.Entity<Size>().HasData(
            new Size { Id = 1, Label = "XS", SortOrder = 1 },
            new Size { Id = 2, Label = "S", SortOrder = 2 },
            new Size { Id = 3, Label = "M", SortOrder = 3 },
            new Size { Id = 4, Label = "L", SortOrder = 4 },
            new Size { Id = 5, Label = "XL", SortOrder = 5 }
        );

        // --- 3. Товары ---
        modelBuilder.Entity<Product>().HasData(
            // Футболки (CategoryId = 1)
            new Product { Id = 1, CategoryId = 1, Name = "Базовая белая футболка", Price = 1500, Description = "Классическая хлопковая футболка прямого кроя. Идеальная база любого гардероба." },
            new Product { Id = 2, CategoryId = 1, Name = "Футболка оверсайз с принтом", Price = 2200, Description = "Трендовая свободная футболка из плотного трикотажа с авторским принтом." },
            new Product { Id = 3, CategoryId = 1, Name = "Спортивная кроп-футболка", Price = 1800, Description = "Укороченная модель для активного отдыха и тренировок. Влагоотводящий материал." },

            // Юбки (CategoryId = 2)
            new Product { Id = 4, CategoryId = 2, Name = "Юбка-миди плиссе", Price = 3500, Description = "Лёгкая плиссированная юбка нежного пастельного оттенка." },
            new Product { Id = 5, CategoryId = 2, Name = "Джинсовая юбка с разрезом", Price = 4200, Description = "Стильная макси-юбка из плотного денима с эффектным разрезом." },
            new Product { Id = 6, CategoryId = 2, Name = "Кожаная юбка-карандаш", Price = 4800, Description = "Элегантная юбка из эко-кожи для делового или вечернего образа." },

            // Платья (CategoryId = 3)
            new Product { Id = 7, CategoryId = 3, Name = "Летнее платье в цветочек", Price = 5200, Description = "Воздушное платье из натурального хлопка с цветочным принтом." },
            new Product { Id = 8, CategoryId = 3, Name = "Вечернее чёрное платье", Price = 8900, Description = "Изысканное платье-футляр из бархата для особых случаев." },
            new Product { Id = 9, CategoryId = 3, Name = "Платье-рубашка в клетку", Price = 4600, Description = "Универсальное платье свободного кроя в классическую клетку." },

            // Блузки (CategoryId = 4)
            new Product { Id = 10, CategoryId = 4, Name = "Шёлковая блузка молочная", Price = 3800, Description = "Нежная блузка из искусственного шёлка с V-образным вырезом." },
            new Product { Id = 11, CategoryId = 4, Name = "Льняная рубашка оверсайз", Price = 3200, Description = "Лёгкая льняная рубашка — идеальный выбор для жаркого лета." },
            new Product { Id = 12, CategoryId = 4, Name = "Блузка с объёмными рукавами", Price = 4100, Description = "Романтичная блузка с пышными рукавами-буфами из шифона." },

            // Брюки (CategoryId = 5)
            new Product { Id = 13, CategoryId = 5, Name = "Прямые джинсы Mom-fit", Price = 5500, Description = "Классические мом-джинсы с высокой посадкой из плотного денима." },
            new Product { Id = 14, CategoryId = 5, Name = "Льняные брюки палаццо", Price = 4700, Description = "Широкие брюки из льна — лёгкость и стиль в одном образе." },
            new Product { Id = 15, CategoryId = 5, Name = "Чёрные классические брюки", Price = 5100, Description = "Прямые брюки со стрелками из костюмной ткани. Офис и вечер." }
        );

        // --- 4. Картинки товаров ---
        modelBuilder.Entity<ProductImage>().HasData(
            // Футболки
            new ProductImage { Id = 1, ProductId = 1, IsMain = true, Url = "https://images.pexels.com/photos/9558785/pexels-photo-9558785.jpeg?auto=compress&cs=tinysrgb&w=600" },
            new ProductImage { Id = 2, ProductId = 2, IsMain = true, Url = "https://images.pexels.com/photos/34802370/pexels-photo-34802370.jpeg?auto=compress&cs=tinysrgb&w=600" },
            new ProductImage { Id = 3, ProductId = 3, IsMain = true, Url = "https://images.pexels.com/photos/9790825/pexels-photo-9790825.jpeg?auto=compress&cs=tinysrgb&w=600" },
            // Юбки
            new ProductImage { Id = 4, ProductId = 4, IsMain = true, Url = "https://images.pexels.com/photos/4690501/pexels-photo-4690501.jpeg?auto=compress&cs=tinysrgb&w=600" },
            new ProductImage { Id = 5, ProductId = 5, IsMain = true, Url = "https://images.pexels.com/photos/23947043/pexels-photo-23947043.jpeg?auto=compress&cs=tinysrgb&w=600" },
            new ProductImage { Id = 6, ProductId = 6, IsMain = true, Url = "https://images.pexels.com/photos/5217676/pexels-photo-5217676.jpeg?auto=compress&cs=tinysrgb&w=600" },
            // Платья
            new ProductImage { Id = 7, ProductId = 7, IsMain = true, Url = "https://images.pexels.com/photos/17500757/pexels-photo-17500757.jpeg?auto=compress&cs=tinysrgb&w=600" },
            new ProductImage { Id = 8, ProductId = 8, IsMain = true, Url = "https://images.pexels.com/photos/31184069/pexels-photo-31184069.jpeg?auto=compress&cs=tinysrgb&w=600" },
            new ProductImage { Id = 9, ProductId = 9, IsMain = true, Url = "https://images.pexels.com/photos/36503943/pexels-photo-36503943.jpeg?auto=compress&cs=tinysrgb&w=600" },
            // Блузки
            new ProductImage { Id = 10, ProductId = 10, IsMain = true, Url = "https://images.pexels.com/photos/10512922/pexels-photo-10512922.jpeg?auto=compress&cs=tinysrgb&w=600" },
            new ProductImage { Id = 11, ProductId = 11, IsMain = true, Url = "https://images.pexels.com/photos/33000729/pexels-photo-33000729.jpeg?auto=compress&cs=tinysrgb&w=600" },
            new ProductImage { Id = 12, ProductId = 12, IsMain = true, Url = "https://images.pexels.com/photos/10123803/pexels-photo-10123803.jpeg?auto=compress&cs=tinysrgb&w=600" },
            // Брюки
            new ProductImage { Id = 13, ProductId = 13, IsMain = true, Url = "https://images.pexels.com/photos/9558941/pexels-photo-9558941.jpeg?auto=compress&cs=tinysrgb&w=600" },
            new ProductImage { Id = 14, ProductId = 14, IsMain = true, Url = "https://images.pexels.com/photos/5393448/pexels-photo-5393448.jpeg?auto=compress&cs=tinysrgb&w=600" },
            new ProductImage { Id = 15, ProductId = 15, IsMain = true, Url = "https://images.pexels.com/photos/30887099/pexels-photo-30887099.jpeg?auto=compress&cs=tinysrgb&w=600" }
        );

        // --- 5. Остатки на складе (ProductSize) ---
        // Формат: ProductId, SizeId, StockQuantity
        // SizeId: 1=XS, 2=S, 3=M, 4=L, 5=XL
        modelBuilder.Entity<ProductSize>().HasData(
            // Товар 1 — Базовая белая футболка
            new ProductSize { ProductId = 1, SizeId = 1, StockQuantity = 3 },
            new ProductSize { ProductId = 1, SizeId = 2, StockQuantity = 8 },
            new ProductSize { ProductId = 1, SizeId = 3, StockQuantity = 12 },
            new ProductSize { ProductId = 1, SizeId = 4, StockQuantity = 5 },
            new ProductSize { ProductId = 1, SizeId = 5, StockQuantity = 0 }, // XL нет в наличии

            // Товар 2 — Оверсайз с принтом
            new ProductSize { ProductId = 2, SizeId = 2, StockQuantity = 4 },
            new ProductSize { ProductId = 2, SizeId = 3, StockQuantity = 7 },
            new ProductSize { ProductId = 2, SizeId = 4, StockQuantity = 6 },
            new ProductSize { ProductId = 2, SizeId = 5, StockQuantity = 2 },

            // Товар 3 — Кроп-футболка
            new ProductSize { ProductId = 3, SizeId = 1, StockQuantity = 5 },
            new ProductSize { ProductId = 3, SizeId = 2, StockQuantity = 9 },
            new ProductSize { ProductId = 3, SizeId = 3, StockQuantity = 0 },
            new ProductSize { ProductId = 3, SizeId = 4, StockQuantity = 3 },

            // Товар 4 — Юбка-миди плиссе
            new ProductSize { ProductId = 4, SizeId = 1, StockQuantity = 2 },
            new ProductSize { ProductId = 4, SizeId = 2, StockQuantity = 5 },
            new ProductSize { ProductId = 4, SizeId = 3, StockQuantity = 8 },
            new ProductSize { ProductId = 4, SizeId = 4, StockQuantity = 4 },
            new ProductSize { ProductId = 4, SizeId = 5, StockQuantity = 1 },

            // Товар 5 — Джинсовая юбка
            new ProductSize { ProductId = 5, SizeId = 2, StockQuantity = 3 },
            new ProductSize { ProductId = 5, SizeId = 3, StockQuantity = 6 },
            new ProductSize { ProductId = 5, SizeId = 4, StockQuantity = 0 },
            new ProductSize { ProductId = 5, SizeId = 5, StockQuantity = 4 },

            // Товар 6 — Кожаная юбка-карандаш
            new ProductSize { ProductId = 6, SizeId = 1, StockQuantity = 0 },
            new ProductSize { ProductId = 6, SizeId = 2, StockQuantity = 4 },
            new ProductSize { ProductId = 6, SizeId = 3, StockQuantity = 7 },
            new ProductSize { ProductId = 6, SizeId = 4, StockQuantity = 3 },

            // Товар 7 — Летнее платье
            new ProductSize { ProductId = 7, SizeId = 1, StockQuantity = 6 },
            new ProductSize { ProductId = 7, SizeId = 2, StockQuantity = 10 },
            new ProductSize { ProductId = 7, SizeId = 3, StockQuantity = 8 },
            new ProductSize { ProductId = 7, SizeId = 4, StockQuantity = 4 },
            new ProductSize { ProductId = 7, SizeId = 5, StockQuantity = 0 },

            // Товар 8 — Вечернее чёрное платье
            new ProductSize { ProductId = 8, SizeId = 1, StockQuantity = 1 },
            new ProductSize { ProductId = 8, SizeId = 2, StockQuantity = 3 },
            new ProductSize { ProductId = 8, SizeId = 3, StockQuantity = 5 },
            new ProductSize { ProductId = 8, SizeId = 4, StockQuantity = 2 },

            // Товар 9 — Платье-рубашка
            new ProductSize { ProductId = 9, SizeId = 2, StockQuantity = 5 },
            new ProductSize { ProductId = 9, SizeId = 3, StockQuantity = 9 },
            new ProductSize { ProductId = 9, SizeId = 4, StockQuantity = 6 },
            new ProductSize { ProductId = 9, SizeId = 5, StockQuantity = 3 },

            // Товар 10 — Шёлковая блузка
            new ProductSize { ProductId = 10, SizeId = 1, StockQuantity = 4 },
            new ProductSize { ProductId = 10, SizeId = 2, StockQuantity = 7 },
            new ProductSize { ProductId = 10, SizeId = 3, StockQuantity = 0 },
            new ProductSize { ProductId = 10, SizeId = 4, StockQuantity = 5 },

            // Товар 11 — Льняная рубашка
            new ProductSize { ProductId = 11, SizeId = 2, StockQuantity = 8 },
            new ProductSize { ProductId = 11, SizeId = 3, StockQuantity = 10 },
            new ProductSize { ProductId = 11, SizeId = 4, StockQuantity = 7 },
            new ProductSize { ProductId = 11, SizeId = 5, StockQuantity = 3 },

            // Товар 12 — Блузка с рукавами
            new ProductSize { ProductId = 12, SizeId = 1, StockQuantity = 2 },
            new ProductSize { ProductId = 12, SizeId = 2, StockQuantity = 5 },
            new ProductSize { ProductId = 12, SizeId = 3, StockQuantity = 8 },
            new ProductSize { ProductId = 12, SizeId = 4, StockQuantity = 0 },

            // Товар 13 — Mom-fit джинсы
            new ProductSize { ProductId = 13, SizeId = 2, StockQuantity = 6 },
            new ProductSize { ProductId = 13, SizeId = 3, StockQuantity = 9 },
            new ProductSize { ProductId = 13, SizeId = 4, StockQuantity = 5 },
            new ProductSize { ProductId = 13, SizeId = 5, StockQuantity = 2 },

            // Товар 14 — Брюки палаццо
            new ProductSize { ProductId = 14, SizeId = 1, StockQuantity = 3 },
            new ProductSize { ProductId = 14, SizeId = 2, StockQuantity = 6 },
            new ProductSize { ProductId = 14, SizeId = 3, StockQuantity = 7 },
            new ProductSize { ProductId = 14, SizeId = 4, StockQuantity = 4 },
            new ProductSize { ProductId = 14, SizeId = 5, StockQuantity = 0 },

            // Товар 15 — Классические брюки
            new ProductSize { ProductId = 15, SizeId = 2, StockQuantity = 4 },
            new ProductSize { ProductId = 15, SizeId = 3, StockQuantity = 8 },
            new ProductSize { ProductId = 15, SizeId = 4, StockQuantity = 6 },
            new ProductSize { ProductId = 15, SizeId = 5, StockQuantity = 3 }
        );

        // --- 6. Тестовые отзывы ---
        modelBuilder.Entity<Review>().HasData(
            new Review { Id = 1, ProductId = 1, AuthorName = "Анна К.", Rating = 5, Comment = "Отличное качество! Ткань мягкая, не садится после стирки. Беру уже третью.", CreatedAt = new DateTime(2025, 3, 10, 10, 0, 0, DateTimeKind.Utc) },
            new Review { Id = 2, ProductId = 1, AuthorName = "Мария Д.", Rating = 4, Comment = "Хорошая футболка, но размер немного большемерит. Советую брать на размер меньше.", CreatedAt = new DateTime(2025, 3, 15, 14, 30, 0, DateTimeKind.Utc) },
            new Review { Id = 3, ProductId = 2, AuthorName = "Екатерина", Rating = 5, Comment = "Просто в восторге! Принт очень чёткий, оверсайз посадка как на картинке.", CreatedAt = new DateTime(2025, 4, 1, 9, 0, 0, DateTimeKind.Utc) },
            new Review { Id = 4, ProductId = 4, AuthorName = "Ольга С.", Rating = 5, Comment = "Юбка великолепная! Ткань не мнётся, цвет нежный. Получила море комплиментов.", CreatedAt = new DateTime(2025, 4, 5, 16, 0, 0, DateTimeKind.Utc) },
            new Review { Id = 5, ProductId = 4, AuthorName = "Светлана", Rating = 3, Comment = "Юбка красивая, но пришла с небольшой затяжкой. Магазин решил вопрос быстро.", CreatedAt = new DateTime(2025, 4, 12, 11, 0, 0, DateTimeKind.Utc) },
            new Review { Id = 6, ProductId = 7, AuthorName = "Наталья Р.", Rating = 5, Comment = "Лучшее летнее платье! Лёгкое, не просвечивает. Уже заказала подруге в подарок.", CreatedAt = new DateTime(2025, 5, 1, 8, 0, 0, DateTimeKind.Utc) },
            new Review { Id = 7, ProductId = 8, AuthorName = "Виктория", Rating = 4, Comment = "Платье роскошное! Единственное — нужна правильная бижутерия, сама по себе выглядит просто.", CreatedAt = new DateTime(2025, 5, 10, 20, 0, 0, DateTimeKind.Utc) },
            new Review { Id = 8, ProductId = 13, AuthorName = "Ирина П.", Rating = 5, Comment = "Джинсы мечты! Высокая посадка скрывает всё что нужно, ткань плотная и не тянется.", CreatedAt = new DateTime(2025, 5, 15, 13, 0, 0, DateTimeKind.Utc) }
        );
    }
}