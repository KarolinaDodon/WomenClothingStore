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

        // Первоначальные данные 
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Платья", Description = "Элегантные платья" },
            new Category { Id = 2, Name = "Блузки", Description = "Стильные блузки" },
            new Category { Id = 3, Name = "Брюки", Description = "Удобные брюки" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, CategoryId = 1, Name = "Элегантное платье", Price = 4500, Description = "Прекрасное вечернее платье для любого случая." },
            new Product { Id = 2, CategoryId = 2, Name = "Стильная блузка", Price = 2800, Description = "Модная блузка из легкого материала." },
            new Product { Id = 3, CategoryId = 3, Name = "Удобные классические брюки", Price = 3900, Description = "Подойдут как для офиса, так и для повседневной носки." }
        );

        // Используем ссылки на фото из открытого источника
        modelBuilder.Entity<ProductImage>().HasData(
            new ProductImage { Id = 1, ProductId = 1, Url = "https://images.pexels.com/photos/2065195/pexels-photo-2065195.jpeg?auto=compress&cs=tinysrgb&w=600", IsMain = true },
            new ProductImage { Id = 2, ProductId = 2, Url = "https://images.pexels.com/photos/1485031/pexels-photo-1485031.jpeg?auto=compress&cs=tinysrgb&w=600", IsMain = true },
            new ProductImage { Id = 3, ProductId = 3, Url = "https://images.pexels.com/photos/1598507/pexels-photo-1598507.jpeg?auto=compress&cs=tinysrgb&w=600", IsMain = true }
        );
    }
}