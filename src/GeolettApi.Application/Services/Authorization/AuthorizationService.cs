using GeolettApi.Application.Models;
using GeolettApi.Application.Queries;
using GeolettApi.Application.Services.Authorization.GeoID;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolettApi.Application.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly List<ActivityAccess> _accesses;
        private readonly IGeoIDService _geoIDService;
        private readonly ILogger<AuthorizationService> _logger;

        public AuthorizationService(
            IGeoIDService geoIDService,
            IAsyncQuery<RegisterItemViewModel> accessQuery,
            ILogger<AuthorizationService> logger)
        {
            _geoIDService = geoIDService;
            _logger = logger;

            _accesses = new List<ActivityAccess>
            {
                new ActivityAccess(UserActivity.CreateRegisterItem, new List<string> { GeonorgeRole.Admin, GeonorgeRole.Editor }, accessQuery.HasOwnership),
                new ActivityAccess(UserActivity.UpdateRegisterItem, new List<string> { GeonorgeRole.Admin, GeonorgeRole.Editor }, accessQuery.HasOwnership),
                new ActivityAccess(UserActivity.DeleteRegisterItem, new List<string> { GeonorgeRole.Admin, GeonorgeRole.Editor }, accessQuery.HasOwnership),
            };
        }

        public async Task AuthorizeActivity(UserActivity activity, int? entityId)
        {
            var access = _accesses.SingleOrDefault(access => access.Activity == activity);

            if (access == null)
            {
                _logger.LogWarning($"No access defined for the activity '{activity}'.");
                throw new AuthorizationException($"No access defined for the activity '{activity}'.");
            }

            var user = await _geoIDService.GetUser();

            if (user == null)
            {
                _logger.LogWarning($"No authenticated user found.");
                throw new AuthorizationException($"No authenticated user found.");
            }

            if (user.IsAdmin)
                return;

            var hasRole = access.Roles.Any(role => user.HasRole(role));

            if (!hasRole)
            {
                _logger.LogWarning($"The user doesn't have a role with access to the activity '{activity}'.");
                throw new AuthorizationException($"The user doesn't have a role with access to the activity '{activity}'.");
            }

            if (access.OwnershipAction == null)
                return;

            if (activity == UserActivity.CreateRegisterItem)
                return;

            var hasOwnership = await access.OwnershipAction(entityId.GetValueOrDefault(), user.OrganizationNumber);

            if (hasOwnership)
                return;

            _logger.LogWarning($"The user doesn't have the ownership which grants access to the activity '{activity}'.");
            throw new AuthorizationException($"The user doesn't have the ownership which grants access to the activity '{activity}'.");
        }
    }
}
