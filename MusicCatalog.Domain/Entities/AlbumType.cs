using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Entities
{
    public class AlbumType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
