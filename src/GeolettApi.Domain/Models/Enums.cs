using GeolettApi.Domain.Attributes;

namespace GeolettApi.Domain.Models
{
    public enum Status
    {
        [LocalizedDescription("Submitted")]
        Submitted = 1,
        [LocalizedDescription("Valid")]
        Valid = 2
    }
}
