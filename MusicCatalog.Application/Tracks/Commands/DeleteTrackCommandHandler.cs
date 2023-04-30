using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MusicCatalog.Application.Services.UserContext;
using MusicCatalog.Domain.Interfaces;

namespace MusicCatalog.Application.Tracks.Commands
{
    public class DeleteTrackCommandHandler : IRequestHandler<DeleteTrackCommand, int>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IUserContextService _userContextService;

        public DeleteTrackCommandHandler(
            ITrackRepository trackRepository,
            IAlbumRepository albumRepository,
            IUserContextService userContextService)
        {
            _trackRepository = trackRepository;
            _albumRepository = albumRepository;
            _userContextService = userContextService;
        }

        public async Task<int> Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
        {
            var track = await _trackRepository.GetTrackByIdAsync(request.id);
            if (track is null)
            {
                return 400;
            }

            var album = await _albumRepository.GetByIdAsync(track.AlbumId);
            if (album.ProviderId != _userContextService.UserId.ToString())
            {
                return 403;
            }

            await _trackRepository.DeleteTrackAsync(track);
            return 204;
        }
    }
}
