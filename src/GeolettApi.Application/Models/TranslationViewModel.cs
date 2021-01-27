using System.Collections.Generic;

namespace GeolettApi.Application.Models
{
    public class TranslationViewModel
    {
        public string Culture { get; set; }
        public IDictionary<string, string> Texts { get; set; }
    }
}
