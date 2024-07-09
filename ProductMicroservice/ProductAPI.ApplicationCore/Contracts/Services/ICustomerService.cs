using System;
using ProductAPI.ApplicationCore.Entities;

namespace ProductAPI.ApplicationCore.Contracts.Services
{
	public interface ICustomerService
	{
		Task<IEnumerable<Product>> GetProductsAsync(int pageIndex, int pageSize);
		Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
	}
}

