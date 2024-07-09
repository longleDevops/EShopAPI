using System;
using ProductAPI.ApplicationCore.Contracts.Repositories;
using ProductAPI.ApplicationCore.Contracts.Services;
using ProductAPI.ApplicationCore.Entities;

namespace ProductAPI.Infrastructure.Services
{
	public class AdminService:IAdminService
	{
        private readonly IProductRepository _productRepository;
		public AdminService(IProductRepository productRepository)
		{
            _productRepository = productRepository;
		}

        public async Task AddProductAsync(Product product)
        {
            await _productRepository.CreateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }
    }
}

