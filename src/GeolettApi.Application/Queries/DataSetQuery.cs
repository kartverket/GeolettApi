using GeolettApi.Application.Mapping;
using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;
using GeolettApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeolettApi.Application.Queries
{
    public class DataSetQuery : IAsyncQuery<DataSetViewModel>
    {
        private readonly GeolettContext _context;
        private readonly IViewModelMapper<DataSet, DataSetViewModel, Geolett> _dataSetViewModelMapper;

        public DataSetQuery(
            GeolettContext context,
            IViewModelMapper<DataSet, DataSetViewModel, Geolett> dataSetViewModelMapper)
        {
            _context = context;
            _dataSetViewModelMapper = dataSetViewModelMapper;
        }

        public Task<List<Geolett>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<DataSetViewModel>> GetAllInternalAsync()
        {
            var dataSets = await _context.DataSets
                .Include(registerItem => registerItem.TypeReference)
                .AsNoTracking()
                .ToListAsync();

            var viewModels = dataSets
                .ConvertAll(dataSet => _dataSetViewModelMapper.MapToViewModel(dataSet));

            return viewModels;
        }

        public async Task<DataSetViewModel> GetByIdAsync(int id)
        {
            var dataSet = await _context.DataSets
                .Include(registerItem => registerItem.TypeReference)
                .AsNoTracking()
                .SingleOrDefaultAsync(dataSet => dataSet.Id == id);

            return _dataSetViewModelMapper.MapToViewModel(dataSet);
        }

        public Task<bool> HasOwnership(int id, long orgNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
