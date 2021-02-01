using FluentValidation;
using GeolettApi.Application;
using GeolettApi.Domain.Models;
using Microsoft.Extensions.Localization;

namespace Geonorge.TiltaksplanApi.Application.Validation
{
    public class ObjectTypeValidator : AbstractValidator<ObjectType>
    {
        public ObjectTypeValidator(
            IStringLocalizer<ValidationResource> localizer)
        {

        }
    }
}
