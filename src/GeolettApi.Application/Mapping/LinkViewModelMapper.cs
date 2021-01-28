using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;

namespace GeolettApi.Application.Mapping
{
    public class LinkViewModelMapper : IViewModelMapper<Link, LinkViewModel>
    {
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
                Url = domainModel.Url
            };
        }
    }
}
