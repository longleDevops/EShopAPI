using System;
using ProductAPI.ApplicationCore.Entities;

namespace ProductAPI.ApplicationCore.Contracts.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAllProducts();
	
		Task<Product> GetProductById(int id);
		Task<int> CreateProduct(Product product);
		Task<int> UpdateProduct(Product product);
		Task<int> DeleteProduct(int id);
    }
}

