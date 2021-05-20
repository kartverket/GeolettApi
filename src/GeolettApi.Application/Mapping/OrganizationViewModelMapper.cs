using FluentValidation.Results;
using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;
using System.Collections.Generic;

namespace GeolettApi.Application.Mapping
{
    public class OrganizationViewModelMapper : IViewModelMapper<Organization, OrganizationViewModel,Geolett>
    {

        public OrganizationViewModelMapper(
            )
        {
            
        }

        public Organization MapToDomainModel(OrganizationViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new Organization
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                OrgNumber = viewModel.OrgNumber
            };
        }

        public Geolett MapToGeolett(RegisterItem registerItem)
        {
            throw new System.NotImplementedException();
        }

        public Datasett MapToGeolett(DataSet datasett)
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

        public ObjektType MapToGeolett(ObjectType typeReference)
        {
            throw new System.NotImplementedException();
        }

        public Referanse MapToGeolett(Reference reference)
        {
            throw new System.NotImplementedException();
        }

        public OrganizationViewModel MapToViewModel(Organization domainModel)
        {
            if (domainModel == null)
                return null;

            return new OrganizationViewModel
            {
                Id = domainModel.Id,
                Name = domainModel.Name,
                OrgNumber = domainModel.OrgNumber
            };
        }
    }
}