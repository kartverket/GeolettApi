namespace GeolettApi.Domain.Models
{
    public class Reference : EntityBase
    {
        public string Title { get; set; }
        public int? Tek17Id { get; set; }
        public Link Tek17 { get; set; }
        public int? OtherLawId { get; set; }
        public Link OtherLaw { get; set; }
        public int? CircularFromMinistryId { get; set; }
        public Link CircularFromMinistry { get; set; }

        public override void Update(EntityBase updatedEntity)
        {
            var updated = (Reference)updatedEntity;

            if (Title != updated.Title)
                Title = updated.Title;

            Tek17.Update(updated.Tek17);

            OtherLaw.Update(updated.OtherLaw);

            CircularFromMinistry.Update(updated.CircularFromMinistry);
        }
    }
}
