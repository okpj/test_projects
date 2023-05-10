using Messenger.Model;
using Messenger.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetUser")]
        public async Task<User?> Get()
        {
            return await _userService.GetUserById(1);
        }
    }
}
