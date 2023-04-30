using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MusicCatalog.Application.Albums.Responses;

namespace MusicCatalog.Application.Albums.Queries
{
    public class GetAlbumDetailsQuery : IRequest<GetAlbumResponse>
    {
        public Guid AlbumId { get; }

        public GetAlbumDetailsQuery(Guid albumId)
        {
            AlbumId = albumId;
        }
    }
}
