namespace GeolettApi.Domain.Models
{
    public class RegisterItemLink : EntityBase
    {
        public int RegisterItemId { get; set; }
        public int LinkId { get; set; }
        public Link Link { get; set; }

        public override void Update(EntityBase updatedEntity)
        {
            if(updatedEntity != null) 
            { 
                var update = (RegisterItemLink) updatedEntity;

                Link.Update(update.Link);
            }
        }
    }
}
