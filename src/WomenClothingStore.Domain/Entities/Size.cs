namespace WomenClothingStore.Domain.Entities;

public class Size
{
    public int Id { get; set; }
    public string Label { get; set; } = string.Empty; // Например "S" или "44"

    // Связь N:N (Этот размер доступен у многих товаров)
    public ICollection<Product> Products { get; set; } = new List<Product>();
}