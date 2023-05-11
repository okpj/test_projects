using Messenger.Contracts.User;
using Messenger.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : MessengerControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdRequest request)
    {
        var result = await _userService.GetUserById(request);
        return CreateResponse(result);
    }


    [HttpGet("GetUserByName")]
    public async Task<IActionResult> GetUserByName([FromQuery] GetUserByNameRequest request)
    {
        var result = await _userService.GetUserByName(request);
        return CreateResponse(result);
    }


    [HttpGet("GetUserListByName")]
    public async Task<IActionResult> GetUsersByName([FromQuery] GetUserListByNameRequest request)
    {
        var result = await _userService.GetUsersByName(request);
        return CreateResponse(result);
    }


    [HttpPost("AddOrUpdateUser")]
    public async Task<IActionResult> CreateUser([FromBody] AddOrUpdateUserRequest request)
    {
        var result = await _userService.CreateUserAsync(request);
        return CreateResponse(result);
    }
}
