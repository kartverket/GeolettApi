using System;
using GeolettApi.Application.Models;
using GeolettApi.Domain.Extensions;
using GeolettApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeolettApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsController : BaseController
    {
        public OptionsController(
            ILogger<SetupController> logger) : base(logger)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var viewModel = new OptionsViewModel
                {
                    Statuses = EnumExtensions.EnumToSelectOptions<Status>()
                };

                return Ok(viewModel);
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
