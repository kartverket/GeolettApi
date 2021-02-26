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

        public ObjektType MapToGeolett(ObjectType domainModel)
        {
            if (domainModel == null)
                return null;

            return new ObjektType
            {
                Objekttype = domainModel.Type,
                Kodeverdi = domainModel.CodeValue,
                Attributt = domainModel.Attribute
            };
        }

        public Referanse MapToGeolett(Reference reference)
        {
            throw new System.NotImplementedException();
        }
    }
}
