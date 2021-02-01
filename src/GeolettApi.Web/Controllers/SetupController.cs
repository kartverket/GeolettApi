using GeolettApi.Application.Services;
using GeolettApi.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Geonorge.TiltaksplanApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetupController : BaseController
    {
        private readonly ISetupService _setupService;

        public SetupController(
            ISetupService setupService,
            ILogger<SetupController> logger) : base(logger)
        {
            _setupService = setupService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var setup = _setupService.Get();

                return Ok(setup);
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
