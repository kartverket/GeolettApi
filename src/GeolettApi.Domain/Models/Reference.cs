using System;

namespace GeolettApi.Domain.Models
{
    [Obsolete("Not used any more, use general list of Links")]
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
            if(updatedEntity != null) 
            { 
                var updated = (Reference)updatedEntity;

                if (Title != updated.Title)
                    Title = updated.Title;
                if (updated.Tek17 != null) {
                    if (Tek17 == null)
                        Tek17 = new Link();
                    Tek17.Update(updated.Tek17);
                }
                else { Tek17 = null; }

                if(updated.OtherLaw != null) 
                {
                    if (OtherLaw == null)
                        OtherLaw = new Link();
                    OtherLaw.Update(updated.OtherLaw);
                }
                else { OtherLaw = null; }


                if(updated.CircularFromMinistry != null) 
                {
                    if (CircularFromMinistry == null)
                        CircularFromMinistry = new Link();
                    CircularFromMinistry.Update(updated.CircularFromMinistry);
                }
                else { CircularFromMinistry = null; }
            }
        }
    }
}
