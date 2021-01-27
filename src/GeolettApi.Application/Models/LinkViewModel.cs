namespace GeolettApi.Application.Models
{
    public class LinkViewModel : ViewModelWithValidation
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
    }
}
