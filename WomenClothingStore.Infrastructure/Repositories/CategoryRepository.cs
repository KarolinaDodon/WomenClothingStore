using Microsoft.EntityFrameworkCore;
using WomenClothingStore.Domain.Entities;
using WomenClothingStore.Domain.Interfaces;
using WomenClothingStore.Infrastructure.Data;

namespace WomenClothingStore.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
    {
        return await _dbSet
            .Include(c => c.Products)
            .ThenInclude(p => p.Images)
            .ToListAsync();
    }
}