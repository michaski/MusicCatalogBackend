using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MusicCatalog.Application.Users.Commands
{
    public class ActivateUserCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
    }
}
