using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Repositories;

public interface IShoppingCartItemRepository
{
    Task<int> SaveShoppingCartItem(ShoppingCartItem shoppingCartItem);
    Task<int> DeleteShoppingCartItem(int cartId);
    Task<int> UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem);

    Task<List<ShoppingCartItem>> GetShoppingCartItemListById(int cartId);
    Task<int> DeleteShoppingCartItemById(int shoppingCartItemId);
}