﻿namespace GeolettApi.Domain.Models
{
    public class DataSet : EntityBase
    {
        public string Title { get; set; }
        public string UuidMetadata { get; set; }
        public string UrlMetadata { get; set; }
        public int? BufferDistance { get; set; }
        public string BufferText { get; set; }
        public string BufferPossibleMeasures { get; set; }
        public string UrlGmlSchema { get; set; }
        public string Namespace { get; set; }
        public int ObjectTypeId { get; set; }
        public ObjectType TypeReference { get; set; }

        public override void Update(EntityBase updatedEntity)
        {
            if(updatedEntity != null) 
            { 

                var updated = (DataSet) updatedEntity;

                if (Title != updated.Title)
                    Title = updated.Title;

                if (UrlMetadata != updated.UrlMetadata)
                    UrlMetadata = updated.UrlMetadata;

                if (UuidMetadata != updated.UuidMetadata)
                    UuidMetadata = updated.UuidMetadata;

                if (BufferDistance != updated.BufferDistance)
                    BufferDistance = updated.BufferDistance;

                if (BufferText != updated.BufferText)
                    BufferText = updated.BufferText;

                if (BufferPossibleMeasures != updated.BufferPossibleMeasures)
                    BufferPossibleMeasures = updated.BufferPossibleMeasures;

                if (Namespace != updated.Namespace)
                    Namespace = updated.Namespace;

                if(updated.TypeReference != null) {
                    if (TypeReference == null)
                        TypeReference = new ObjectType();

                    TypeReference.Update(updated.TypeReference);
                }

            }
        }
    }
}
