using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolettApi.Domain.Models
{
    public class Organization : EntityBase
    {
        public string Name { get; set; }
        public long? OrgNumber { get; set; }

        public override void Update(EntityBase updatedEntity)
        {
            var updated = (Organization)updatedEntity;

            if (Name != updated.Name)
                Name = updated.Name;

            if (OrgNumber != updated.OrgNumber)
                OrgNumber = updated.OrgNumber;
        }
    }
}
