using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Application.AlbumTypes.Queries;

namespace MusicCatalog.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class AlbumTypesController : ControllerBase
    {
        private readonly ISender _mediator;

        public AlbumTypesController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllAlbumTypesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
