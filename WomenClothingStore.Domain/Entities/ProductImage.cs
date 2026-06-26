namespace WomenClothingStore.Domain.Entities;

public class ProductImage
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public bool IsMain { get; set; } // Главная картинка

    // Связь N:1 (Картинка принадлежит одному товару)
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}