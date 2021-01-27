namespace GeolettApi.Application.Mapping
{
    public interface IViewModelMapper<TDomainModel, TViewModel>
    {
        TDomainModel MapToDomainModel(TViewModel viewModel);
        TViewModel MapToViewModel(TDomainModel domainModel);
    }
}
