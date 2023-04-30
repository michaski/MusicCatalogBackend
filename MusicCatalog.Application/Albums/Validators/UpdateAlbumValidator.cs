using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MusicCatalog.Application.Albums.Commands;

namespace MusicCatalog.Application.Albums.Validators
{
    public class UpdateAlbumValidator : AbstractValidator<UpdateAlbumCommand>
    {
        public UpdateAlbumValidator()
        {
            RuleFor(cmd => cmd.Artist)
                .NotEmpty();
            RuleFor(cmd => cmd.Title)
                .NotEmpty();
            RuleFor(cmd => cmd.TypeId)
                .NotEmpty();
            RuleFor(cmd => cmd.ReleaseYear)
                .InclusiveBetween(1800, DateTime.Now.Year);
        }
    }
}
