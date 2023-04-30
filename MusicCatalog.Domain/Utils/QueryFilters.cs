using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCatalog.Domain.Enums;

namespace MusicCatalog.Domain.Utils
{
    public class QueryFilters
    {
        public string? SearchPhrase { get; set; }
        public AlbumFields? SearchIn { get; set; }
        public AlbumFields? OrderBy { get; set; }
        public SortingOrder? Ordering { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
