using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Repositories;

public interface IShoppingCartRepository
{
    Task<int> SaveShoppingCart(ShoppingCart shoppingCart);
    Task<int> DeleteShoppingCart(int shoppingCartId, Guid customerId);
    Task<ShoppingCart> GetShoppingCart(int shoppingCartId, Guid customerId);
    Task<ShoppingCart> GetShoppingCart(Guid customerId);
}