using System.Net;
using FoodDelivery.Models;
using FoodDelivery.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IProductService productService, ILogger<ProductController> logger)
    {
        _logger = logger;
        _productService = productService;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("get all products");
        var productModels = new List<ProductModel>();
        (await _productService.GetAll()).ToList().ForEach(entity => productModels.Add(entity.ToProductModel()));

        return Ok(productModels);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation($"get product by id:{id}");
        var address = await _productService.GetById(id);
        if (address == null)
            return BadRequest("Product is not exist");
        return Ok(address);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(ProductModel entity)
    {
        _logger.LogInformation("add product");
        await _productService.Add(entity.ToProductEntity());
        return Ok();
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(ProductModel entity)
    {
        _logger.LogInformation("update product");
        await _productService.Update(entity.ToProductEntity());
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Remove(ProductModel entity)
    {
        _logger.LogInformation("remove product");
        await _productService.Remove(entity.ToProductEntity());
        return NoContent();
    }
}