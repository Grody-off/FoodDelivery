using System.Net;
using FoodDelivery.Models;
using FoodDelivery.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;
    private readonly ILogger<AddressController> _logger;

    public AddressController(IAddressService addressService, ILogger<AddressController> logger)
    {
        _logger = logger;
        _addressService = addressService;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<AddressModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        var addressModels = new List<AddressModel>();
        (await _addressService.GetAll()).ToList().ForEach(entity => addressModels.Add(entity.ToAddressModel()));
        _logger.LogInformation("get all addresses");
        return Ok(addressModels);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AddressModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation($"get address by id: {id}");
        var address = await _addressService.GetById(id);
        if (address == null)
            return BadRequest("Address is not exist");
        return Ok(address);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(AddressModel entity)
    {
        _logger.LogInformation("add address");
        await _addressService.Add(entity.ToAddressEntity());
        return Ok();
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(AddressModel entity)
    {
        _logger.LogInformation("update address");
        await _addressService.Update(entity.ToAddressEntity());
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Remove(AddressModel entity)
    {
        _logger.LogInformation("remove address");
        await _addressService.Remove(entity.ToAddressEntity());
        return NoContent();
    }
}