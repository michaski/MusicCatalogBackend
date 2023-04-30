using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MusicCatalog.Application.Tracks.Responses;

namespace MusicCatalog.Application.Tracks.Queries
{
    public class GetTrackByIdQuery : IRequest<TrackDetailsResponse>
    {
        public Guid TrackId { get; }

        public GetTrackByIdQuery(Guid trackId)
        {
            TrackId = trackId;
        }
    }
}
