using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MusicCatalog.Domain.Entities
{
    public class User : IdentityUser
    {
        public bool IsActivated { get; set; }
        public DateTime ActivatedOn { get; set; }
        public User? ActivatedBy { get; set; }
    }
}
