namespace GeolettApi.Application.Models
{
    public class DataSetViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UuidMetadata { get; set; }
        public string UrlMetadata { get; set; }
        public int? BufferDistance { get; set; }
        public string BufferText { get; set; }
        public string BufferPossibleMeasures { get; set; }
        public string UrlGmlSchema { get; set; }
        public string Namespace { get; set; }        
        public ObjectTypeViewModel TypeReference { get; set; }
    }
}
