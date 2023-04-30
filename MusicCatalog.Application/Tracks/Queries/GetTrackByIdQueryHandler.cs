using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MusicCatalog.Application.Tracks.Responses;
using MusicCatalog.Domain.Entities;
using MusicCatalog.Domain.Interfaces;

namespace MusicCatalog.Application.Tracks.Queries
{
    public class GetTrackByIdQueryHandler : IRequestHandler<GetTrackByIdQuery, TrackDetailsResponse>
    {
        private readonly ITrackRepository _repository;
        private readonly IMapper _mapper;

        public GetTrackByIdQueryHandler(ITrackRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TrackDetailsResponse> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
        {
            var track = await _repository.GetTrackByIdAsync(request.TrackId);
            return _mapper.Map<Track, TrackDetailsResponse>(track);
        }
    }
}
