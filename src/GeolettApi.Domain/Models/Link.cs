namespace GeolettApi.Domain.Models
{
    public class Link : ValidatableEntity
    {
        public string Text { get; set; }
        public string Url { get; set; }

        public override void Update(EntityBase updatedEntity)
        {
            var updated = (Link) updatedEntity;

            if (Text != updated.Text)
                Text = updated.Text;

            if (Url != updated.Url)
                Url = updated.Url;
        }
    }
}
