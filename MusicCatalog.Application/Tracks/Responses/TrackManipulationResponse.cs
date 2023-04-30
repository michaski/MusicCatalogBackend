using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.Tracks.Responses
{
    public class TrackManipulationResponse
    {
        public int Status { get; set; }
        public TrackDetailsResponse TrackResponse { get; set; }
    }
}
