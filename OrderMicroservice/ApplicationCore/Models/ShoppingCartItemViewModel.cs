namespace OrderAPI.ApplicationCore.Models;

public class ShoppingCartItemViewModel
{
    public int Id { get; set; }
    public int CartId { get; set; } 
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
}