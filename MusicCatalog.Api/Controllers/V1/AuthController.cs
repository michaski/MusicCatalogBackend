using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Application.Auth.Commands;

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

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand registerCommand)
        {
            var result = await _mediator.Send(registerCommand);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
