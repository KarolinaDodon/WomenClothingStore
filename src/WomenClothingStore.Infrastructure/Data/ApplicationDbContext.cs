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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Конфигурация связей ( Fluent API )
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<ProductImage>()
            .HasOne(pi => pi.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(pi => pi.ProductId);

        // 1. Первоначальные данные категорий (Подкаталоги)
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Футболки", Description = "Стильные и базовые футболки на каждый день" },
            new Category { Id = 2, Name = "Юбки", Description = "Элегантные и модные юбки для любого сезона" }
        );

        // 2. Первоначальные данные товаров
        modelBuilder.Entity<Product>().HasData(
            // --- ФУТБОЛКИ ---
            new Product { Id = 1, CategoryId = 1, Name = "Базовая белая футболка", Price = 1500, Description = "Классическая хлопковая футболка прямого кроя." },
            new Product { Id = 2, CategoryId = 1, Name = "Футболка оверсайз с принтом", Price = 2200, Description = "Трендовая свободная футболка из плотного трикотажа." },
            new Product { Id = 3, CategoryId = 1, Name = "Спортивная кроп-футболка", Price = 1800, Description = "Укороченная модель для активного отдыха и тренировок." },

            // --- ЮБКИ ---
            new Product { Id = 4, CategoryId = 2, Name = "Юбка-миди плиссе", Price = 3500, Description = "Легкая плиссированная юбка нежного пастельного оттенка." },
            new Product { Id = 5, CategoryId = 2, Name = "Джинсовая юбка с разрезом", Price = 4200, Description = "Стильная макси-юбка из плотного денима с эффектным разрезом." },
            new Product { Id = 6, CategoryId = 2, Name = "Кожаная юбка-карандаш", Price = 4800, Description = "Элегантная юбка из эко-кожи для делового или вечернего образа." }
        );

        // 3. Первоначальные данные картинок с прямыми ссылками
        modelBuilder.Entity<ProductImage>().HasData(
            // Фото для футболок
            new ProductImage { Id = 1, ProductId = 1, Url = "https://images.pexels.com/photos/1484799/pexels-photo-1484799.jpeg?auto=compress&cs=tinysrgb&w=600", IsMain = true },
            new ProductImage { Id = 2, ProductId = 2, Url = "https://images.pexels.com/photos/2294342/pexels-photo-2294342.jpeg?auto=compress&cs=tinysrgb&w=600", IsMain = true },
            new ProductImage { Id = 3, ProductId = 3, Url = "https://images.pexels.com/photos/3534523/pexels-photo-3534523.jpeg?auto=compress&cs=tinysrgb&w=600", IsMain = true },

            
            new ProductImage { Id = 4, ProductId = 4, Url = "https://images.pexels.com/photos/4690501/pexels-photo-4690501.jpeg?auto=compress&cs=tinysrgb&w=600", IsMain = true },
            new ProductImage { Id = 5, ProductId = 5, Url = "https://images.pexels.com/photos/23947043/pexels-photo-23947043.jpeg?auto=compress&cs=tinysrgb&w=600", IsMain = true },
            new ProductImage { Id = 6, ProductId = 6, Url = "https://images.pexels.com/photos/5217676/pexels-photo-5217676.jpeg?auto=compress&cs=tinysrgb&w=600", IsMain = true }
        );
    }
}