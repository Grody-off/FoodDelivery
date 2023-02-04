using System.Net;
using FoodDelivery.Models;
using FoodDelivery.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ILogger<OrderController> _logger;

    public OrderController(IOrderService orderService, ILogger<OrderController> logger)
    {
        _logger = logger;
        _orderService = orderService;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<OrderModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        var orderModels = new List<OrderModel>();
        _logger.LogInformation("get all orders");
        (await _orderService.GetAll()).ToList().ForEach(entity => orderModels.Add(entity.ToOrderModel()));

        return Ok(orderModels);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OrderModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetById(int id)
    {
        var address = await _orderService.GetById(id);
        _logger.LogInformation($"get order by id:{id}");
        if (address == null)
        {
            _logger.LogError($"order with id:{id} not exist");
            return BadRequest("Order is not exist");
        }
        return Ok(address);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(OrderModel entity)
    {
        _logger.LogInformation("add order");
        await _orderService.Add(entity.ToOrderEntity());
        return Ok();
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(OrderModel entity)
    {
        _logger.LogInformation("update order");
        await _orderService.Update(entity.ToOrderEntity());
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Remove(OrderModel entity)
    {
        _logger.LogInformation("remove order");
        await _orderService.Remove(entity.ToOrderEntity());
        return NoContent();
    }
}