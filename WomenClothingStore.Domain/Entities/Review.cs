namespace WomenClothingStore.Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public string AuthorName { get; set; } = string.Empty; // Имя покупателя
    public string Comment { get; set; } = string.Empty;    // Текст отзыва
    public int Rating { get; set; }                         // Оценка от 1 до 5
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Связь N:1 — отзыв принадлежит одному товару
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}