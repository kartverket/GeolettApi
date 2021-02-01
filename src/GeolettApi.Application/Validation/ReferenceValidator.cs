using FluentValidation;
using GeolettApi.Application;
using GeolettApi.Domain.Models;
using Microsoft.Extensions.Localization;

namespace Geonorge.TiltaksplanApi.Application.Validation
{
    public class ReferenceValidator : AbstractValidator<Reference>
    {
        public ReferenceValidator(
            IStringLocalizer<ValidationResource> localizer)
        {
            RuleFor(reference => reference.Title)
                .NotEmpty()
                .WithMessage(reference => localizer["Title"]);

            RuleFor(reference => reference.Tek17)
                .SetValidator(new LinkValidator(localizer))
                .When(reference => reference.Tek17 != null);

            RuleFor(reference => reference.OtherLaw)
                .SetValidator(new LinkValidator(localizer))
                .When(reference => reference.OtherLaw != null);

            RuleFor(reference => reference.CircularFromMinistry)
                .SetValidator(new LinkValidator(localizer))
                .When(reference => reference.CircularFromMinistry != null);
        }
    }
}
