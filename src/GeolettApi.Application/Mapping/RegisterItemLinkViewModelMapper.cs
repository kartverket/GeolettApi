using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;

namespace GeolettApi.Application.Mapping
{
    public class RegisterItemLinkViewModelMapper : IViewModelMapper<RegisterItemLink, RegisterItemLinkViewModel>
    {
        private readonly IViewModelMapper<Link, LinkViewModel> _linkViewModelMapper;

        public RegisterItemLinkViewModelMapper(
            IViewModelMapper<Link, LinkViewModel> linkViewModelMapper)
        {
            _linkViewModelMapper = linkViewModelMapper;
        }

        public RegisterItemLink MapToDomainModel(RegisterItemLinkViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new RegisterItemLink
            {
                Id = viewModel.Id,
                RegisterItemId = viewModel.RegisterItemId,
                Link = _linkViewModelMapper.MapToDomainModel(viewModel.Link)
            };
        }

        public RegisterItemLinkViewModel MapToViewModel(RegisterItemLink domainModel)
        {
            if (domainModel == null)
                return null;

            return new RegisterItemLinkViewModel
            {
                Id = domainModel.Id,
                RegisterItemId = domainModel.RegisterItemId,
                Link = _linkViewModelMapper.MapToViewModel(domainModel.Link)
            };
        }
    }
}
