using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Application.Auth.Commands.Login;
using MusicCatalog.Application.Auth.Commands.Register;

namespace MusicCatalog.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _mediator;

        public AuthController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterCommand registerCommand)
        {
            var result = await _mediator.Send(registerCommand);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            var result = await _mediator.Send(loginCommand);
            return result.Succeeded 
                ? Ok(new { Token = result.Token }) 
                : Unauthorized(new { Message = result.Message });
        }
    }
}
