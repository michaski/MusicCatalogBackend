using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MusicCatalog.Application.Dtos.Tracks;

namespace MusicCatalog.Application.Albums.Validators
{
    public class NewTrackValidator : AbstractValidator<NewTrackDto>
    {
        public NewTrackValidator()
        {
            RuleFor(dto => dto.Artist)
                .NotEmpty();
            RuleFor(dto => dto.Title)
                .NotEmpty();
            RuleFor(dto => dto.ReleaseYear)
                .InclusiveBetween(1800, DateTime.Now.Year);
            RuleFor(dto => dto.DurationMinutes)
                .GreaterThanOrEqualTo(0);
            RuleFor(dto => dto.DurationSeconds)
                .ExclusiveBetween(0, 60);
        }
    }
}
