using FluentValidation.Results;
using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;
using System.Collections.Generic;

namespace GeolettApi.Application.Mapping
{
    public class LinkViewModelMapper : IViewModelMapper<Link, LinkViewModel>
    {
        private readonly IViewModelMapper<ValidationResult, List<string>> _validationErrorViewModelMapper;

        public LinkViewModelMapper(
            IViewModelMapper<ValidationResult, List<string>> validationErrorViewModelMapper)
        {
            _validationErrorViewModelMapper = validationErrorViewModelMapper;
        }

        public Link MapToDomainModel(LinkViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new Link
            {
                Id = viewModel.Id,
                Text = viewModel.Text,
                Url = viewModel.Url
            };
        }

        public LinkViewModel MapToViewModel(Link domainModel)
        {
            if (domainModel == null)
                return null;

            return new LinkViewModel
            {
                Id = domainModel.Id,
                Text = domainModel.Text,
                Url = domainModel.Url,
                ValidationErrors = _validationErrorViewModelMapper.MapToViewModel(domainModel.ValidationResult)
            };
        }
    }
}
