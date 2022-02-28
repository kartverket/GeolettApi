using GeolettApi.Application.Mapping;
using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;
using GeolettApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GeolettApi.Application.Queries
{
    public class RegisterItemQuery : IAsyncQuery<RegisterItemViewModel>
    {
        private readonly GeolettContext _context;
        private readonly IViewModelMapper<RegisterItem, RegisterItemViewModel, Geolett> _registerItemViewModelMapper;

        public RegisterItemQuery(
            GeolettContext context,
            IViewModelMapper<RegisterItem, RegisterItemViewModel, Geolett> registerItemViewModelMapper)
        {
            _context = context;
            _registerItemViewModelMapper = registerItemViewModelMapper;
        }

        public async Task<List<RegisterItemViewModel>> GetAllInternalAsync()
        {
            var registerItems = await _context.RegisterItems
                .Include(organization => organization.Owner)
                .Include(registerItem => registerItem.DataSet)
                    .ThenInclude(dataSet => dataSet.TypeReference)
                .Include(registerItem => registerItem.Reference)
                    .ThenInclude(reference => reference.Tek17)
                .Include(registerItem => registerItem.Reference)
                    .ThenInclude(reference => reference.OtherLaw)
                .Include(registerItem => registerItem.Reference)
                    .ThenInclude(reference => reference.CircularFromMinistry)
                .Include(registerItem => registerItem.Links)
                    .ThenInclude(registerItemLink => registerItemLink.Link)
                .AsNoTracking()
                .ToListAsync();

            var viewModels = registerItems
                .ConvertAll(registerItem => _registerItemViewModelMapper.MapToViewModel(registerItem));

            return viewModels.OrderBy(o => o.ContextType).ToList();
        }

        public async Task<List<Geolett>> GetAllAsync()
        {
            var registerItems = await _context.RegisterItems
                .Include(registerItem => registerItem.DataSet)
                    .ThenInclude(dataSet => dataSet.TypeReference)
                .Include(registerItem => registerItem.Reference)
                    .ThenInclude(reference => reference.Tek17)
                .Include(registerItem => registerItem.Reference)
                    .ThenInclude(reference => reference.OtherLaw)
                .Include(registerItem => registerItem.Reference)
                    .ThenInclude(reference => reference.CircularFromMinistry)
                .Include(registerItem => registerItem.Links)
                    .ThenInclude(registerItemLink => registerItemLink.Link)
                .AsNoTracking()
                .ToListAsync();

            var viewModels = registerItems
                .ConvertAll(registerItem => _registerItemViewModelMapper.MapToGeolett(registerItem));

            return viewModels.OrderBy(o => o.KontekstType).ToList();
        }


        public async Task<RegisterItemViewModel> GetByIdAsync(int id)
        {
            var registerItem = await _context.RegisterItems
                .Include(registerItem => registerItem.Owner)
                .Include(registerItem => registerItem.DataSet)
                    .ThenInclude(dataSet => dataSet.TypeReference)
                .Include(registerItem => registerItem.Reference)
                    .ThenInclude(reference => reference.Tek17)
                .Include(registerItem => registerItem.Reference)
                    .ThenInclude(reference => reference.OtherLaw)
                .Include(registerItem => registerItem.Reference)
                    .ThenInclude(reference => reference.CircularFromMinistry)
                .Include(registerItem => registerItem.Links)
                    .ThenInclude(registerItemLink => registerItemLink.Link)
                .AsNoTracking()
                .SingleOrDefaultAsync(registerItem => registerItem.Id == id);

            return _registerItemViewModelMapper.MapToViewModel(registerItem);
        }

        public async Task<bool> HasOwnership(int id, long orgNumber)
        {
            var register = await _context.RegisterItems
                .Include(owner => owner.Owner)
                .AsNoTracking()
                .SingleOrDefaultAsync(register => register.Id == id);

            if (register == null)
                return false;

            return register.Owner.OrgNumber == orgNumber;
        }
    }
}
