using System;
using Microsoft.EntityFrameworkCore;
using ProductAPI.ApplicationCore.Contracts.Repositories;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.Infrastructure.Data;

namespace ProductAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EShopDbContext _dbContext;
		public ProductRepository(EShopDbContext dbContext)
		{
            _dbContext = dbContext;
		}
		
		public async Task<IEnumerable<Product>> GetAllProducts()
		{
			return await _dbContext.Products.ToListAsync();
		}

		public async Task<Product> GetProductById(int id)
		{
			return await _dbContext.Products.FindAsync(id);
		}

		public async Task<int> CreateProduct(Product product)
		{
			_dbContext.Products.Add(product);
			return await _dbContext.SaveChangesAsync();
		}

		public async Task<int> UpdateProduct(Product product)
		{
			_dbContext.Products.Update(product);
			return await _dbContext.SaveChangesAsync();
		}

		public async Task<int> DeleteProduct(int id)
		{
			
			var product = await _dbContext.Products.FindAsync(id);
			if (product != null)
			{
				_dbContext.Products.Remove(product);
			}
			return await _dbContext.SaveChangesAsync();
		}
    }
}

