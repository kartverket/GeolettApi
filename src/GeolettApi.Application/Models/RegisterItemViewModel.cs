using System;
using System.Collections.Generic;

namespace GeolettApi.Application.Models
{
    public class RegisterItemViewModel : ViewModelWithValidation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DialogText { get; set; }
        public string PossibleMeasures { get; set; }
        public string Guidance { get; set; }
        public string TechnicalComment { get; set; }
        public string OtherComment { get; set; }
        public List<LinkViewModel> Links { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
