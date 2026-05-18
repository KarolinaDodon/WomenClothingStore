using WomenClothingStore.Domain.Entities;

namespace WomenClothingStore.Domain.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<IEnumerable<Category>> GetCategoriesWithProductsAsync();
}