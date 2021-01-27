using FluentValidation;
using GeolettApi.Application.Mapping;
using GeolettApi.Application.Models;
using GeolettApi.Application.Services.Authorization;
using GeolettApi.Domain.Models;
using GeolettApi.Domain.Repositories;
using GeolettApi.Infrastructure.DataModel.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace GeolettApi.Application.Services
{
    public class RegisterItemService : IRegisterItemService
    {
        private readonly IUnitOfWorkManager _uowManager;
        private readonly IRepository<RegisterItem, int> _registerItemRepository;
        private readonly IViewModelMapper<RegisterItem, RegisterItemViewModel> _registerItemViewModelMapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IValidator<RegisterItem> _registerItemValidator;

        public RegisterItemService(
            IUnitOfWorkManager uowManager,
            IRepository<RegisterItem, int> registerItemRepository,
            IViewModelMapper<RegisterItem, RegisterItemViewModel> registerItemViewModelMapper,
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

            if (IsValid(registerItem))
            {
                using var uow = _uowManager.GetUnitOfWork();
                registerItem.LastUpdated = DateTime.Now;
                _registerItemRepository.Create(registerItem);
                await uow.SaveChangesAsync();
            }

            return _registerItemViewModelMapper.MapToViewModel(registerItem);
        }

        public async Task<RegisterItemViewModel> UpdateAsync(int id, RegisterItemViewModel viewModel)
        {
            await _authorizationService.AuthorizeActivity(UserActivity.UpdateRegisterItem);

            var update = _registerItemViewModelMapper.MapToDomainModel(viewModel);

            using var uow = _uowManager.GetUnitOfWork();
            var registerItem = await _registerItemRepository
                .GetByIdAsync(id);

            registerItem.Update(update);

            if (IsValid(registerItem))
            {
                registerItem.LastUpdated = DateTime.Now;
                await uow.SaveChangesAsync();
            }

            return _registerItemViewModelMapper.MapToViewModel(registerItem);
        }

        public async Task DeleteAsync(int id)
        {
            await _authorizationService.AuthorizeActivity(UserActivity.DeleteRegisterItem);

            using var uow = _uowManager.GetUnitOfWork();

            var registerItem = await _registerItemRepository.GetByIdAsync(id);
            _registerItemRepository.Delete(registerItem);

            await uow.SaveChangesAsync();
        }

        private bool IsValid(RegisterItem registerItem)
        {
            registerItem.ValidationResult = _registerItemValidator.Validate(registerItem);

            return registerItem.ValidationResult.IsValid;
        }
    }
}
