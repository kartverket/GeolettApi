using GeolettApi.Application.Models;
using GeolettApi.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace GeolettApi.Application.Mapping
{
    public class RegisterItemViewModelMapper : IViewModelMapper<RegisterItem, RegisterItemViewModel,Geolett>
    {
        private readonly IViewModelMapper<DataSet, DataSetViewModel,Geolett> _dataSetViewModelMapper;
        private readonly IViewModelMapper<Reference, ReferenceViewModel, Geolett> _referenceViewModelMapper;
        private readonly IViewModelMapper<RegisterItemLink, RegisterItemLinkViewModel, Geolett> _registerItemlinkViewModelMapper;
        private readonly IViewModelMapper<Organization, OrganizationViewModel, Geolett> _organizationViewModelMapper;

        public RegisterItemViewModelMapper(
            IViewModelMapper<DataSet, DataSetViewModel, Geolett> dataSetViewModelMapper,
            IViewModelMapper<Reference, ReferenceViewModel, Geolett> referenceViewModelMapper,
            IViewModelMapper<RegisterItemLink, RegisterItemLinkViewModel, Geolett> registerItemlinkViewModelMapper,
            IViewModelMapper<Organization, OrganizationViewModel, Geolett> organizationViewModelMapper)
        {
            _dataSetViewModelMapper = dataSetViewModelMapper;
            _referenceViewModelMapper = referenceViewModelMapper;
            _registerItemlinkViewModelMapper = registerItemlinkViewModelMapper;
            _organizationViewModelMapper = organizationViewModelMapper;
        }

        public RegisterItem MapToDomainModel(RegisterItemViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            List<RegisterItemLink> links = null;
            if(viewModel.Links != null && viewModel.Links.Count> 0)
                links = viewModel.Links?.ConvertAll(link => _registerItemlinkViewModelMapper.MapToDomainModel(link));

            DataSet dataset = null;
            if(viewModel.DataSet != null)
                dataset= _dataSetViewModelMapper.MapToDomainModel(viewModel.DataSet);

            Reference reference = null;
            if (viewModel.Reference != null)
                reference = _referenceViewModelMapper.MapToDomainModel(viewModel.Reference);

            return new RegisterItem
            {
                Id = viewModel.Id,
                OwnerId = viewModel.Owner?.Id ?? 0,
                ContextType = viewModel.ContextType,
                Title = viewModel.Title,
                Description = viewModel.Description,
                Status = viewModel.Status ?? Status.Submitted,
                Links = links,
                DialogText = viewModel.DialogText,
                PossibleMeasures = viewModel.PossibleMeasures,
                Guidance = viewModel.Guidance,
                DataSet = dataset,
                Reference = reference,
                TechnicalComment = viewModel.TechnicalComment,
                OtherComment = viewModel.OtherComment,
                Sign1 = viewModel.Sign1,
                Sign2 = viewModel.Sign2,
                Sign3 = viewModel.Sign3,
                Sign4 = viewModel.Sign4,
                Sign5 = viewModel.Sign5,
                Sign6 = viewModel.Sign6,
                DegreeRisk = viewModel.Risk
            };
        }

        public RegisterItemViewModel MapToViewModel(RegisterItem domainModel)
        {
            if (domainModel == null)
                return null;
            var model =  new RegisterItemViewModel
            {
                Id = domainModel.Id,
                Owner = _organizationViewModelMapper.MapToViewModel(domainModel.Owner),
                ContextType = domainModel.ContextType,
                Title = domainModel.Title,
                Description = domainModel.Description,
                Status = domainModel.Status ?? Status.Submitted,
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
                LastUpdated = domainModel.LastUpdated,
                Risk = domainModel.DegreeRisk
            };

            //Add reference links to links

            if (domainModel.Reference != null)
            {
                if (domainModel.Reference.OtherLawId.HasValue)
                {
                    model.Links.Add(new RegisterItemLinkViewModel
                    {
                        RegisterItemId = domainModel.Id,
                        Link = new LinkViewModel
                        {
                            Id = domainModel.Reference.OtherLawId.Value,
                            Text = domainModel.Reference.OtherLaw.Text,
                            Url = domainModel.Reference.OtherLaw.Url
                        }
                    });
                }
                if (domainModel.Reference.Tek17Id.HasValue)
                {
                    model.Links.Add(new RegisterItemLinkViewModel
                    {
                        RegisterItemId = domainModel.Id,
                        Link = new LinkViewModel
                        {
                            Id = domainModel.Reference.Tek17Id.Value,
                            Text = domainModel.Reference.Tek17.Text,
                            Url = domainModel.Reference.Tek17.Url
                        }
                    });
                }
                if (domainModel.Reference.CircularFromMinistryId.HasValue)
                {
                    model.Links.Add(new RegisterItemLinkViewModel
                    {
                        RegisterItemId = domainModel.Id,
                        Link = new LinkViewModel
                        {
                            Id = domainModel.Reference.CircularFromMinistryId.Value,
                            Text = domainModel.Reference.CircularFromMinistry.Text,
                            Url = domainModel.Reference.CircularFromMinistry.Url
                        }
                    });
                }
            }

            return model;
        }
        public Geolett MapToGeolett(RegisterItem domainModel)
        {
            if (domainModel == null)
                return null;

            var excludedLinks = new List<int>();
            //if(domainModel.Reference != null) 
            //{
            //    if (domainModel.Reference.OtherLawId.HasValue)
            //        excludedLinks.Add(domainModel.Reference.OtherLawId.Value);
            //    if (domainModel.Reference.Tek17Id.HasValue)
            //        excludedLinks.Add(domainModel.Reference.Tek17Id.Value);
            //    if (domainModel.Reference.CircularFromMinistryId.HasValue)
            //        excludedLinks.Add(domainModel.Reference.CircularFromMinistryId.Value);
            //}

            var statuses = Domain.Extensions.EnumExtensions.EnumToSelectOptions<Status>();

            string status = statuses.Where(s => s.Value == (int)Status.Submitted).Select(y => y.Label).FirstOrDefault();

            if (domainModel.Status.HasValue) 
            {
                status = statuses.Where(s => s.Value == (int)domainModel.Status.Value).Select(y => y.Label).FirstOrDefault();
            }
            var model = new Geolett
            {
                ID = domainModel.Uuid.ToString(),
                KontekstType = domainModel.ContextType,
                Tittel = domainModel.Title,
                ForklarendeTekst = domainModel.Description,
                Lenker = domainModel.Links.Where(e => !excludedLinks.Contains(e.Id)).ToList()?.ConvertAll(link => _registerItemlinkViewModelMapper.MapToGeolett(link)),
                Dialogtekst = domainModel.DialogText,
                MuligeTiltak = domainModel.PossibleMeasures,
                Veiledning = domainModel.Guidance,
                Status = status,
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

            if (domainModel.Reference != null)
            {
                if (domainModel.Reference.OtherLawId.HasValue)
                {
                    model.Lenker.Add(new Lenke
                    {      
                        Tittel = domainModel.Reference.OtherLaw.Text,
                        Href = domainModel.Reference.OtherLaw.Url
                    });
                }
                if (domainModel.Reference.Tek17Id.HasValue)
                {
                    model.Lenker.Add(new Lenke
                    {
                        Tittel = domainModel.Reference.Tek17.Text,
                        Href = domainModel.Reference.Tek17.Url
                    });
                }
                if (domainModel.Reference.CircularFromMinistryId.HasValue)
                {
                    model.Lenker.Add(new Lenke
                    {
                        Tittel = domainModel.Reference.CircularFromMinistry.Text,
                        Href = domainModel.Reference.CircularFromMinistry.Url
                    });
                }
            }

            return model;
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
