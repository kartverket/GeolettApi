using FluentValidation;
using GeolettApi.Application;
using GeolettApi.Domain.Models;
using Microsoft.Extensions.Localization;

namespace Geonorge.TiltaksplanApi.Application.Validation
{
    public class RegisterItemValidator : AbstractValidator<RegisterItem>
    {
        public RegisterItemValidator(
            IStringLocalizer<ValidationResource> localizer)
        {
            RuleFor(registerItem => registerItem.Title)
                .NotEmpty()
                .WithMessage(registerItem => localizer["Title"]);

            RuleForEach(registerItem => registerItem.Links)
                .ChildRules(registerItemLink => 
                {
                    registerItemLink.RuleFor(link => link.Link)
                        .SetValidator(new LinkValidator(localizer))
                        .When(link => link.Link != null);
                });

            RuleFor(registerItem => registerItem.DataSet)
                .SetValidator(new DataSetValidator(localizer))
                .When(registerItem => registerItem.DataSet != null);

            RuleFor(registerItem => registerItem.Reference)
                .SetValidator(new ReferenceValidator(localizer))
                .When(registerItem => registerItem.Reference != null);
        }
    }
}
