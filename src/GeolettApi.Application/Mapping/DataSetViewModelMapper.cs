using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;

namespace GeolettApi.Application.Mapping
{
    public class DataSetViewModelMapper : IViewModelMapper<DataSet, DataSetViewModel>
    {
        private readonly IViewModelMapper<ObjectType, ObjectTypeViewModel> _objectTypeViewModelMapper;

        public DataSetViewModelMapper(
            IViewModelMapper<ObjectType, ObjectTypeViewModel> objectTypeViewModelMapper)
        {
            _objectTypeViewModelMapper = objectTypeViewModelMapper;
        }

        public DataSet MapToDomainModel(DataSetViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new DataSet
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                UrlMetadata = viewModel.UrlMetadata,
                BufferDistance = viewModel.BufferDistance,
                BufferText = viewModel.BufferText,
                UrlGmlSchema = viewModel.UrlGmlSchema,
                Namespace = viewModel.Namespace,
                TypeReference = _objectTypeViewModelMapper.MapToDomainModel(viewModel.TypeReference)
            };
        }

        public DataSetViewModel MapToViewModel(DataSet domainModel)
        {
            if (domainModel == null)
                return null;

            return new DataSetViewModel
            {
                Id = domainModel.Id,
                Title = domainModel.Title,
                UrlMetadata = domainModel.UrlMetadata,
                BufferDistance = domainModel.BufferDistance,
                BufferText = domainModel.BufferText,
                UrlGmlSchema = domainModel.UrlGmlSchema,
                Namespace = domainModel.Namespace,
                TypeReference = _objectTypeViewModelMapper.MapToViewModel(domainModel.TypeReference)
            };
        }
    }
}
