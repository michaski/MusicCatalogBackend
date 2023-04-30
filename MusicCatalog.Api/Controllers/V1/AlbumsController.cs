using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Application.Albums.Commands;
using MusicCatalog.Application.Albums.Queries;

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
        public async Task<IActionResult> GetProvidersAllAlbums()
        {
            var query = new GetProvidersAllAlbumsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
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
        public async Task<IActionResult> CreateNewAlbum(CreateNewAlbumCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetAlbumById", new { Id = result.Id }, result);
        }

        [HttpPut]
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
