using ProductAPI.ApplicationCore.Models;

namespace ProductAPI.ApplicationCore.Contracts.Services;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllProducts();
	
    Task<ProductViewModel> GetProductById(int id);
    Task<int> CreateProduct(ProductViewModel product);
    Task<int> UpdateProduct(ProductViewModel product);
    Task<int> DeleteProduct(int id);
}