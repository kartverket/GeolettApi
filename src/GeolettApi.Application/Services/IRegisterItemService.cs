using GeolettApi.Application.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace GeolettApi.Application.Services
{
    public interface IRegisterItemService
    {
        Task<RegisterItemViewModel> CreateAsync(RegisterItemViewModel viewModel);
        Task<RegisterItemViewModel> UpdateAsync(int id, RegisterItemViewModel viewModel);
        Task<RegisterItemViewModel> UpdateAsync(int id, JsonPatchDocument<RegisterItemViewModel> patchDocument);
        Task<bool> DeleteAsync(int id);
    }
}
