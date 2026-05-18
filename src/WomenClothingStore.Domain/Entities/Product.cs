namespace WomenClothingStore.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;

    // Связь 1:N
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    // Связь 1:N (Много картинок у одного товара)
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();

    // Связь N:N (Много размеров у одного товара)
    public ICollection<Size> Sizes { get; set; } = new List<Size>();
}