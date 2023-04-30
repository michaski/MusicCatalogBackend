using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicCatalog.Application.Albums.Responses;
using MusicCatalog.Application.Services.UserContext;
using MusicCatalog.Domain.Entities;
using MusicCatalog.Domain.Interfaces;

namespace MusicCatalog.Application.Albums.Commands
{
    public class CreateNewAlbumCommandHandler : IRequestHandler<CreateNewAlbumCommand, AlbumDetailsResponse>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;

        public CreateNewAlbumCommandHandler(
            IAlbumRepository albumRepository, 
            IUserContextService userContextService,
            IMapper mapper)
        {
            _albumRepository = albumRepository;
            _userContextService = userContextService;
            _mapper = mapper;
        }

        public async Task<AlbumDetailsResponse> Handle(CreateNewAlbumCommand request, CancellationToken cancellationToken)
        {
            var mappedAlbumData = _mapper.Map<CreateNewAlbumCommand, Album>(request);
            mappedAlbumData.ProviderId = _userContextService.UserId.Value.ToString();
            var createdAlbum = await _albumRepository.CreateNewAlbumAsync(mappedAlbumData);
            return _mapper.Map<Album, AlbumDetailsResponse>(createdAlbum);
        }
    }
}
