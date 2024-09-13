using FluentValidation;
using GeolettApi.Application.Helpers;
using GeolettApi.Application.Mapping;
using GeolettApi.Application.Models;
using GeolettApi.Application.Services.Authorization;
using GeolettApi.Domain.Models;
using GeolettApi.Domain.Repositories;
using GeolettApi.Infrastructure.DataModel.UnitOfWork;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace GeolettApi.Application.Services
{
    public class RegisterItemService : IRegisterItemService
    {
        private readonly IUnitOfWorkManager _uowManager;
        private readonly IRepository<RegisterItem, int> _registerItemRepository;
        private readonly IViewModelMapper<RegisterItem, RegisterItemViewModel, Geolett> _registerItemViewModelMapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IValidator<RegisterItem> _registerItemValidator;

        public RegisterItemService(
            IUnitOfWorkManager uowManager,
            IRepository<RegisterItem, int> registerItemRepository,
            IViewModelMapper<RegisterItem, RegisterItemViewModel, Geolett> registerItemViewModelMapper,
            IAuthorizationService authorizationService,
            IValidator<RegisterItem> registerItemValidator)
        {
            _uowManager = uowManager;
            _registerItemRepository = registerItemRepository;
            _registerItemViewModelMapper = registerItemViewModelMapper;
            _authorizationService = authorizationService;
            _registerItemValidator = registerItemValidator;
        }

        public async Task<RegisterItemViewModel> CreateAsync(RegisterItemViewModel viewModel)
        {
            await _authorizationService.AuthorizeActivity(UserActivity.CreateRegisterItem);

            var registerItem = _registerItemViewModelMapper.MapToDomainModel(viewModel);

            ValidationHelper.Validate(_registerItemValidator, registerItem);

            using var uow = _uowManager.GetUnitOfWork();
            registerItem.LastUpdated = DateTime.Now;
            _registerItemRepository.Create(registerItem);
            await uow.SaveChangesAsync();

            return _registerItemViewModelMapper.MapToViewModel(registerItem);
        }

        public async Task<RegisterItemViewModel> UpdateAsync(int id, RegisterItemViewModel viewModel)
        {
            await _authorizationService.AuthorizeActivity(UserActivity.UpdateRegisterItem, id);

            var update = _registerItemViewModelMapper.MapToDomainModel(viewModel);

            using var uow = _uowManager.GetUnitOfWork();

            var registerItem = await _registerItemRepository.GetByIdAsync(id);
            if (update.DataSetId == null && update.DataSet != null)
            {
                ObjectType objectType = new ObjectType();

                if (update.DataSet.ObjectTypeId == 0)
                {
                    uow.Context.ObjectTypes.Add(objectType);
                    await uow.SaveChangesAsync();
                }

                DataSet dataSet = new DataSet { Title = update.DataSet.Title != null ? update.DataSet.Title : "" };
                if (update.DataSet.ObjectTypeId == 0)
                {
                    update.DataSet.ObjectTypeId = objectType.Id;
                    dataSet.ObjectTypeId = objectType.Id;
                }
                uow.Context.DataSets.Add(dataSet);
                await uow.SaveChangesAsync();
                update.DataSet.Id = dataSet.Id;
                update.DataSetId = dataSet.Id;
                if (update.DataSet.TypeReference == null)
                    update.DataSet.TypeReference = objectType;

            }
            registerItem.Update(update);

            ValidationHelper.Validate(_registerItemValidator, registerItem);

            registerItem.LastUpdated = DateTime.Now;
            await uow.SaveChangesAsync();

            return _registerItemViewModelMapper.MapToViewModel(registerItem);
        }

        public async Task<RegisterItemViewModel> UpdateAsync(int id, JsonPatchDocument<RegisterItemViewModel> patchDocument)
        {
            await _authorizationService.AuthorizeActivity(UserActivity.UpdateRegisterItem);

            var existing = await _registerItemRepository.GetByIdAsync(id);
            var existingViewModel = _registerItemViewModelMapper.MapToViewModel(existing);

            patchDocument.ApplyTo(existingViewModel);

            using var uow = _uowManager.GetUnitOfWork();

            var updated = _registerItemViewModelMapper.MapToDomainModel(existingViewModel);
            existing.Update(updated);          

            ValidationHelper.Validate(_registerItemValidator, existing);

            existing.LastUpdated = DateTime.Now;
            await uow.SaveChangesAsync();

            return _registerItemViewModelMapper.MapToViewModel(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _authorizationService.AuthorizeActivity(UserActivity.DeleteRegisterItem, id);

            using var uow = _uowManager.GetUnitOfWork();

            var registerItem = await _registerItemRepository.GetByIdAsync(id);

            if (registerItem == null)
                return false;

            _registerItemRepository.Delete(registerItem);
            await uow.SaveChangesAsync();

            return true;
        }

        public Task<RegisterItemViewModel> CloneAsync(RegisterItemViewModel model)
        {
            RegisterItemViewModel registerItemViewModel = new RegisterItemViewModel();
            registerItemViewModel.Id = 0;
            registerItemViewModel.Title = model.Title + " (duplikat)";
            registerItemViewModel.ContextType = model.ContextType;
            registerItemViewModel.Owner = model.Owner;
            registerItemViewModel.Status = Status.Submitted;

            registerItemViewModel.Description = model.Description;
            registerItemViewModel.DialogText = model.DialogText;
            registerItemViewModel.Guidance = model.Guidance;
            registerItemViewModel.OtherComment = model.OtherComment;
            registerItemViewModel.PossibleMeasures = model.PossibleMeasures;
            registerItemViewModel.Sign1 = model.Sign1;
            registerItemViewModel.Sign2 = model.Sign2;
            registerItemViewModel.Sign3 = model.Sign3;
            registerItemViewModel.Sign4 = model.Sign4;
            registerItemViewModel.Sign5 = model.Sign5;
            registerItemViewModel.Sign6 = model.Sign6;
            registerItemViewModel.TechnicalComment = model.TechnicalComment;

            //Dataset
            if (model.DataSet != null)
            {
                DataSetViewModel dataSet = new DataSetViewModel();
                dataSet.BufferDistance = model.DataSet.BufferDistance;
                dataSet.BufferPossibleMeasures = model.DataSet.BufferPossibleMeasures;
                dataSet.BufferText = model.DataSet.BufferText;
                dataSet.Namespace = model.DataSet.Namespace;
                dataSet.Title = model.DataSet.Title;
                if (model.DataSet.TypeReference != null)
                {
                    dataSet.TypeReference = new ObjectTypeViewModel
                    {
                        Attribute = model.DataSet.TypeReference.Attribute,
                        CodeValue = model.DataSet.TypeReference.CodeValue,
                        Type = model.DataSet.TypeReference.Type
                    };

                    dataSet.UrlGmlSchema = model.DataSet.UrlGmlSchema;
                    dataSet.UrlMetadata = model.DataSet.UrlMetadata;
                    dataSet.UuidMetadata = model.DataSet.UuidMetadata;

                    registerItemViewModel.DataSet = dataSet;
                }
            }

            //Links
            if(model.Links!= null) 
            {
                List<RegisterItemLinkViewModel> links = new List<RegisterItemLinkViewModel>();

                foreach(var link in model.Links) 
                {
                    links.Add(new RegisterItemLinkViewModel 
                    { 
                        Link = new LinkViewModel { Text = link.Link.Text, Url = link.Link.Url } 
                    });
                }

                registerItemViewModel.Links = links;
            }

            //References
            if(model.Reference != null) 
            {
                ReferenceViewModel reference = new ReferenceViewModel();
                reference.Title = model.Reference.Title;

                if (model.Reference.CircularFromMinistry != null) 
                {
                    reference.CircularFromMinistry = new LinkViewModel { Text = model.Reference.CircularFromMinistry.Text, Url = model.Reference.CircularFromMinistry.Url };
                }

                if (model.Reference.Tek17 != null)
                {
                    reference.Tek17 = new LinkViewModel { Text = model.Reference.Tek17.Text, Url = model.Reference.Tek17.Url };
                }

                if (model.Reference.OtherLaw != null)
                {
                    reference.OtherLaw = new LinkViewModel { Text = model.Reference.OtherLaw.Text, Url = model.Reference.OtherLaw.Url };
                }

                registerItemViewModel.Reference = reference;
            }

            return Task.FromResult(registerItemViewModel);
        }
    }
}
