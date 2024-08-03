using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OllieShop.Catalog.Dtos.ProductStockDtos;
using OllieShop.Catalog.Services.ProductStockServices;

namespace OllieShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStocksController : ControllerBase
    {
        private readonly IProductStockService _productStockService;

        public ProductStocksController(IProductStockService productStockService)
        {
            _productStockService = productStockService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductStockList()
        {
            var values = await _productStockService.GetAllProductStockAsync();
            return Ok(values);
        }

        [HttpGet("GetProductStocksByProductId/{id}")]
        public async Task<IActionResult> GetProductStocksByProductId(string id)
        {
            var values = await _productStockService.GetProductStocksByProductId(id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductStockById(string id)
        {
            var value = await _productStockService.GetByIdProductStockAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductStock(CreateProductStockDto createProductStockDto)
        {
            await _productStockService.CreateProductStockAsync(createProductStockDto);
            return Ok("Product Stock Added Successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductStock(string id)
        {
            await _productStockService.DeleteProductStockAsync(id);
            return Ok("Product Stock Deleted Successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductStock(UpdateProductStockDto updateProductStockDto)
        {
            await _productStockService.UpdateProductStockAsync(updateProductStockDto);
            return Ok("Product Stock Updated Successfully.");
        }

        [HttpGet("GetProductStocksWithDetails")]
        public async Task<IActionResult> GetProductStocksWithDetails()
        {
            var values = await _productStockService.GetProductStocksWithDetails();
            return Ok(values);
        }
    }
}
