using Microsoft.EntityFrameworkCore;

using WomenClothingStore.Domain.Entities;
using WomenClothingStore.Domain.Interfaces;
using WomenClothingStore.Infrastructure.Data;

namespace WomenClothingStore.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Images)
            .Include(p => p.ProductSizes).ThenInclude(ps => ps.Size)
            .Include(p => p.Reviews)
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Images)
            .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsWithDetailsAsync()
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Images)
            .Include(p => p.ProductSizes).ThenInclude(ps => ps.Size)
            .Include(p => p.Reviews)
            .ToListAsync();
    }

    // Новый метод: полная загрузка одного товара для страницы детали
    public async Task<Product?> GetProductWithFullDetailsAsync(int productId)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.Images)
            .Include(p => p.ProductSizes).ThenInclude(ps => ps.Size)
            .Include(p => p.Reviews)
            .FirstOrDefaultAsync(p => p.Id == productId);
    }
}