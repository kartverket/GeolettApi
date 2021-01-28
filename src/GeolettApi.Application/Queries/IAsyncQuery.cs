using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeolettApi.Application.Queries
{
    public interface IAsyncQuery<TViewModel>
    {
        Task<List<TViewModel>> GetAllAsync();
        Task<TViewModel> GetByIdAsync(int id);
    }
}
