﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MusicCatalog.Application.Tracks.Commands
{
    public class UpdateTrackCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int DurationMinutes { get; set; }
        public int DurationSeconds { get; set; }
    }
}
