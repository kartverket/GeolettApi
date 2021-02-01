using System.Threading.Tasks;

namespace GeolettApi.Application.Services.Authorization
{
    public interface IAuthorizationService
    {
        Task AuthorizeActivity(UserActivity activity, int? entityId = null);
    }
}
