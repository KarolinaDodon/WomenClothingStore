using WomenClothingStore.Domain.Entities;

namespace WomenClothingStore.Web.Services;

public class CartService
{
    private readonly List<CartItem> _items = new List<CartItem>();
    public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

    public void AddProduct(Product product, string selectedSize = "")
    {
        var existingItem = _items.FirstOrDefault(i =>
            i.Product.Id == product.Id && i.SelectedSize == selectedSize);

        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            _items.Add(new CartItem
            {
                Product = product,
                Quantity = 1,
                SelectedSize = selectedSize
            });
        }
    }

    public void DecreaseQuantity(int productId, string selectedSize)
    {
        var existingItem = _items.FirstOrDefault(i =>
            i.Product.Id == productId && i.SelectedSize == selectedSize);

        if (existingItem != null)
        {
            existingItem.Quantity--;
            if (existingItem.Quantity <= 0)
                _items.Remove(existingItem);
        }
    }

    public void RemoveProduct(int productId, string selectedSize)
    {
        var existingItem = _items.FirstOrDefault(i =>
            i.Product.Id == productId && i.SelectedSize == selectedSize);

        if (existingItem != null)
            _items.Remove(existingItem);
    }

    public int GetTotalCount() => _items.Sum(i => i.Quantity);
    public decimal GetTotalSum() => _items.Sum(i => i.TotalPrice);
    public void ClearCart() => _items.Clear();
}

public class CartItem
{
    public Product Product { get; set; } = null!;
    public string SelectedSize { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal TotalPrice => Product.Price * Quantity;
}