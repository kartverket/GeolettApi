using FluentValidation.Results;
using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;
using System.Collections.Generic;

namespace GeolettApi.Application.Mapping
{
    public class RegisterItemViewModelMapper : IViewModelMapper<RegisterItem, RegisterItemViewModel>
    {
        private readonly IViewModelMapper<Link, LinkViewModel> _linkViewModelMapper;
        private readonly IViewModelMapper<ValidationResult, List<string>> _validationErrorViewModelMapper;

        public RegisterItemViewModelMapper(
            IViewModelMapper<Link, LinkViewModel> linkViewModelMapper,
            IViewModelMapper<ValidationResult, List<string>> validationErrorViewModelMapper)
        {
            _linkViewModelMapper = linkViewModelMapper;
            _validationErrorViewModelMapper = validationErrorViewModelMapper;
        }

        public RegisterItem MapToDomainModel(RegisterItemViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new RegisterItem
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Description = viewModel.Description,
                DialogText = viewModel.DialogText,
                PossibleMeasures = viewModel.PossibleMeasures,
                Guidance = viewModel.Guidance,
                TechnicalComment = viewModel.TechnicalComment,
                OtherComment = viewModel.OtherComment,
                Links = viewModel.Links?.ConvertAll(link => _linkViewModelMapper.MapToDomainModel(link))
            };
        }

        public RegisterItemViewModel MapToViewModel(RegisterItem domainModel)
        {
            if (domainModel == null)
                return null;

            return new RegisterItemViewModel
            {
                Id = domainModel.Id,
                Title = domainModel.Title,
                Description = domainModel.Description,
                DialogText = domainModel.DialogText,
                PossibleMeasures = domainModel.PossibleMeasures,
                Guidance = domainModel.Guidance,
                TechnicalComment = domainModel.TechnicalComment,
                OtherComment = domainModel.OtherComment,
                Links = domainModel.Links?.ConvertAll(link => _linkViewModelMapper.MapToViewModel(link)),
                ValidationErrors = _validationErrorViewModelMapper.MapToViewModel(domainModel.ValidationResult),
                LastUpdated = domainModel.LastUpdated
            };
        }
    }
}
