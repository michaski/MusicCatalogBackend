using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MusicCatalog.Application.Albums.Responses;

namespace MusicCatalog.Application.Albums.Queries
{
    public class GetProvidersAllAlbumsQuery : IRequest<IEnumerable<ListAlbumResponse>> { }
}
