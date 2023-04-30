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
    public class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand, int>
    {
        private readonly IAlbumRepository _repository;
        private readonly IUserContextService _userContextService;

        public DeleteAlbumCommandHandler(IAlbumRepository repository, IUserContextService userContextService)
        {
            _repository = repository;
            _userContextService = userContextService;
        }

        public async Task<int> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = await _repository.GetByIdAsync(request.id);
            if (album == null)
            {
                return 400;
            }

            if (album.ProviderId != _userContextService.UserId.ToString())
            {
                return 403;
            }

            await _repository.DeleteAlbumAsync(album);
            return 204;
        }
    }
}
