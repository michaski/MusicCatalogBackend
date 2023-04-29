using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MusicCatalog.Application.AlbumTypes.Responses;

namespace MusicCatalog.Application.AlbumTypes.Queries
{
    public class GetAllAlbumTypesQuery : IRequest<IEnumerable<ListAlbumTypesResponse>> { }
}
