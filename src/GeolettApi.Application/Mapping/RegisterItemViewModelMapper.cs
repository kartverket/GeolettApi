using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;

namespace GeolettApi.Application.Mapping
{
    public class RegisterItemViewModelMapper : IViewModelMapper<RegisterItem, RegisterItemViewModel,Geolett>
    {
        private readonly IViewModelMapper<DataSet, DataSetViewModel,Geolett> _dataSetViewModelMapper;
        private readonly IViewModelMapper<Reference, ReferenceViewModel, Geolett> _referenceViewModelMapper;
        private readonly IViewModelMapper<RegisterItemLink, RegisterItemLinkViewModel, Geolett> _registerItemlinkViewModelMapper;

        public RegisterItemViewModelMapper(
            IViewModelMapper<DataSet, DataSetViewModel, Geolett> dataSetViewModelMapper,
            IViewModelMapper<Reference, ReferenceViewModel, Geolett> referenceViewModelMapper,
            IViewModelMapper<RegisterItemLink, RegisterItemLinkViewModel, Geolett> registerItemlinkViewModelMapper)
        {
            _dataSetViewModelMapper = dataSetViewModelMapper;
            _referenceViewModelMapper = referenceViewModelMapper;
            _registerItemlinkViewModelMapper = registerItemlinkViewModelMapper;
        }

        public RegisterItem MapToDomainModel(RegisterItemViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new RegisterItem
            {
                Id = viewModel.Id,
                ContextType = viewModel.ContextType,
                Title = viewModel.Title,
                Description = viewModel.Description,
                Links = viewModel.Links?.ConvertAll(link => _registerItemlinkViewModelMapper.MapToDomainModel(link)),
                DialogText = viewModel.DialogText,
                PossibleMeasures = viewModel.PossibleMeasures,
                Guidance = viewModel.Guidance,
                DataSet = _dataSetViewModelMapper.MapToDomainModel(viewModel.DataSet),
                Reference = _referenceViewModelMapper.MapToDomainModel(viewModel.Reference),
                TechnicalComment = viewModel.TechnicalComment,
                OtherComment = viewModel.OtherComment,
                Sign1 = viewModel.Sign1,
                Sign2 = viewModel.Sign2,
                Sign3 = viewModel.Sign3,
                Sign4 = viewModel.Sign4,
                Sign5 = viewModel.Sign5,
                Sign6 = viewModel.Sign6
            };
        }

        public RegisterItemViewModel MapToViewModel(RegisterItem domainModel)
        {
            if (domainModel == null)
                return null;

            return new RegisterItemViewModel
            {
                Id = domainModel.Id,
                ContextType = domainModel.ContextType,
                Title = domainModel.Title,
                Description = domainModel.Description,
                Links = domainModel.Links?.ConvertAll(link => _registerItemlinkViewModelMapper.MapToViewModel(link)),
                DialogText = domainModel.DialogText,
                PossibleMeasures = domainModel.PossibleMeasures,
                Guidance = domainModel.Guidance,
                DataSet = _dataSetViewModelMapper.MapToViewModel(domainModel.DataSet),
                Reference = _referenceViewModelMapper.MapToViewModel(domainModel.Reference),
                TechnicalComment = domainModel.TechnicalComment,
                OtherComment = domainModel.OtherComment,
                Sign1 = domainModel.Sign1,
                Sign2 = domainModel.Sign2,
                Sign3 = domainModel.Sign3,
                Sign4 = domainModel.Sign4,
                Sign5 = domainModel.Sign5,
                Sign6 = domainModel.Sign6,
                LastUpdated = domainModel.LastUpdated                
            };
        }
        public Geolett MapToGeolett(RegisterItem domainModel)
        {
            if (domainModel == null)
                return null;

            return new Geolett
            {
                KontekstType = domainModel.ContextType,
                Tittel = domainModel.Title,
                ForklarendeTekst = domainModel.Description,
                Lenker = domainModel.Links?.ConvertAll(link => _registerItemlinkViewModelMapper.MapToGeolett(link)),
                Dialogtekst = domainModel.DialogText,
                MuligeTiltak = domainModel.PossibleMeasures,
                Veiledning = domainModel.Guidance,
                Datasett = _dataSetViewModelMapper.MapToGeolett(domainModel.DataSet),
                Referanse = _referenceViewModelMapper.MapToGeolett(domainModel.Reference),
                TekniskKommentar = domainModel.TechnicalComment,
                AnnenKommentar = domainModel.OtherComment,
                Tegn1 = domainModel.Sign1,
                Tegn2 = domainModel.Sign2,
                Tegn3 = domainModel.Sign3,
                Tegn4 = domainModel.Sign4,
                Tegn5 = domainModel.Sign5,
                Tegn6 = domainModel.Sign6
            };
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
    }
}
