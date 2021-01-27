namespace GeolettApi.Application.Models
{
    public class ReferenceViewModel : ViewModelWithValidation
    {
        public int Id { get; set; }
        public int RegisterItemId { get; set; }
        public string Title { get; set; }
        public LinkViewModel Tek17 { get; set; }
        public LinkViewModel OtherLaw { get; set; }
        public LinkViewModel CircularFromMinistry { get; set; }
    }
}
