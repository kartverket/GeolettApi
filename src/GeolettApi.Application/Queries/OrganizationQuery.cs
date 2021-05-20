using GeolettApi.Application.Mapping;
using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;
using GeolettApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolettApi.Application.Queries
{
    public class OrganizationQuery : IOrganizationQuery
    {
        private readonly GeolettContext _context;
        private readonly IViewModelMapper<Organization, OrganizationViewModel,Geolett> _organizationViewModelMapper;

        public OrganizationQuery(
            GeolettContext context,
            IViewModelMapper<Organization, OrganizationViewModel,Geolett> organizationViewModelMapper)
        {
            _context = context;
            _organizationViewModelMapper = organizationViewModelMapper;
        }

        public async Task<IList<OrganizationViewModel>> GetAllAsync()
        {
            var organizations = await _context.Organizations
                .AsNoTracking()
                .OrderBy(organization => organization.Name)
                .ToListAsync();

            return organizations
                .ConvertAll(organization => _organizationViewModelMapper.MapToViewModel(organization));
        }

        public async Task<OrganizationViewModel> GetByIdAsync(int id)
        {
            var organization = await _context.Organizations
                .AsNoTracking()
                .SingleOrDefaultAsync(organization => organization.Id == id);

            return _organizationViewModelMapper.MapToViewModel(organization);
        }
    }
}
