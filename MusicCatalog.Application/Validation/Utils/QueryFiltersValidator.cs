using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MusicCatalog.Domain.Utils;

namespace MusicCatalog.Application.Validation.Utils
{
    public class QueryFiltersValidator : AbstractValidator<QueryFilters>
    {
        public QueryFiltersValidator()
        {
            RuleFor(query => query.Page)
                .GreaterThan(0)
                .When(query => query.Page.HasValue)
                .NotNull()
                .When(query => query.PageSize.HasValue);
            RuleFor(query => query.PageSize)
                .GreaterThan(0)
                .When(query => query.PageSize.HasValue)
                .NotNull()
                .When(query => query.Page.HasValue);
            RuleFor(query => query.SearchPhrase)
                .MinimumLength(3)
                .When(query => !string.IsNullOrEmpty(query.SearchPhrase))
                .NotEmpty()
                .When(query => query.SearchIn.HasValue);
            RuleFor(query => query.SearchIn)
                .NotNull()
                .IsInEnum()
                .When(query => !string.IsNullOrEmpty(query.SearchPhrase));
            RuleFor(query => query.Ordering)
                .NotNull()
                .IsInEnum()
                .When(query => query.OrderBy.HasValue);
            RuleFor(query => query.OrderBy)
                .NotNull()
                .IsInEnum()
                .When(query => query.Ordering.HasValue);
        }
    }
}
