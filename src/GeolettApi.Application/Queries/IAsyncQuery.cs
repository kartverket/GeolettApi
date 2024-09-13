using GeolettApi.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeolettApi.Application.Queries
{
    public interface IAsyncQuery<TViewModel>
    {
        Task<List<TViewModel>> GetAllInternalAsync(string search = null);
        Task<TViewModel> GetByIdAsync(int id);
        Task<List<Geolett>> GetAllAsync();
        Task<bool> HasOwnership(int id, long orgNumber);
    }
}
