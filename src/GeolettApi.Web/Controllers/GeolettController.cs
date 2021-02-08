using GeolettApi.Application.Models;
using GeolettApi.Application.Queries;
using GeolettApi.Application.Services;
using GeolettApi.Web.Controllers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geonorge.TiltaksplanApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeolettController : BaseController
    {
        private readonly IRegisterItemService _registerItemService;
        private readonly IAsyncQuery<RegisterItemViewModel> _registerItemQuery;

        public GeolettController(
            IRegisterItemService registerItemService,
            IAsyncQuery<RegisterItemViewModel> registerItemQuery,
            ILogger<RegisterItemController> logger) : base(logger)
        {
            _registerItemService = registerItemService;
            _registerItemQuery = registerItemQuery;
        }


        [HttpGet]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(typeof(List<Geolett>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var viewModels = await _registerItemQuery.GetAllAsync();

                return Ok(viewModels);
            }
            catch (Exception exception)
            {
                var result = HandleException(exception);

                if (result != null)
                    return result;

                throw;
            }
        }
    }
}
