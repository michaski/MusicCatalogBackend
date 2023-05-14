using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Application.Albums.Commands;
using MusicCatalog.Application.Albums.Queries;
using MusicCatalog.Domain.Utils;
using Swashbuckle.AspNetCore.Annotations;

namespace MusicCatalog.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class AlbumsController : ControllerBase
    {
        private readonly ISender _mediator;

        public AlbumsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all provider's albums.")]
        public async Task<IActionResult> GetProvidersAllAlbums([FromQuery] QueryFilters filters)
        {
            var query = new GetProvidersAllAlbumsQuery(filters);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get album details.")]
        public async Task<IActionResult> GetAlbumById(Guid id)
        {
            var query = new GetAlbumDetailsQuery(id);
            var result = await _mediator.Send(query);
            if (!result.Succeeded)
            {
                return result.Error switch
                {
                    404 => NotFound(),
                    403 => Forbid()
                };
            }
            return Ok(result.Album);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create new album.")]
        public async Task<IActionResult> CreateNewAlbum(CreateNewAlbumCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetAlbumById", new { Id = result.Id }, result);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update album's info.")]
        public async Task<IActionResult> UpdateAlbum(UpdateAlbumCommand command)
        {
            var result = await _mediator.Send(command);
            return result switch
            {
                400 => BadRequest(),
                403 => Forbid(),
                204 => NoContent()
            };
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete album with given id.")]
        public async Task<IActionResult> DeleteAlbum([FromRoute] DeleteAlbumCommand command)
        {
            var result = await _mediator.Send(command);
            return result switch
            {
                400 => BadRequest(),
                403 => Forbid(),
                204 => NoContent()
            };
        }
    }
}
