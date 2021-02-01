using FluentValidation;
using GeolettApi.Application.Exceptions;
using GeolettApi.Application.Models;
using System.Collections.Generic;

namespace GeolettApi.Application.Helpers
{
    public class ValidationHelper
    {
        public static void Validate<T>(IValidator<T> validator, T model)
        {
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
                return;

            var errors = new List<ErrorViewModel>();

            foreach (var error in validationResult.Errors)
                errors.Add(new ErrorViewModel(error.PropertyName, error.ErrorMessage));

            throw new InvalidModelException(errors);
        }
    }
}
