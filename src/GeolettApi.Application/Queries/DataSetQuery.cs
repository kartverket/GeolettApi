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
        private readonly IViewModelMapper<DataSet, DataSetViewModel> _dataSetViewModelMapper;

        public DataSetQuery(
            GeolettContext context,
            IViewModelMapper<DataSet, DataSetViewModel> dataSetViewModelMapper)
        {
            _context = context;
            _dataSetViewModelMapper = dataSetViewModelMapper;
        }

        public async Task<List<DataSetViewModel>> GetAllAsync()
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
    }
}
