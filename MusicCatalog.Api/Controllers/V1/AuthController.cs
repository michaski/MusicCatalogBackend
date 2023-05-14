using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Application.Auth.Commands.Login;
using MusicCatalog.Application.Auth.Commands.Register;
using Swashbuckle.AspNetCore.Annotations;

namespace MusicCatalog.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _mediator;

        public AuthController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        [SwaggerOperation(Summary = "Create new user account.")]
        public async Task<IActionResult> Register(RegisterCommand registerCommand)
        {
            var result = await _mediator.Send(registerCommand);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "Log in to an existing account. Returns a JWT token.")]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            var result = await _mediator.Send(loginCommand);
            return result.Succeeded 
                ? Ok(new { Token = result.Token }) 
                : Unauthorized(new { Message = result.Message });
        }
    }
}
