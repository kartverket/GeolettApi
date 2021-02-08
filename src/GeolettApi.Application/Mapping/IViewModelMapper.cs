using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;
using System.Collections.Generic;

namespace GeolettApi.Application.Mapping
{
    public interface IViewModelMapper<TDomainModel, TViewModel, TGeolett>
    {
        TDomainModel MapToDomainModel(TViewModel viewModel);
        TViewModel MapToViewModel(TDomainModel domainModel);
        TGeolett MapToGeolett(RegisterItem registerItem);
    }
}
