using System;
using ProductAPI.ApplicationCore.Contracts.Repositories;
using ProductAPI.ApplicationCore.Contracts.Services;
using ProductAPI.ApplicationCore.Entities;

namespace ProductAPI.Infrastructure.Services
{
	public class CustomerService:ICustomerService
	{
		private readonly IProductRepository _productRepository;
		public CustomerService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

        public async Task<IEnumerable<Product>> GetProductsAsync(int pageIndex, int pageSize)
        {
            return await _productRepository.GetProductsAsync(pageIndex, pageSize);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}

