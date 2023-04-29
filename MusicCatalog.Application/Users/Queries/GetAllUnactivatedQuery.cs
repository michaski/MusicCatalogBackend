using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MusicCatalog.Application.Users.Responses;

namespace MusicCatalog.Application.Users.Queries
{
    public class GetAllUnactivatedQuery : IRequest<List<UserDetailsResponse>> { }
}
