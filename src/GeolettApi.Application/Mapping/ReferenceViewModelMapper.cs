using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;

namespace GeolettApi.Application.Mapping
{
    public class ReferenceViewModelMapper : IViewModelMapper<Reference, ReferenceViewModel,Geolett>
    {
        private readonly IViewModelMapper<Link, LinkViewModel,Geolett> _linkViewModelMapper;

        public ReferenceViewModelMapper(
            IViewModelMapper<Link, LinkViewModel,Geolett> linkViewModelMapper)
        {
            _linkViewModelMapper = linkViewModelMapper;
        }

        public Reference MapToDomainModel(ReferenceViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new Reference
            {
                Id = viewModel.Id,
                Title = !string.IsNullOrEmpty(viewModel.Title) ? viewModel.Title : "Mangler",
                Tek17 = _linkViewModelMapper.MapToDomainModel(viewModel.Tek17),
                OtherLaw = _linkViewModelMapper.MapToDomainModel(viewModel.OtherLaw),
                CircularFromMinistry = _linkViewModelMapper.MapToDomainModel(viewModel.CircularFromMinistry)
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
            Referanse referanse = null;

            if(reference != null) 
            { 

                if (reference.Tek17 != null || reference.OtherLaw != null || reference.CircularFromMinistry != null)
                    referanse = new Referanse { Tittel = reference.Title };

                if (reference.Tek17 != null)
                    referanse.Tek17 = new Lenke { Href = reference.Tek17.Url, Tittel = reference.Tek17.Text };

                if (reference.OtherLaw != null)
                    referanse.AnnenLov = new Lenke { Href = reference.OtherLaw.Url, Tittel = reference.OtherLaw.Text };

                if (reference.CircularFromMinistry != null)
                    referanse.RundskrivFraDep = new Lenke { Href = reference.CircularFromMinistry.Url, Tittel = reference.CircularFromMinistry.Text };

            }

            return referanse;
        }

        public ReferenceViewModel MapToViewModel(Reference domainModel)
        {
            if (domainModel == null)
                return null;

            return new ReferenceViewModel
            {
                Id = domainModel.Id,
                Title = domainModel.Title,
                Tek17 = _linkViewModelMapper.MapToViewModel(domainModel.Tek17),
                OtherLaw = _linkViewModelMapper.MapToViewModel(domainModel.OtherLaw),
                CircularFromMinistry = _linkViewModelMapper.MapToViewModel(domainModel.CircularFromMinistry)
            };
        }
    }
}
