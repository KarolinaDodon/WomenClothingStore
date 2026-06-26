namespace WomenClothingStore.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;

    // —в€зь N:1 с категорией
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    // —в€зь 1:N Ч много картинок у одного товара
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();

    // —в€зь N:N через промежуточную таблицу ProductSize (с остатками)
    public ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();

    // —в€зь 1:N Ч много отзывов у одного товара
    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    // ¬ычисл€емое свойство Ч средний рейтинг (не хранитс€ в Ѕƒ)
    public double AverageRating =>
        Reviews != null && Reviews.Any()
            ? Math.Round(Reviews.Average(r => r.Rating), 1)
            : 0;
}