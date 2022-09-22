using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Queries.LoginUser;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            var accessToken = await Mediator.Send(registerUserCommand);
            return Ok( accessToken);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserQuery loginUserQuery)
        {
            var accessToken = await Mediator.Send(loginUserQuery);
            return Ok(accessToken);
        }
    }
}
