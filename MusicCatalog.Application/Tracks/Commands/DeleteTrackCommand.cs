using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MusicCatalog.Application.Tracks.Commands
{
    public class DeleteTrackCommand : IRequest<int>
    {
        public Guid id { get; set; }
    }
}
