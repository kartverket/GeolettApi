namespace GeolettApi.Application.Models
{
    public class ErrorViewModel
    {
        public string PropertyName { get; private set; }
        public string ErrorMessage { get; private set; }

        public ErrorViewModel(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}
