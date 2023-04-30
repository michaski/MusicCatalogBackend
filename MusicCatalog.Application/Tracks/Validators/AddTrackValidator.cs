using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MusicCatalog.Application.Tracks.Commands;

namespace MusicCatalog.Application.Tracks.Validators
{
    public class AddTrackValidator : AbstractValidator<AddTrackCommand>
    {
        public AddTrackValidator()
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
                .ExclusiveBetween(0, 60);
            RuleFor(cmd => cmd.AlbumId)
                .NotEmpty();
        }
    }
}
