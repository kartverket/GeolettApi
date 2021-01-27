using GeolettApi.Application.Models;
using System.Threading.Tasks;

namespace GeolettApi.Application.Services
{
    public interface IRegisterItemService
    {
        Task<RegisterItemViewModel> CreateAsync(RegisterItemViewModel viewModel);
        Task<RegisterItemViewModel> UpdateAsync(int id, RegisterItemViewModel viewModel);
        Task DeleteAsync(int id);
    }
}
