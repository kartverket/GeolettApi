using GeolettApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolettApi.Application.Queries
{
    public interface IOrganizationQuery
    {
        Task<IList<OrganizationViewModel>> GetAllAsync();
        Task<OrganizationViewModel> GetByIdAsync(int id);
    }
}
