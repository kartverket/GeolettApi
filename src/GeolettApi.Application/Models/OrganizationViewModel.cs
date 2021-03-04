using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolettApi.Application.Models
{
    public class OrganizationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long? OrgNumber { get; set; }
    }
}
