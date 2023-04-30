using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MusicCatalog.Application.Services.UserContext;
using MusicCatalog.Domain.Interfaces;

namespace MusicCatalog.Application.Albums.Commands
{
    public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, int>
    {
        private readonly IAlbumRepository _repository;
        private readonly IUserContextService _userContextService;

        public UpdateAlbumCommandHandler(IAlbumRepository repository, IUserContextService userContextService)
        {
            _repository = repository;
            _userContextService = userContextService;
        }

        public async Task<int> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = await _repository.GetByIdAsync(request.Id);
            if (album is null)
            {
                return 400;
            }

            if (album.ProviderId != _userContextService.UserId.ToString())
            {
                return 403;
            }

            album.TypeId = request.TypeId;
            album.Title = request.Title;
            album.Artist = request.Artist;
            album.ReleaseYear = request.ReleaseYear;
            await _repository.UpdateAlbumAsync(album);
            return 204;
        }
    }
}
