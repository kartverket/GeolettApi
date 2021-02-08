using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;

namespace GeolettApi.Application.Mapping
{
    public class ObjectTypeViewModelMapper : IViewModelMapper<ObjectType, ObjectTypeViewModel,Geolett>
    {
        public ObjectType MapToDomainModel(ObjectTypeViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new ObjectType
            {
                Id = viewModel.Id,
                Type = viewModel.Type,
                CodeValue = viewModel.CodeValue,
                Attribute = viewModel.Attribute
            };
        }

        public Geolett MapToGeolett(RegisterItem registerItem)
        {
            throw new System.NotImplementedException();
        }

        public ObjectTypeViewModel MapToViewModel(ObjectType domainModel)
        {
            if (domainModel == null)
                return null;

            return new ObjectTypeViewModel
            {
                Id = domainModel.Id,
                Type = domainModel.Type,
                CodeValue = domainModel.CodeValue,
                Attribute = domainModel.Attribute
            };
        }
    }
}
