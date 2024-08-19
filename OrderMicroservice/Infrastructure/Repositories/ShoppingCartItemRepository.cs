using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using ProductAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories;

public class ShoppingCartItemRepository: IShoppingCartItemRepository
{
    private readonly EShopDbContext _dbContext;
    public ShoppingCartItemRepository(EShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> SaveShoppingCartItem(ShoppingCartItem shoppingCartItem)
    {
        await _dbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
        var result = await _dbContext.SaveChangesAsync();
        return result;
    }

    public async Task<int> DeleteShoppingCartItem(int cartId)
    {
        var entity = await _dbContext.ShoppingCartItems.Where(x => x.CartId == cartId).ToListAsync();
        if (entity == null)
        {
            return 0;
        }

        _dbContext.ShoppingCartItems.RemoveRange(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem)
    {
        _dbContext.ShoppingCartItems.Update(shoppingCartItem);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<List<ShoppingCartItem>> GetShoppingCartItemListById(int cartId)
    {
        var entity = await _dbContext.ShoppingCartItems.Where(x => x.CartId == cartId).ToListAsync();
        return entity;
    }

    public async Task<int> DeleteShoppingCartItemById(int shoppingCartItemId)
    {
        var entity = await _dbContext.ShoppingCartItems.Where(x => x.Id == shoppingCartItemId).FirstOrDefaultAsync();
        if (entity == null)
        {
            return 0;
        }

        _dbContext.ShoppingCartItems.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }
}