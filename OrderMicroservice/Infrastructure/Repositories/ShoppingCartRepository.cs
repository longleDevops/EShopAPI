using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Entities;
using ProductAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories;

public class ShoppingCartRepository:IShoppingCartRepository
{
    private readonly EShopDbContext _dbContext;
    public ShoppingCartRepository(EShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> SaveShoppingCart(ShoppingCart shoppingCart)
    {
        await _dbContext.ShoppingCarts.AddAsync(shoppingCart);
        var result = await _dbContext.SaveChangesAsync();
        return result;
    }

    public async Task<int> DeleteShoppingCart(int shoppingCartId, Guid customerId)
    {
        var entity = await _dbContext.ShoppingCarts.Where(x => x.Id == shoppingCartId && x.CustomerId == customerId).FirstOrDefaultAsync();
        if (entity == null)
        {
            return 0;
        }

        _dbContext.ShoppingCarts.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<ShoppingCart> GetShoppingCart(int shoppingCartId, Guid customerId)
    {
        var entity = await _dbContext.ShoppingCarts.Where(x=>x.Id == shoppingCartId && x.CustomerId == customerId).FirstOrDefaultAsync();
        return entity;
    }

    public async Task<ShoppingCart> GetShoppingCart(Guid customerId)
    {
        var entity = await _dbContext.ShoppingCarts.Where(x=>x.CustomerId == customerId).FirstOrDefaultAsync();
        return entity;
    }
}