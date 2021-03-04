using System;
using System.Collections.Generic;

namespace GeolettApi.Application.Models
{
    public class RegisterItemViewModel
    {
        public int Id { get; set; }
        public OrganizationViewModel Owner { get; set; }
        public string ContextType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<RegisterItemLinkViewModel> Links { get; set; }
        public string DialogText { get; set; }
        public string PossibleMeasures { get; set; }
        public string Guidance { get; set; }
        public DataSetViewModel DataSet { get; set; }
        public ReferenceViewModel Reference { get; set; }
        public string TechnicalComment { get; set; }
        public string OtherComment { get; set; }
        public string Sign1 { get; set; }
        public string Sign2 { get; set; }
        public string Sign3 { get; set; }
        public string Sign4 { get; set; }
        public string Sign5 { get; set; }
        public string Sign6 { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
