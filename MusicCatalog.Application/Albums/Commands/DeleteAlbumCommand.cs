using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MusicCatalog.Application.Albums.Commands
{
    public class DeleteAlbumCommand : IRequest<int>
    {
        public Guid id { get; set; }
    }
}
