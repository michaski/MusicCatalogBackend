using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Entities
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public Guid TypeId { get; set; }
        public AlbumType Type { get; set; }
        public string ProviderId { get; set; }
        public User Provider { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
