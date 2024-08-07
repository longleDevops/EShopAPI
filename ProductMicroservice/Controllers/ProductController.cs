using System;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.ApplicationCore.Contracts.Services;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.ApplicationCore.Models;


namespace ProductMicroserviceAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController:ControllerBase
	{
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        

        // [HttpGet("category/{categoryId}")]
        // public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId)
        // {
        //     var products= await _customerService.GetProductsByCategoryAsync(categoryId);
        //     return Ok(products);
        // }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var allProducts = await _productService.GetAllProducts();
            return Ok(allProducts);
        } 
        
        [HttpPost("CreateProduct")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Product>> CreateProduct([FromBody]ProductViewModel product)
        {
            var result = await _productService.CreateProduct(product);
            if (result == 1) return Ok("Create one product successfully");
            else return BadRequest("Failed to create product") ;
        }

        [HttpPut("UpdateProduct/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateProduct(int id, ProductViewModel product)
        {
            var result = await _productService.UpdateProduct(product);
            if (result == 1) return Ok("Update one product successfully");
            else return BadRequest("Failed to update product");
            
        }

        [HttpDelete("DeleteProduct/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result == 1) return Ok("Delete products successfully");
            else return BadRequest("Failed to delete products");
        }
    }
}

