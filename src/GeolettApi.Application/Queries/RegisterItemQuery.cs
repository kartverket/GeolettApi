using GeolettApi.Application.Mapping;
using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;
using GeolettApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeolettApi.Application.Queries
{
    public class RegisterItemQuery : IRegisterItemQuery
    {
        private readonly GeolettContext _context;
        private readonly IViewModelMapper<RegisterItem, RegisterItemViewModel> _registerItemViewModelMapper;

        public RegisterItemQuery(
            GeolettContext context,
            IViewModelMapper<RegisterItem, RegisterItemViewModel> registerItemViewModelMapper)
        {
            _context = context;
            _registerItemViewModelMapper = registerItemViewModelMapper;
        }

        public async Task<List<RegisterItemViewModel>> GetAllAsync()
        {
            var registerItems = await _context.RegisterItems
                .Include(registerItem => registerItem.Links)
                .AsNoTracking()
                .ToListAsync();

            var viewModels = registerItems
                .ConvertAll(registerItem => _registerItemViewModelMapper.MapToViewModel(registerItem));

            return viewModels;
        }

        public async Task<RegisterItemViewModel> GetByIdAsync(int id)
        {
            var registerItem = await _context.RegisterItems
                .Include(registerItem => registerItem.Links)
                .AsNoTracking()
                .SingleOrDefaultAsync(registerItem => registerItem.Id == id);

            return _registerItemViewModelMapper.MapToViewModel(registerItem);
        }
    }
}
