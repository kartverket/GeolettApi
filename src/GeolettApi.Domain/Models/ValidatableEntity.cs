using FluentValidation.Results;

namespace GeolettApi.Domain.Models
{
    public abstract class ValidatableEntity : EntityBase
    {
        public ValidationResult ValidationResult { get; set; }
        public bool IsValid => ValidationResult != null && ValidationResult.IsValid;
    }
}
