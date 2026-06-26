using WomenClothingStore.Domain.Entities;

namespace WomenClothingStore.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
    Task<IEnumerable<Product>> GetProductsWithDetailsAsync();

    // НОВЫЙ МЕТОД: загрузить товар со всеми связями (размеры, отзывы, картинки)
    Task<Product?> GetProductWithFullDetailsAsync(int productId);
}