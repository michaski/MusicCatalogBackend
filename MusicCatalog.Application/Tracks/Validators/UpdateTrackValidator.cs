using FluentValidation;
using MusicCatalog.Application.Tracks.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.Tracks.Validators
{
    public class UpdateTrackValidator : AbstractValidator<UpdateTrackCommand>
    {
        public UpdateTrackValidator()
        {
            RuleFor(cmd => cmd.Artist)
                .NotEmpty();
            RuleFor(cmd => cmd.Title)
                .NotEmpty();
            RuleFor(cmd => cmd.ReleaseYear)
                .InclusiveBetween(1800, DateTime.Now.Year);
            RuleFor(cmd => cmd.DurationMinutes)
                .GreaterThanOrEqualTo(0);
            RuleFor(cmd => cmd.DurationSeconds)
                .ExclusiveBetween(0, 60).When(cmd => cmd.DurationMinutes == 0, ApplyConditionTo.CurrentValidator)
                .InclusiveBetween(0, 59).When(cmd => cmd.DurationMinutes > 0, ApplyConditionTo.CurrentValidator);
        }
    }
}
