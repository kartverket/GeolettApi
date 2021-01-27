using FluentValidation;
using GeolettApi.Application;
using GeolettApi.Domain.Models;
using Microsoft.Extensions.Localization;

namespace Geonorge.TiltaksplanApi.Application.Validation
{
    public class DataSetValidator : AbstractValidator<DataSet>
    {
        public DataSetValidator(
            IStringLocalizer<ValidationResource> localizer)
        {
            RuleFor(dataSet => dataSet.Title)
                .NotEmpty()
                .WithMessage(dataSet => localizer["Title"]);

            RuleFor(dataSet => dataSet.TypeReference)
                .SetValidator(new ObjectTypeValidator(localizer))
                .When(dataSet => dataSet.TypeReference != null);
        }
    }
}
