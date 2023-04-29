using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Application.Users.Commands;
using MusicCatalog.Application.Users.Queries;

namespace MusicCatalog.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ISender _mediator;

        public UsersController(ISender mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("unactivated")]
        public async Task<IActionResult> GetAllUnactivated()
        {
            var query = new GetAllUnactivatedQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("unactivated/{UserId}")]
        public async Task<IActionResult> ActivateUser([FromRoute] ActivateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? NoContent() : BadRequest();
        }
    }
}
