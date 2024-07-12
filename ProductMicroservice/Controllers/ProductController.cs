using System;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.ApplicationCore.Contracts.Services;
using ProductAPI.ApplicationCore.Entities;


namespace ProductMicroserviceAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController:ControllerBase
	{
        private readonly ICustomerService _customerService;
        private readonly IAdminService _adminService;

        public ProductController(ICustomerService customerService, IAdminService adminService)
        {
            _customerService = customerService;
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int pageIndex, int pageSize)
        {
            var products = await _customerService.GetProductsAsync(pageIndex, pageSize);
            return Ok(products);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId)
        {
            var products= await _customerService.GetProductsByCategoryAsync(categoryId);
            return Ok(products);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Product>> CreateProduct([FromBody]Product product)
        {
            await _adminService.AddProductAsync(product);
            return Ok("");
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            await _adminService.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _adminService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}

