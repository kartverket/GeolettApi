namespace GeolettApi.Domain.Models
{
    public class ObjectType : EntityBase
    {
        public string Type { get; set; }
        public string Attribute { get; set; }
        public string CodeValue { get; set; }

        public override void Update(EntityBase updatedEntity)
        {
            var updated = (ObjectType)updatedEntity;

            if (Type != updated.Type)
                Type = updated.Type;

            if (Attribute != updated.Attribute)
                Attribute = updated.Attribute;

            if (CodeValue != updated.CodeValue)
                CodeValue = updated.CodeValue;
        }
    }
}
