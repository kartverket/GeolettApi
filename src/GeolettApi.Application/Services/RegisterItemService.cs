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
    }
}
