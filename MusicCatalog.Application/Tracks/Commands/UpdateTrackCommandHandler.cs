using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MusicCatalog.Application.Services.UserContext;
using MusicCatalog.Domain.Interfaces;

namespace MusicCatalog.Application.Tracks.Commands
{
    public class UpdateTrackCommandHandler : IRequestHandler<UpdateTrackCommand, int>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;

        public UpdateTrackCommandHandler(
            ITrackRepository trackRepository,
            IAlbumRepository albumRepository,
            IUserContextService userContextService,
            IMapper mapper)
        {
            _trackRepository = trackRepository;
            _albumRepository = albumRepository;
            _userContextService = userContextService;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateTrackCommand request, CancellationToken cancellationToken)
        {
            var track = await _trackRepository.GetTrackByIdAsync(request.Id);
            if (track is null)
            {
                return 400;
            }

            var album = await _albumRepository.GetByIdAsync(track.AlbumId);
            if (album.ProviderId != _userContextService.UserId.ToString())
            {
                return 403;
            }

            track.Artist = request.Artist;
            track.Title = request.Title;
            track.ReleaseYear = request.ReleaseYear;
            track.DurationMinutes = request.DurationMinutes;
            track.DurationSeconds = request.DurationSeconds;
            await _trackRepository.UpdateTrackAsync(track);
            return 204;
        }
    }
}
