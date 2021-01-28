using GeolettApi.Application.Exceptions;
using GeolettApi.Application.Services.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace GeolettApi.Web.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly ILogger<ControllerBase> _logger;

        protected BaseController(
            ILogger<ControllerBase> logger)
        {
            _logger = logger;
        }

        protected IActionResult HandleException(Exception exception)
        {
            _logger.LogError(exception.ToString());

            return exception switch
            {
                ArgumentException _ or FormatException _ or JsonPatchException _ => BadRequest(),
                InvalidModelException ex => BadRequest(ex.Errors),
                AuthorizationException ex => StatusCode(StatusCodes.Status403Forbidden, ex.Message),
                WorkProcessException ex => StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message),
                Exception _ => StatusCode(StatusCodes.Status500InternalServerError),
                _ => null
            };
        }
    }
}
