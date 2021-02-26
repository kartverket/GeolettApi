using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;

namespace GeolettApi.Application.Mapping
{
    public class RegisterItemLinkViewModelMapper : IViewModelMapper<RegisterItemLink, RegisterItemLinkViewModel,Geolett>
    {
        private readonly IViewModelMapper<Link, LinkViewModel,Geolett> _linkViewModelMapper;

        public RegisterItemLinkViewModelMapper(
            IViewModelMapper<Link, LinkViewModel,Geolett> linkViewModelMapper)
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

        public Geolett MapToGeolett(RegisterItemLinkViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return _linkViewModelMapper.MapToGeolett(viewModel.Link);
        }

        public Geolett MapToGeolett(RegisterItem registerItem)
        {
            throw new System.NotImplementedException();
        }

        public Lenke MapToGeolett(RegisterItemLink link)
        {
            return new Lenke { Href = link.Link.Url, Tittel = link.Link.Text };
        }

        public Lenke MapToGeolett(LinkViewModel link)
        {
            return new Lenke();
        }

        public Datasett MapToGeolett(DataSet datasett)
        {
            throw new System.NotImplementedException();
        }

        public ObjektType MapToGeolett(ObjectType typeReference)
        {
            throw new System.NotImplementedException();
        }

        public Referanse MapToGeolett(Reference reference)
        {
            throw new System.NotImplementedException();
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

        Geolett IViewModelMapper<RegisterItemLink, RegisterItemLinkViewModel, Geolett>.MapToGeolett(LinkViewModel link)
        {
            throw new System.NotImplementedException();
        }
    }
}
