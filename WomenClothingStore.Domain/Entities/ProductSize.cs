namespace WomenClothingStore.Domain.Entities;

// Промежуточная таблица для связи N:N между Product и Size.
// Содержит склад: сколько единиц данного размера есть в наличии.
public class ProductSize
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int SizeId { get; set; }
    public Size Size { get; set; } = null!;

    public int StockQuantity { get; set; } = 0; // Количество на складе
}