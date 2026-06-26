using WomenClothingStore.Domain.Entities;
using WomenClothingStore.Domain.Interfaces;
using WomenClothingStore.Infrastructure.Data;

namespace WomenClothingStore.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }
}