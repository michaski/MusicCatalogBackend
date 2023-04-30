using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Albums.Commands
{
    public class UpdateAlbumCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public Guid TypeId { get; set; }
    }
}
