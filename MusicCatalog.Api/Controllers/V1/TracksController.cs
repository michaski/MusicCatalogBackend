using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Application.Tracks.Commands;
using MusicCatalog.Application.Tracks.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace MusicCatalog.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class TracksController : ControllerBase
    {
        private readonly ISender _mediator;

        public TracksController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get details of a track with given id.")]
        public async Task<IActionResult> GetTrackById(Guid id)
        {
            var query = new GetTrackByIdQuery(id);
            var result = await _mediator.Send(query);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create new track.")]
        public async Task<IActionResult> AddTrack(AddTrackCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Status switch
            {
                400 => BadRequest(),
                403 => Forbid(),
                203 => CreatedAtAction("GetTrackById", new { id = result.TrackResponse.Id }, result.TrackResponse)
            };
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update track's info.")]
        public async Task<IActionResult> UpdateTrack(UpdateTrackCommand command)
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
        [SwaggerOperation(Summary = "Delete track with given id.")]
        public async Task<IActionResult> DeleteTrack([FromRoute] DeleteTrackCommand command)
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
