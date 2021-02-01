using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;

namespace GeolettApi.Application.Mapping
{
    public class RegisterItemViewModelMapper : IViewModelMapper<RegisterItem, RegisterItemViewModel>
    {
        private readonly IViewModelMapper<DataSet, DataSetViewModel> _dataSetViewModelMapper;
        private readonly IViewModelMapper<Reference, ReferenceViewModel> _referenceViewModelMapper;
        private readonly IViewModelMapper<RegisterItemLink, RegisterItemLinkViewModel> _registerItemlinkViewModelMapper;

        public RegisterItemViewModelMapper(
            IViewModelMapper<DataSet, DataSetViewModel> dataSetViewModelMapper,
            IViewModelMapper<Reference, ReferenceViewModel> referenceViewModelMapper,
            IViewModelMapper<RegisterItemLink, RegisterItemLinkViewModel> registerItemlinkViewModelMapper)
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
    }
}
