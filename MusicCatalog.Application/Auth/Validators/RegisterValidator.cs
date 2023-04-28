using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MusicCatalog.Application.Auth.Commands;
using MusicCatalog.Application.Validation.CustomValidators.Auth;

namespace MusicCatalog.Application.Auth.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(cmd => cmd.Name)
                .NotEmpty();
            RuleFor(cmd => cmd.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(cmd => cmd.Password)
                .NotEmpty()
                .CorrectPassword();
            RuleFor(cmd => cmd.ConfirmPassword)
                .NotEmpty()
                .Must((cmd, confirmPassword) => confirmPassword.Equals(cmd.Password))
                .WithMessage("Hasła są różne."); ;
            RuleFor(cmd => cmd.PhoneNumber)
                .NotEmpty()
                .PhoneNumber();
        }
    }
}
