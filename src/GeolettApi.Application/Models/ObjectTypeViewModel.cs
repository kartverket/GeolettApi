namespace GeolettApi.Application.Models
{
    public class ObjectTypeViewModel : ViewModelWithValidation
    {
        public int Id { get; set; }
        public int DataSetId { get; set; }
        public string Type { get; set; }
        public string Attribute { get; set; }
        public string CodeValue { get; set; }
    }
}
