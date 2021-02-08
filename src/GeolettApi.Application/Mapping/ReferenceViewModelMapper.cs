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
                Title = viewModel.Title,
                Tek17 = _linkViewModelMapper.MapToDomainModel(viewModel.Tek17),
                OtherLaw = _linkViewModelMapper.MapToDomainModel(viewModel.OtherLaw),
                CircularFromMinistry = _linkViewModelMapper.MapToDomainModel(viewModel.CircularFromMinistry)
            };
        }

        public Geolett MapToGeolett(RegisterItem registerItem)
        {
            throw new System.NotImplementedException();
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
