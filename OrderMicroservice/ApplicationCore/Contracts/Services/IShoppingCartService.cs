using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface IShoppingCartService
{
    Task<int> SaveShoppingCart (ShoppingCartViewModel shoppingCart);
    Task<int> DeleteShoppingCart(int Id, Guid customerId);
    Task<ShoppingCartViewModel> GetShoppingCartByCustomerId(Guid customerId);
}