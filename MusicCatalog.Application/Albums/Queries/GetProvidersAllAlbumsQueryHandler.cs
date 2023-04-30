using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MusicCatalog.Application.Albums.Responses;
using MusicCatalog.Application.Services.UserContext;
using MusicCatalog.Domain.Entities;
using MusicCatalog.Domain.Interfaces;

namespace MusicCatalog.Application.Albums.Queries
{
    public class GetProvidersAllAlbumsQueryHandler : IRequestHandler<GetProvidersAllAlbumsQuery, IEnumerable<ListAlbumResponse>>
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

        public async Task<IEnumerable<ListAlbumResponse>> Handle(GetProvidersAllAlbumsQuery request, CancellationToken cancellationToken)
        {
            var albums = await _repository.GetProvidersAlbumsAsync(_userContextService.UserId.Value.ToString());
            return _mapper.Map<IEnumerable<Album>, IEnumerable<ListAlbumResponse>>(albums);
        }
    }
}
