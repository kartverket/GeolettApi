using FluentValidation.Results;
using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;
using System.Collections.Generic;

namespace GeolettApi.Application.Mapping
{
    public class DataSetViewModelMapper : IViewModelMapper<DataSet, DataSetViewModel>
    {
        private readonly IViewModelMapper<ObjectType, ObjectTypeViewModel> _objectTypeViewModelMapper;
        private readonly IViewModelMapper<ValidationResult, List<string>> _validationErrorViewModelMapper;

        public DataSetViewModelMapper(
            IViewModelMapper<ObjectType, ObjectTypeViewModel> objectTypeViewModelMapper,
            IViewModelMapper<ValidationResult, List<string>> validationErrorViewModelMapper)
        {
            _objectTypeViewModelMapper = objectTypeViewModelMapper;
            _validationErrorViewModelMapper = validationErrorViewModelMapper;
        }

        public DataSet MapToDomainModel(DataSetViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new DataSet
            {
                Id = viewModel.Id,
                RegisterItemId = viewModel.RegisterItemId,
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
                RegisterItemId = domainModel.RegisterItemId,
                Title = domainModel.Title,
                UrlMetadata = domainModel.UrlMetadata,
                BufferDistance = domainModel.BufferDistance,
                BufferText = domainModel.BufferText,
                UrlGmlSchema = domainModel.UrlGmlSchema,
                Namespace = domainModel.Namespace,
                TypeReference = _objectTypeViewModelMapper.MapToViewModel(domainModel.TypeReference),
                ValidationErrors = _validationErrorViewModelMapper.MapToViewModel(domainModel.ValidationResult)
            };
        }
    }
}
