using GeolettApi.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeolettApi.Application.Queries
{
    public interface IRegisterItemQuery
    {
        Task<List<RegisterItemViewModel>> GetAllAsync();
        Task<RegisterItemViewModel> GetByIdAsync(int id);
    }
}
