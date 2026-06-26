namespace WomenClothingStore.Domain.Entities;

public class Size
{
    public int Id { get; set; }
    public string Label { get; set; } = string.Empty; // "S", "M", "L", "XL" или "42", "44"
    public int SortOrder { get; set; } = 0; // ƒл€ правильной сортировки в UI

    // Ќавигационное свойство через промежуточную таблицу
    public ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
}