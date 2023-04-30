using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MusicCatalog.Application.Albums.Responses;
using MusicCatalog.Application.Dtos.Pagination;
using MusicCatalog.Application.Services.UserContext;
using MusicCatalog.Domain.Entities;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Domain.Utils;

namespace MusicCatalog.Application.Albums.Queries
{
    public class GetProvidersAllAlbumsQueryHandler : IRequestHandler<GetProvidersAllAlbumsQuery, PagedResult<ListAlbumResponse>>
    {
        private readonly IAlbumRepository _repository;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;

        public GetProvidersAllAlbumsQueryHandler(IAlbumRepository repository, IUserContextService userContextService, IMapper mapper)
        {
            _repository = repository;
            _userContextService = userContextService;
            _mapper = mapper;
        }

        public async Task<PagedResult<ListAlbumResponse>> Handle(GetProvidersAllAlbumsQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _repository.GetProvidersAlbumsAsync(_userContextService.UserId.Value.ToString(), request.Filters);
            var mappedAlbums = _mapper.Map<IEnumerable<Album>, IEnumerable<ListAlbumResponse>>(queryResult.Items);
            var resultPage = new ResultPage<ListAlbumResponse>(mappedAlbums, queryResult.TotalItemsCount);
            return new PagedResult<ListAlbumResponse>(resultPage, request.Filters);
        }
    }
}
