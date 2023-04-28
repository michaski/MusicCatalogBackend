using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.Auth.Responses
{
    public class LoginResponse
    {
        public bool Succeeded { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
