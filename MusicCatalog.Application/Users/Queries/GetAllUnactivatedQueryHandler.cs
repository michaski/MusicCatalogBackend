using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MusicCatalog.Application.Users.Responses;
using MusicCatalog.Domain.Entities;
using MusicCatalog.Domain.Interfaces;

namespace MusicCatalog.Application.Users.Queries
{
    public class GetAllUnactivatedQueryHandler : IRequestHandler<GetAllUnactivatedQuery, List<UserDetailsResponse>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUnactivatedQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserDetailsResponse>> Handle(GetAllUnactivatedQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllUnactivatedAsync();
            return _mapper.Map<IEnumerable<User>, List<UserDetailsResponse>>(users);
        }
    }
}
