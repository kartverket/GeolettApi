using FluentValidation.Results;
using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;
using System.Collections.Generic;

namespace GeolettApi.Application.Mapping
{
    public class ReferenceViewModelMapper : IViewModelMapper<Reference, ReferenceViewModel>
    {
        private readonly IViewModelMapper<Link, LinkViewModel> _linkViewModelMapper;
        private readonly IViewModelMapper<ValidationResult, List<string>> _validationErrorViewModelMapper;

        public ReferenceViewModelMapper(
            IViewModelMapper<Link, LinkViewModel> linkViewModelMapper,
            IViewModelMapper<ValidationResult, List<string>> validationErrorViewModelMapper)
        {
            _linkViewModelMapper = linkViewModelMapper;
            _validationErrorViewModelMapper = validationErrorViewModelMapper;
        }

        public Reference MapToDomainModel(ReferenceViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new Reference
            {
                Id = viewModel.Id,
                RegisterItemId = viewModel.RegisterItemId,
                Title = viewModel.Title,
                Tek17 = _linkViewModelMapper.MapToDomainModel(viewModel.Tek17),
                OtherLaw = _linkViewModelMapper.MapToDomainModel(viewModel.OtherLaw),
                CircularFromMinistry = _linkViewModelMapper.MapToDomainModel(viewModel.CircularFromMinistry)
            };
        }

        public ReferenceViewModel MapToViewModel(Reference domainModel)
        {
            if (domainModel == null)
                return null;

            return new ReferenceViewModel
            {
                Id = domainModel.Id,
                RegisterItemId = domainModel.RegisterItemId,
                Title = domainModel.Title,
                Tek17 = _linkViewModelMapper.MapToViewModel(domainModel.Tek17),
                OtherLaw = _linkViewModelMapper.MapToViewModel(domainModel.OtherLaw),
                CircularFromMinistry = _linkViewModelMapper.MapToViewModel(domainModel.CircularFromMinistry),
                ValidationErrors = _validationErrorViewModelMapper.MapToViewModel(domainModel.ValidationResult)
            };
        }
    }
}
