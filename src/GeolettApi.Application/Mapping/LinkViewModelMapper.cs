using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;

namespace GeolettApi.Application.Mapping
{
    public class LinkViewModelMapper : IViewModelMapper<Link, LinkViewModel,Geolett>
    {
        public Link MapToDomainModel(LinkViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new Link
            {
                Id = viewModel.Id,
                Text = !string.IsNullOrEmpty(viewModel.Text) ? viewModel.Text : "Mangler" ,
                Url = viewModel.Url
            };
        }

        public Geolett MapToGeolett(RegisterItem registerItem)
        {
            throw new System.NotImplementedException();
        }

        public Lenke MapToGeolett(RegisterItemLink link)
        {
            throw new System.NotImplementedException();
        }

        public Geolett MapToGeolett(LinkViewModel link)
        {
            throw new System.NotImplementedException();
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
