using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MusicCatalog.Application.Auth.Responses
{
    public class RegisterResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public RegisterResponse()
        {
            Succeeded = false;
            Message = "";
        }

        public RegisterResponse(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public RegisterResponse(string message, IEnumerable<IdentityError> errors)
        {
            Succeeded = false;
            Message =
                $"{message}:{Environment.NewLine}{string.Join(Environment.NewLine, errors.Select(error => error.Description))}";
        }
    }
}
