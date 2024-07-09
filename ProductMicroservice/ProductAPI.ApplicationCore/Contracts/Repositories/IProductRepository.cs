using System;
using ProductAPI.ApplicationCore.Entities;

namespace ProductAPI.ApplicationCore.Contracts.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetProductsAsync();
	
		Task<Product> GetProductByIdAsync(int id);
		Task CreateProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync(int pageIndex, int pageSize);
    }
}

