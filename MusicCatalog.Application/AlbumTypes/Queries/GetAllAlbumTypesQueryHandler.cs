using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MusicCatalog.Application.AlbumTypes.Responses;
using MusicCatalog.Domain.Entities;
using MusicCatalog.Domain.Interfaces;

namespace MusicCatalog.Application.AlbumTypes.Queries
{
    public class GetAllAlbumTypesQueryHandler : IRequestHandler<GetAllAlbumTypesQuery, IEnumerable<ListAlbumTypesResponse>>
    {
        private readonly IAlbumTypesRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAlbumTypesQueryHandler(IAlbumTypesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListAlbumTypesResponse>> Handle(GetAllAlbumTypesQuery request, CancellationToken cancellationToken)
        {
            var albumTypes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AlbumType>, IEnumerable<ListAlbumTypesResponse>>(albumTypes);
        }
    }
}
