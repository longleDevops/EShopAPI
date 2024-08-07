namespace OrderAPI.ApplicationCore.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }
    public List<ShoppingCartItem> ShoppingItems { get; set; }
}