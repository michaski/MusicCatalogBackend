using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MusicCatalog.Application.Validation.CustomValidators.Auth
{
    public static class CorrectPasswordCustomValidator
    {
        public static IRuleBuilderOptions<T, string> CorrectPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {

            return ruleBuilder
                .Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$")
                .WithMessage("Hasło musi zawierać minimum 6 znaków, w tym conajmniej jedną wielką i jedną małą literę, jedną cyfrę oraz symbol.");
        }
    }
}
