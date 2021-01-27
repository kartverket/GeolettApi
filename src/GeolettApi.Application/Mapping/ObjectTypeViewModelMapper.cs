using FluentValidation.Results;
using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;
using System.Collections.Generic;

namespace GeolettApi.Application.Mapping
{
    public class ObjectTypeViewModelMapper : IViewModelMapper<ObjectType, ObjectTypeViewModel>
    {
        private readonly IViewModelMapper<ValidationResult, List<string>> _validationErrorViewModelMapper;

        public ObjectTypeViewModelMapper(
            IViewModelMapper<ValidationResult, List<string>> validationErrorViewModelMapper)
        {
            _validationErrorViewModelMapper = validationErrorViewModelMapper;
        }

        public ObjectType MapToDomainModel(ObjectTypeViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new ObjectType
            {
                Id = viewModel.Id,
                DataSetId = viewModel.DataSetId,
                Type = viewModel.Type,
                CodeValue = viewModel.CodeValue,
                Attribute = viewModel.Attribute
            };
        }

        public ObjectTypeViewModel MapToViewModel(ObjectType domainModel)
        {
            if (domainModel == null)
                return null;

            return new ObjectTypeViewModel
            {
                Id = domainModel.Id,
                DataSetId = domainModel.DataSetId,
                Type = domainModel.Type,
                CodeValue = domainModel.CodeValue,
                Attribute = domainModel.Attribute,
                ValidationErrors = _validationErrorViewModelMapper.MapToViewModel(domainModel.ValidationResult)
            };
        }
    }
}
