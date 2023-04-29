using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Entities
{
    public class Track
    {
        public Guid Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int DurationMinutes { get; set; }
        public int DurationSeconds { get; set; }
        public Guid AlbumId { get; set; }
    }
}
