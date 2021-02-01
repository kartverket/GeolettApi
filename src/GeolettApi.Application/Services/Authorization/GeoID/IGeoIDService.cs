using GeolettApi.Application.Models;
using System.Threading.Tasks;

namespace GeolettApi.Application.Services.Authorization.GeoID
{
    public interface IGeoIDService
    {
        Task<UserViewModel> GetUser();
    }
}
