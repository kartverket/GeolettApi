using GeolettApi.Domain.Models;
using System.Collections.Generic;

namespace GeolettApi.Application.Models
{
    public class OptionsViewModel
    {
        public IEnumerable<SelectOption> Statuses { get; set; }
    }
}
