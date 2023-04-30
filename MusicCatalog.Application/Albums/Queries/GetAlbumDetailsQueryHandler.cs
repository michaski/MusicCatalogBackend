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
    public class GetAlbumDetailsQueryHandler : IRequestHandler<GetAlbumDetailsQuery, GetAlbumResponse>
    {
        private readonly IAlbumRepository _repository;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;

        public GetAlbumDetailsQueryHandler(IAlbumRepository repository, IUserContextService userContextService, IMapper mapper)
        {
            _repository = repository;
            _userContextService = userContextService;
            _mapper = mapper;
        }

        public async Task<GetAlbumResponse> Handle(GetAlbumDetailsQuery request, CancellationToken cancellationToken)
        {
            var album = await _repository.GetByIdAsync(request.AlbumId);
            if (album == null)
            {
                return new GetAlbumResponse
                {
                    Succeeded = false,
                    Error = 404
                };
            }

            if (album.ProviderId != _userContextService.UserId.ToString())
            {
                return new GetAlbumResponse
                {
                    Succeeded = false,
                    Error = 403
                };
            }

            var albumResponse =  _mapper.Map<Album, AlbumDetailsResponse>(album);
            return new GetAlbumResponse
            {
                Succeeded = true,
                Album = albumResponse
            };
        }
    }
}
