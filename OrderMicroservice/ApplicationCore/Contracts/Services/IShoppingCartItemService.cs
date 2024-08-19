using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface IShoppingCartItemService
{
    Task<int> SaveShoppingCartItem(List<ShoppingCartItemViewModel> shoppingCart);
    Task<int> DeleteShoppingCartItem(int cartId);
    Task<int> UpdateShoppingCartItem(ShoppingCartItemViewModel shoppingCartItem);

    Task<int> DeleteShoppingCartItemById(int shoppingCartItemId);
    
    Task<List<ShoppingCartItemViewModel>> GetShoppingCartItemByCustomerId(int CartId);

}