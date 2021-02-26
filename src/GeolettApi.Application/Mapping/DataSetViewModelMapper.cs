using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;

namespace GeolettApi.Application.Mapping
{
    public class DataSetViewModelMapper : IViewModelMapper<DataSet, DataSetViewModel, Geolett>
    {
        private readonly IViewModelMapper<ObjectType, ObjectTypeViewModel,Geolett> _objectTypeViewModelMapper;

        public DataSetViewModelMapper(
            IViewModelMapper<ObjectType, ObjectTypeViewModel,Geolett> objectTypeViewModelMapper)
        {
            _objectTypeViewModelMapper = objectTypeViewModelMapper;
        }

        public DataSet MapToDomainModel(DataSetViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new DataSet
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                UrlMetadata = viewModel.UrlMetadata,
                BufferDistance = viewModel.BufferDistance,
                BufferText = viewModel.BufferText,
                UrlGmlSchema = viewModel.UrlGmlSchema,
                Namespace = viewModel.Namespace,
                TypeReference = _objectTypeViewModelMapper.MapToDomainModel(viewModel.TypeReference)
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

        public DataSetViewModel MapToViewModel(DataSet domainModel)
        {
            if (domainModel == null)
                return null;

            return new DataSetViewModel
            {
                Id = domainModel.Id,
                Title = domainModel.Title,
                UrlMetadata = domainModel.UrlMetadata,
                BufferDistance = domainModel.BufferDistance,
                BufferText = domainModel.BufferText,
                UrlGmlSchema = domainModel.UrlGmlSchema,
                Namespace = domainModel.Namespace,
                TypeReference = _objectTypeViewModelMapper.MapToViewModel(domainModel.TypeReference)
            };
        }

        public Datasett MapToGeolett(DataSet domainModel)
        {
            if (domainModel == null)
                return null;

            return new Datasett
            {
                //Id = domainModel.Id, Todo create field with guid datatype ex uuid as Guid
                Tittel = domainModel.Title,
                UrlMetadata = domainModel.UrlMetadata,
                BufferAvstand = domainModel.BufferDistance,
                BufferText = domainModel.BufferText,
                GmlSkjema = domainModel.UrlGmlSchema,
                Navnerom = domainModel.Namespace,
                TypeReferanse = _objectTypeViewModelMapper.MapToGeolett(domainModel.TypeReference)
            };
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
