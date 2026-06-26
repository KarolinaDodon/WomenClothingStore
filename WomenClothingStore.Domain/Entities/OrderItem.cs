using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenClothingStore.Domain.Entities;

public class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public string SelectedSize { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; } // Цена на момент заказа
}
