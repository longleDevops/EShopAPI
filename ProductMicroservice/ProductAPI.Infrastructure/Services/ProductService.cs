using AutoMapper;
using ProductAPI.ApplicationCore.Contracts.Repositories;
using ProductAPI.ApplicationCore.Contracts.Services;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.ApplicationCore.Models;
using ProductAPI.Infrastructure.Common;

namespace ProductAPI.Infrastructure.Services;

public class ProductService:IProductService
{
    // repositories will be injected into services
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
    {
        var productEntity = await _productRepository.GetAllProducts();
        var mapper = MapperConfig.InitializeAutomapper();
        return mapper.Map<IEnumerable<ProductViewModel>>(productEntity);
    }

    public async Task<ProductViewModel> GetProductById(int id)
    {
        var productEntity = await _productRepository.GetProductById(id);
        var mapper = MapperConfig.InitializeAutomapper();
        return mapper.Map<ProductViewModel>(productEntity);
    }

    public async Task<int> CreateProduct(ProductViewModel product)
    {
        var mapper = MapperConfig.InitializeAutomapper();
        var productEntity = mapper.Map<Product>(product);
        return await _productRepository.CreateProduct(productEntity);
    }

    public async Task<int> UpdateProduct(ProductViewModel product)
    {
        var mapper = MapperConfig.InitializeAutomapper();
        var productEntity = mapper.Map<Product>(product);
        return await _productRepository.UpdateProduct(productEntity);
    }

    public async Task<int> DeleteProduct(int id)
    {
        return await _productRepository.DeleteProduct(id);
    }
}