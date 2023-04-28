using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MusicCatalog.Application.Auth.Commands.Login;
using MusicCatalog.Application.Validation.CustomValidators.Auth;

namespace MusicCatalog.Application.Auth.Validators
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(cmd => cmd.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(cmd => cmd.Password)
                .NotEmpty();
        }
    }
}
