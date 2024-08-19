namespace OrderAPI.ApplicationCore.Models;

public class ShoppingCartViewModel
{
    public int Id { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }
    public List<ShoppingCartItemViewModel> ShoppingItems { get; set; }
}