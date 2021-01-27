using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace GeolettApi.Application.Models
{
    public abstract class ViewModelWithValidation
    {
        [JsonIgnore]
        public List<string> ValidationErrors { get; set; }
        [JsonIgnore]
        public bool IsValid => ValidationErrors == null || !ValidationErrors.Any();
    }
}
