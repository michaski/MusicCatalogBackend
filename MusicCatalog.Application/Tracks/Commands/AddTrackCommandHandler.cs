using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MusicCatalog.Application.Services.UserContext;
using MusicCatalog.Application.Tracks.Responses;
using MusicCatalog.Domain.Entities;
using MusicCatalog.Domain.Interfaces;

namespace MusicCatalog.Application.Tracks.Commands
{
    public class AddTrackCommandHandler : IRequestHandler<AddTrackCommand, TrackManipulationResponse>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;

        public AddTrackCommandHandler(ITrackRepository trackRepository,
            IAlbumRepository albumRepository, 
            IUserContextService userContextService, 
            IMapper mapper)
        {
            _trackRepository = trackRepository;
            _albumRepository = albumRepository;
            _userContextService = userContextService;
            _mapper = mapper;
        }

        public async Task<TrackManipulationResponse> Handle(AddTrackCommand request, CancellationToken cancellationToken)
        {
            var album = await _albumRepository.GetByIdAsync(request.AlbumId);
            if (album is null)
            {
                return new TrackManipulationResponse
                {
                    Status = 400
                };
            }

            if (album.ProviderId != _userContextService.UserId.ToString())
            {
                return new TrackManipulationResponse
                {
                    Status = 403
                };
            }

            var mappedTrackData = _mapper.Map<AddTrackCommand, Track>(request);
            var createdTrack = await _trackRepository.CreateTrackAsync(mappedTrackData);
            //album.Tracks.Add(createdTrack);
            //await _albumRepository.UpdateAlbumAsync(album);
            return new TrackManipulationResponse
            {
                Status = 203,
                TrackResponse = _mapper.Map<Track, TrackDetailsResponse>(createdTrack)
            };
        }
    }
}
