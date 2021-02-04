using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZELF.SocialNetwork.Api.Interfaces;
using ZELF.SocialNetwork.Api.Requests;
using ZELF.SocialNetwork.Host.Filters;

namespace ZELF.SocialNetwork.Host.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService<Guid> _userService;

        public UsersController(IUserService<Guid> userService)
        {
            _userService = userService;
        }

        [HttpPut("create-user")]
        [ValidateModelState]
        public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken token)
        {
            var result = await _userService.CreateUser(request, token);
            return Ok(result);
        }

        [HttpPost("subscribe-user")]
        [ValidateModelState]
        public async Task<IActionResult> SubscribeUser(SubscribeUserRequest<Guid> request, CancellationToken token)
        {
            var result = await _userService.SubscribeUser(request, token);
            return Ok(result);
        }

        // Использование Post для возможности работать из Swagger
        [HttpPost("top-users")]
        [ValidateModelState]
        public async Task<IActionResult> GetTopUsers(TopUsersRequest request, CancellationToken token)
        {
            var result = await _userService.GetTopUsers(request, token);
            return Ok(result);
        }
    }
}
