using WomenClothingStore.Domain.Entities;

namespace WomenClothingStore.Domain.Interfaces;

public interface IReviewRepository : IRepository<Review>
{
    // Получить все отзывы для конкретного товара
    Task<IEnumerable<Review>> GetByProductIdAsync(int productId);
}