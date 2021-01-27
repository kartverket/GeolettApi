using FluentValidation;
using GeolettApi.Application;
using GeolettApi.Domain.Models;
using Microsoft.Extensions.Localization;

namespace Geonorge.TiltaksplanApi.Application.Validation
{
    public class LinkValidator : AbstractValidator<Link>
    {
        public LinkValidator(
            IStringLocalizer<ValidationResource> localizer)
        {
            RuleFor(link => link.Text)
                .NotEmpty()
                .WithMessage(link => localizer["LinkText"]);

            RuleFor(link => link.Url)
                .NotEmpty()
                .WithMessage(link => localizer["LinkUrl"]);
        }
    }
}
