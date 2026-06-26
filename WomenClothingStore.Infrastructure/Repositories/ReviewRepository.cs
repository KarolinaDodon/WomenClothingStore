using Microsoft.EntityFrameworkCore;

using WomenClothingStore.Domain.Entities;
using WomenClothingStore.Domain.Interfaces;
using WomenClothingStore.Infrastructure.Data;

namespace WomenClothingStore.Infrastructure.Repositories;

public class ReviewRepository : Repository<Review>, IReviewRepository
{
    public ReviewRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Review>> GetByProductIdAsync(int productId)
    {
        return await _dbSet
            .Where(r => r.ProductId == productId)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
    }
}