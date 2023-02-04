using System.Net;
using FoodDelivery.Models;
using FoodDelivery.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<UserModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("get all users");
        var userModels = new List<UserModel>();
        (await _userService.GetAll()).ToList().ForEach(entity => userModels.Add(entity.ToUserModel()));

        return Ok(userModels);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation($"get user by id:{id}");
        var user = await _userService.GetById(id);
        if (user == null)
            return BadRequest("User is not exist");
        return Ok(user.ToUserModel());
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(UserModel model)
    {
        _logger.LogInformation("add user");
        await _userService.Add(model.ToUserEntity());
        return Ok();
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UserModel model)
    {
        _logger.LogInformation("update user");
        await _userService.Update(model.ToUserEntity());
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Remove(UserModel model)
    {
        _logger.LogInformation("remove user");
        await _userService.Remove(model.ToUserEntity());
        return NoContent();
    }
}