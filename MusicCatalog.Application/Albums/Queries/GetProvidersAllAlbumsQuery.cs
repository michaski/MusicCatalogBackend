using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MusicCatalog.Application.Albums.Responses;
using MusicCatalog.Application.Dtos.Pagination;
using MusicCatalog.Domain.Utils;

namespace MusicCatalog.Application.Albums.Queries
{
    public class GetProvidersAllAlbumsQuery : IRequest<PagedResult<ListAlbumResponse>>
    {
        public QueryFilters Filters { get; }

        public GetProvidersAllAlbumsQuery(QueryFilters filters)
        {
            Filters = filters;
        }
    }
}
