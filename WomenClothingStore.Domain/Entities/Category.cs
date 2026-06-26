namespace WomenClothingStore.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Emoji { get; set; } = "👗"; // Иконка для UI

    // Связь 1:N — одна категория содержит много товаров
    public ICollection<Product> Products { get; set; } = new List<Product>();
}